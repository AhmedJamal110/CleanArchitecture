using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Properities.Commands
{
    public class UpdateProperirtyRequest : IRequest<bool>
    {
        public UpdatePorperity updatePorperity { get; set; }

        public UpdateProperirtyRequest(UpdatePorperity updateprop)
        {
            updatePorperity = updateprop;
        }

    }

    public class UpdateProperirtyRequestHandler : IRequestHandler<UpdateProperirtyRequest, bool>
    {
        private readonly IProperityRepo _properityRepo;
        private readonly IMapper _mapper;

        public UpdateProperirtyRequestHandler(IProperityRepo properityRepo, IMapper mapper)
        {
            _properityRepo = properityRepo;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateProperirtyRequest request, CancellationToken cancellationToken)
        {
            Property properityInDb = await _properityRepo.GetByIdAsync(request.updatePorperity.Id);

            if (properityInDb is not null)
            {
                properityInDb.Name = request.updatePorperity.Name;
                properityInDb.Description = request.updatePorperity.Description;
                properityInDb.Type = request.updatePorperity.Type;
                properityInDb.ErfSize = request.updatePorperity.ErfSize;
                properityInDb.FloorSize = request.updatePorperity.FloorSize;
                properityInDb.Price = request.updatePorperity.Price;
                properityInDb.Levies = request.updatePorperity.Levies;
                properityInDb.Rates = request.updatePorperity.Rates;
                properityInDb.Address = request.updatePorperity.Address;
                properityInDb.PetsAllowed = request.updatePorperity.PetsAllowed;
                properityInDb.Bathrooms = request.updatePorperity.Bathrooms;
                properityInDb.Bedrooms = request.updatePorperity.Bedrooms;
                properityInDb.Kitchens = request.updatePorperity.Kitchens;
                properityInDb.Louge = request.updatePorperity.Louge;
                properityInDb.Dining = request.updatePorperity.Dining;
                properityInDb.ListDate = request.updatePorperity.ListDate;


                await _properityRepo.UPdateAsync(properityInDb);

                return true;
            }

            return false;

        }
    }
}
