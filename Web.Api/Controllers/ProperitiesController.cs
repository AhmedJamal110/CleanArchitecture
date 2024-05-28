using Application.Features.Properities.Commands;
using Application.Features.Properities.Queries;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{

    public class ProperitiesController : BaseController
    {
        private readonly ISender _mediaterSender;

        public ProperitiesController(ISender mediaterSender)
        {
            _mediaterSender = mediaterSender;
        }


        [HttpPost("add")]
        public async Task<ActionResult> AddNewProperity(NewProperityRequest newProperityRequest)
        {
           var IsSeccess =  await _mediaterSender.Send(new CreateProperityRequest(newProperityRequest));
            if (IsSeccess)
                return Ok("Porperity Created Successfully");

            return BadRequest("Faild To Create Properity");
        
        }


        [HttpPut("update")]
        public async Task<ActionResult> UpdateProperity(UpdatePorperity updatePorperity)
        {
            var IsSuccess =  await _mediaterSender.Send(new UpdateProperirtyRequest(updatePorperity));
            if (IsSuccess)
                return Ok("properity Updated SuccessFully");

            return NotFound("Properity Not Found");


        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ProperityDto>> GetProperityById(int id)
        {

            var properityDto =  await _mediaterSender.Send(new GetProperitybyIdRequest(id));

            if (properityDto is not null)
            {
                return Ok(properityDto);
            }

            return NotFound("Properity Not Found");
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProperityDto>>> GetAllPropperities()
        {
            var properitiesDto = await _mediaterSender.Send(new GetAllProperityRequest());

            if (properitiesDto is not null)
                return Ok(properitiesDto);

            return NotFound("Not Found Properities");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProperity(int id)
        {
            var IsSuccess = await _mediaterSender.Send(new DeleteProperityRequest(id));

            if (IsSuccess)
            {
                return Ok("Properity Deleted Successfully");
            }

            return NotFound("Properity Not Found");
        }
    
    }
}
