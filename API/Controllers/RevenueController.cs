using API.Configuration.Filters.Auth;
using Business.Abstract;
using DTO.Revenue;
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
    public class RevenueController : ControllerBase
    {
        private readonly IRevenueService _service;
        public RevenueController(IRevenueService service)
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

        [HttpPost]
        public IActionResult Insert(RevenueInsertRequest revenue)
        {
            var response = _service.Insert(revenue);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(RevenueUpdateRequest revenue)
        {
            var response = _service.Update(revenue);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Revenue revenue)
        {
            var response = _service.Delete(revenue);
            return Ok(response);
        }
    }
}
