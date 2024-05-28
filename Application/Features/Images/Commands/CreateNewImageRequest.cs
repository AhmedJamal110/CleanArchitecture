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

namespace Application.Features.Images.Commands
{
    public class CreateNewImageRequest : IRequest<bool>
    {
        public NewImage  newImage { get; set; }
        public CreateNewImageRequest(NewImage image)
        {
            newImage = image;
        }

    }


    public class CreateNewImageRequestHandler : IRequestHandler<CreateNewImageRequest, bool>
    {
        private readonly IImageRepo _imageRepo;
        private readonly IMapper _mapper;

        public CreateNewImageRequestHandler(IImageRepo imageRepo , IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateNewImageRequest request, CancellationToken cancellationToken)
        {

            Image image = _mapper.Map<Image>(request.newImage);

             await _imageRepo.AddImageAsync(image);
           
            return true;

        }
    }
}
