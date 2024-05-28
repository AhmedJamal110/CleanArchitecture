using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Properities.Commands
{
    public class DeleteProperityRequest : IRequest<bool>
    {
        public int ProperityId { get; set; }

        public DeleteProperityRequest(int propId)
        {
            ProperityId = propId;
        }

    }

    public class DeleteProperityRequestHandler : IRequestHandler<DeleteProperityRequest, bool>
    {
        private readonly IProperityRepo _properityRepo;

        public DeleteProperityRequestHandler(IProperityRepo properityRepo)
        {
            _properityRepo = properityRepo;
        }
        public async Task<bool> Handle(DeleteProperityRequest request, CancellationToken cancellationToken)
        {

            var properityInDb = await _properityRepo.GetByIdAsync(request.ProperityId);

            if (properityInDb is not null)
            {
                await _properityRepo.DeleteAsync(properityInDb);
                return true;
            }
            return false;


        }
    }
}
