using System.Collections.Generic;
using System.Threading.Tasks;
using HolidaysCalendar.Core.Models;
using HolidaysCalendar.Core.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HolidaysCalendar.Api.Resources;
using HolidaysCalendar.Api.Validators;

namespace HolidaysCalendar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;
        public RequestsController(IRequestService requestService, IMapper mapper)
        {
            this._requestService = requestService;
            this._mapper = mapper;
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<RequestResource>>> GetAllRequests()
        {
            var requests = await _requestService.GetAllRequests();
            var requestResources = _mapper.Map<IEnumerable<Request>, IEnumerable<RequestResource>>(requests);

            return Ok(requestResources);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestResource>> GetRequestById(int id)
        {
            var request = await _requestService.GetRequestById(id);
            var requestResource = _mapper.Map<Request, RequestResource>(request);

            return Ok(requestResource);
        }
        [HttpPost("")]
        public async Task<ActionResult<RequestResource>> CreateRequest([FromBody] SaveRequestResource saveRequestResource)
        {
            var validator = new SaveRequestResourceValidator();
            var validationResult = await validator.ValidateAsync(saveRequestResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var requestToCreate = _mapper.Map<SaveRequestResource, Request>(saveRequestResource);

            var newRequest = await _requestService.CreateRequest(requestToCreate);

            var request = await _requestService.GetRequestById(newRequest.Id);

            var requestResource = _mapper.Map<Request, RequestResource>(request);

            return Ok(requestResource);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<RequestResource>> UpdateRequest(int id, [FromBody] SaveRequestResource saveRequestResource)
        {
            var validator = new SaveRequestResourceValidator();
            var validationResult = await validator.ValidateAsync(saveRequestResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var requestToBeUpdate = await _requestService.GetRequestById(id);

            if (requestToBeUpdate == null)
                return NotFound();

            var request = _mapper.Map<SaveRequestResource, Request>(saveRequestResource);

            await _requestService.UpdateRequest(requestToBeUpdate, request);

            var updatedRequest = await _requestService.GetRequestById(id);
            var updatedRequestResource = _mapper.Map<Request, RequestResource>(updatedRequest);

            return Ok(updatedRequestResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            if (id == 0)
                return BadRequest();

            var request = await _requestService.GetRequestById(id);

            if (request == null)
                return NotFound();

            await _requestService.DeleteRequest(request);

            return NoContent();
        }
    }
}