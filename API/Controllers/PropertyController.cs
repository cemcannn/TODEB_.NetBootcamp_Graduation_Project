using API.Configuration.Filters.Auth;
using Business.Abstract;
using DTO.Property;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Common;
using Models.Entities;

namespace API.Controllers
{
    [Authorize]
    [Permission(PermissionEnum.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _service;
        public PropertyController(IPropertyService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var data = _service.GetById(id);
            return Ok(data);
        }

        [HttpGet("GetUser")]
        public IActionResult GetProperty(int id)
        {
            var data = _service.GetProperty(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Insert(PropertyInsertRequest property)
        {
            var response = _service.Insert(property);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(PropertyUpdateRequest property)
        {
            var response = _service.Update(property);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Property property)
        {
            var response = _service.Delete(property);
            return Ok(response);
        }
    }
}
