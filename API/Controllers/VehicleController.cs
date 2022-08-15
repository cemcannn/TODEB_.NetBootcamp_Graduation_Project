using API.Configuration.Filters.Auth;
using Business.Abstract;
using DTO.Vehicle;
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
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _service;
        public VehicleController(IVehicleService service)
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
        public IActionResult Insert(VehicleInsertRequest vehicle)
        {
            var response = _service.Insert(vehicle);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(VehicleUpdateRequest vehicle)
        {
            var response = _service.Update(vehicle);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Vehicle vehicle)
        {
            var response = _service.Delete(vehicle);
            return Ok(response);
        }
    }
}
