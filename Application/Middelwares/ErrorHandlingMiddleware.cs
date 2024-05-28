using Application.CustomException;
using Application.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
namespace Application.Middelwares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware( RequestDelegate next )
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {

                context.Response.ContentType = "application/json";

                Errors errors = new();

                switch (ex)
                {
                    case CustomValidationException validationException:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        errors.ErrorMessages = validationException.ErrorMessage;
                        errors.FriendlyErrorMessage = validationException.FriendlErrorMessage;
                         break;
                    default:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        errors.FriendlyErrorMessage = ex.Message;
                        break;
                }

                var Result = JsonSerializer.Serialize(errors);
                await context.Response.WriteAsync(Result);


            }
            
        }



    }
}
