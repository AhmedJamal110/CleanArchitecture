using Application.Features.Images.Commands;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
  
    public class ImagesController : BaseController
    {
        private readonly ISender _mediaterSender;

        public ImagesController(ISender MediaterSender)
        {
            _mediaterSender = MediaterSender;
        }

        [HttpPost("add")]
        public async Task<ActionResult> CreateNewImage(NewImage newImage)
        {
           var IsSuccess =  await _mediaterSender.Send(new CreateNewImageRequest(newImage));
            if (IsSuccess)
                return Ok("Create New Image Succesfully");

            return BadRequest("Failed to Create New Image");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateImage(UpdateNewImage updateNewImage)
        {
          var IsSuccess = await _mediaterSender.Send(new UpdateNewImageRequest(updateNewImage));
            if (IsSuccess)
                return Ok("Update Image SuccessFully");

            return NotFound("image dont found");
        }
    
    }
}
