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

namespace Application.Features.Properities.Queries
{
    public class GetAllProperityRequest : IRequest<IReadOnlyList<ProperityDto>>
    {


    }


    public class GetAllProperityRequestHandler : IRequestHandler<GetAllProperityRequest, IReadOnlyList<ProperityDto>>
    {
        private readonly IProperityRepo _properityRepo;
        private readonly IMapper _mapper;

        public GetAllProperityRequestHandler(IProperityRepo properityRepo, IMapper mapper)
        {
            _properityRepo = properityRepo;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<ProperityDto>> Handle(GetAllProperityRequest request, CancellationToken cancellationToken)
        {

            var Properties = await _properityRepo.GetAllAsync();

            var ProperititesToReturnDto = _mapper.Map<IReadOnlyList<Property>, IReadOnlyList<ProperityDto>>(Properties);

            /// ProperityDto properityDto = _mapper.Map<ProperityDto>(Properties);

            return ProperititesToReturnDto;
        }
    }
}

