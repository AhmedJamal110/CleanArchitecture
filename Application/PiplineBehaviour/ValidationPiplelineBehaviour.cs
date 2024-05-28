using Application.CustomException;
using FluentValidation;
using MediatR;

namespace Application.PiplineBehaviour
{

    public class ValidationPiplelineBehaviour<TRequest , TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPiplelineBehaviour(IEnumerable<IValidator<TRequest>> validators )
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                List<string> errors = new();

                var validitorsResponse = await Task.WhenAll(
                    _validators.Select(V => V.ValidateAsync(context, cancellationToken)));

                var failures = validitorsResponse.SelectMany(E => E.Errors)
                                                  .Where(E => E is not null)
                                                  .ToList();

                if(failures.Count > 0)
                {
                    foreach (var failur in failures)
                    {
                        errors.Add(failur.ErrorMessage);
                    }

                    throw new CustomValidationException(errors , "one or more validation failures occure"); 
                }
            }



           return await next();
        }
    }

}
        
  



//namespace Application.PiplineBehaviour
//{
//    public class ValidationPiplelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//        where TRequest : IRequest<TResponse>
//    {
//        private readonly IEnumerable<IValidator<TRequest>> _validators;

//        public ValidationPiplelineBehaviour(IEnumerable<IValidator<TRequest>> validators)
//        {
//            _validators = validators;
//        }

//        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//        {
//            if (_validators.Any())
//            {
//                var context = new ValidationContext<TRequest>(request);
//                List<string> errors = new();

//                var validationResult = await Task.WhenAll(
//                    _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

//                var failures = validationResult.SelectMany(r => r.Errors)
//                                                .Where(e => e != null)
//                                                .ToList();

//                if (failures.Count > 0)
//                {
//                    foreach (var failure in failures)
//                    {
//                        errors.Add(failure.ErrorMessage);
//                    }

//                    throw new ValidationException(errors);
//                }
//            }

//            return await next();
//        }
//    }
//}
