using Application.Models;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Properities.Queries
{
    public class GetProperitybyIdRequest : IRequest<ProperityDto>
    {
        public int ProperityId { get; set; }

        public GetProperitybyIdRequest(int properityID)
        {
            ProperityId = properityID;
        }

    }


    public class GetProperityByIdRequestHander : IRequestHandler<GetProperitybyIdRequest, ProperityDto>
    {
        private readonly IProperityRepo _properityRepo;
        private readonly IMapper _mapper;

        public GetProperityByIdRequestHander(IProperityRepo properityRepo, IMapper mapper)
        {
            _properityRepo = properityRepo;
            _mapper = mapper;
        }

        public async Task<ProperityDto> Handle(GetProperitybyIdRequest request, CancellationToken cancellationToken)
        {
            var properity = await _properityRepo.GetByIdAsync(request.ProperityId);

            if (properity is not null)
            {
                ProperityDto properityDto = _mapper.Map<ProperityDto>(properity);

                return properityDto;
            }

            return null;
        }
    }
}
