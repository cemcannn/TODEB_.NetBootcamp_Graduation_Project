using API.Configuration.Filters.Auth;
using Business.Abstract;
using DTO.User;
using Microsoft.AspNetCore.Mvc;
using Models.Common;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        public IActionResult Register(UserRegisterRequest register)
        {
            var response = _service.Register(register);
            return Ok(response);
        }

        [HttpGet("GetAll")]
        [Permission(PermissionEnum.Admin)]
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
    }
}
