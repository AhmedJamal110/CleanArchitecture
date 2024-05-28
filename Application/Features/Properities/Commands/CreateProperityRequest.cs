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
    public class CreateProperityRequest : IRequest<bool>
    {

        public NewProperityRequest properityRequest { get; set; }

        public CreateProperityRequest(NewProperityRequest newProperityRequest)
        {
            properityRequest = newProperityRequest;
        }


    }


    public class CreateProperityRequestHandler : IRequestHandler<CreateProperityRequest, bool>
    {
        private readonly IProperityRepo _properityRepo;
        private readonly IMapper _mapper;



        public CreateProperityRequestHandler(IProperityRepo properityRepo, IMapper mapper)
        {
            _properityRepo = properityRepo;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateProperityRequest request, CancellationToken cancellationToken)
        {

            // var MappedProperity = _mapper.Map<NewProperityRequest, Property>(request.newProperityRequest);

            Property property = _mapper.Map<Property>(request.properityRequest);

            property.ListDate = DateTime.Now;

            await _properityRepo.AddAsync(property);
            return true;
        }






    }
}
