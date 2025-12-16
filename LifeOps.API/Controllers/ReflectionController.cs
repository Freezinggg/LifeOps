using LifeOps.Application.Common;
using LifeOps.Application.DTO;
using LifeOps.Application.Interface;
using LifeOps.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LifeOps.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReflectionController : ControllerBase
    {
        public readonly IReflectionService _service;
        public ReflectionController(IReflectionService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var result = _service.GetById(id);
                return result.IsSuccess ? Ok(ApiResponse<ReflectionDTO?>.Ok(result.Data)) : NotFound(ApiResponse<ReflectionDTO?>.Fail(result.ErrorMessage));
            }
            catch
            {
                return StatusCode(500, ApiResponse<object>.Fail("Get reflection error, internal server problem."));
            }
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _service.GetAll();
                return Ok(ApiResponse<IReadOnlyList<ReflectionDTO>>.Ok(result.Data));
            }
            catch
            {
                return StatusCode(500, ApiResponse<object>.Fail("Get reflection error, internal server problem."));
            }
            
        }

        [HttpPost]
        public IActionResult Save([FromBody] CreateReflectionDTO dto)
        {
            try
            {
                var result = _service.Save(dto);
                return result.IsSuccess ? CreatedAtAction(nameof(Get), new { id = result.Data }, ApiResponse<Guid>.Ok(result.Data)) : BadRequest(ApiResponse<Guid>.Fail(result.ErrorMessage));
            }
            catch
            {
                return StatusCode(500, ApiResponse<object>.Fail("Save reflection error, internal server problem."));
            }
        }
    }
}
