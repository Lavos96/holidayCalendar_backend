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
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService;
        private readonly IMapper _mapper;
        
        public TypeController(ITypeService typeService, IMapper mapper)
        {
            this._mapper = mapper;
            this._typeService = typeService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<TypeResource>>> GetAllTypes()
        {
            var types = await _typeService.GetAllTypes();
            var typeResources = _mapper.Map<IEnumerable<Type>, IEnumerable<TypeResource>>(types);

            return Ok(typeResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TypeResource>> GetTypeById(int id)
        {
            var type = await _typeService.GetTypeById(id);
            var typeResource = _mapper.Map<Type, TypeResource>(type);

            return Ok(typeResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<TypeResource>> CreateType([FromBody] SaveTypeResource saveTypeResource)
        {
            var validator = new SaveTypeResourceValidator();
            var validationResult = await validator.ValidateAsync(saveTypeResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var typeToCreate = _mapper.Map<SaveTypeResource, Type>(saveTypeResource);

            var newType = await _typeService.CreateType(typeToCreate);

            var type = await _typeService.GetTypeById(newType.Id);

            var typeResource = _mapper.Map<Type, TypeResource>(type);

            return Ok(typeResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StatusResource>> UpdateType(int id, [FromBody] SaveTypeResource saveTypeResource)
        {
            var validator = new SaveTypeResourceValidator();
            var validationResult = await validator.ValidateAsync(saveTypeResource);
            
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var typeToBeUpdated = await _typeService.GetTypeById(id);

            if (typeToBeUpdated == null)
                return NotFound();

            var type = _mapper.Map<SaveTypeResource, Type>(saveTypeResource);

            await _typeService.UpdateType(typeToBeUpdated, type);

            var updatedType = await _typeService.GetTypeById(id);

            var updatedTypeResource = _mapper.Map<Type, TypeResource>(updatedType);

            return Ok(updatedTypeResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var type = await _typeService.GetTypeById(id);

            await _typeService.DeleteType(type);
            
            return NoContent();
        }
    }
}