using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HolidaysCalendar.Api.Resources;
using HolidaysCalendar.Api.Validators;
using HolidaysCalendar.Core.Models;
using HolidaysCalendar.Core.Services;

namespace HolidaysCalendar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        private readonly IMapper _mapper;
        
        public StatusController(IStatusService statusService, IMapper mapper)
        {
            this._mapper = mapper;
            this._statusService = statusService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<StatusResource>>> GetAllStatuses()
        {
            var statuses = await _statusService.GetAllStatuses();
            var statusResources = _mapper.Map<IEnumerable<Status>, IEnumerable<StatusResource>>(statuses);

            return Ok(statusResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusResource>> GetStatusById(int id)
        {
            var status = await _statusService.GetStatusById(id);
            var statusResource = _mapper.Map<Status, StatusResource>(status);

            return Ok(statusResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<StatusResource>> CreateStatus([FromBody] SaveStatusResource saveStatusResource)
        {
            var validator = new SaveStatusResourceValidator();
            var validationResult = await validator.ValidateAsync(saveStatusResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var statusToCreate = _mapper.Map<SaveStatusResource, Status>(saveStatusResource);

            var newStatus = await _statusService.CreateStatus(statusToCreate);

            var status = await _statusService.GetStatusById(newStatus.Id);

            var statusResource = _mapper.Map<Status, StatusResource>(status);

            return Ok(statusResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StatusResource>> UpdateStatus(int id, [FromBody] SaveStatusResource saveStatusResource)
        {
            var validator = new SaveStatusResourceValidator();
            var validationResult = await validator.ValidateAsync(saveStatusResource);
            
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var statusToBeUpdated = await _statusService.GetStatusById(id);

            if (statusToBeUpdated == null)
                return NotFound();

            var status = _mapper.Map<SaveStatusResource, Status>(saveStatusResource);

            await _statusService.UpdateStatus(statusToBeUpdated, status);

            var updatedStatus = await _statusService.GetStatusById(id);

            var updatedStatusResource = _mapper.Map<Status, StatusResource>(updatedStatus);

            return Ok(updatedStatusResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _statusService.GetStatusById(id);

            await _statusService.DeleteStatus(status);
            
            return NoContent();
        }
    }
}