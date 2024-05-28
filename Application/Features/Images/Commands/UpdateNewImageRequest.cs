using Application.Models;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Commands
{
    public class UpdateNewImageRequest :IRequest<bool>
    {

        public UpdateNewImage updateNewImage { get; set; }
       // public int ImageId { get; set; }

        public UpdateNewImageRequest(UpdateNewImage updatenewImage)
        {
            updateNewImage = updatenewImage; 
        }

    }


    public class UpdateNewImageRequestHandler : IRequestHandler<UpdateNewImageRequest, bool>
    {
        private readonly IImageRepo _imageRepo;
        private readonly IMapper _mapper;

        public UpdateNewImageRequestHandler(IImageRepo imageRepo, IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateNewImageRequest request, CancellationToken cancellationToken)
        {

            var imageInDb = await _imageRepo.GetImageByIdAsync(request.updateNewImage.Id);

            if(imageInDb is not null)
            {
                imageInDb.Name = request.updateNewImage.Name;
                imageInDb.Path = request.updateNewImage.Path;
                   await _imageRepo.UpdateImageAsync(imageInDb);

                return true;
            }

            return false;
        }
    }
}
