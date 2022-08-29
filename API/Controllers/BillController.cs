using API.Configuration.Filters.Auth;
using Business.Abstract;
using DTO.Bill;
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
    public class BillController : ControllerBase
    {
        private readonly IBillService _service;
        public BillController(IBillService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
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
        
        [HttpGet("GetBillWithProperty")]
        public IActionResult GetBillWithProperty(int id)
        {
            var data = _service.GetBillWithProperty(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Insert(BillInsertRequest bill)
        {
            var response = _service.Insert(bill);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(BillUpdateRequest bill)
        {
            var response = _service.Update(bill);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Bill bill)
        {
            var response = _service.Delete(bill);
            return Ok(response);
        }
    }
}
