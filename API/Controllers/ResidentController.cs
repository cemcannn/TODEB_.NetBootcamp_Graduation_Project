using API.Configuration.Filters.Auth;
using Business.Abstract;
using DTO.Resident;
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
    public class ResidentController : ControllerBase
    {
        private readonly IResidentService _service;
        public ResidentController(IResidentService service)
        {
            _service = service;
        }

        [HttpGet]
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

        [HttpPost]
        public IActionResult Insert(ResidentInsertRequest resident)
        {
            var response = _service.Insert(resident);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(ResidentUpdateRequest resident)
        {
            var response = _service.Update(resident);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Resident resident)
        {
            var response = _service.Delete(resident);
            return Ok(response);
        }
    }
}
