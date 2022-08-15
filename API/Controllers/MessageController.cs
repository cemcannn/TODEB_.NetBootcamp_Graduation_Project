using API.Configuration.Filters.Auth;
using Business.Abstract;
using DTO.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Common;
using Models.Entities;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;
        public MessageController(IMessageService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        [Permission(PermissionEnum.Admin)]
        public IActionResult GetAllMessage()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpGet("GetById")]
        [Permission(PermissionEnum.Admin)]
        public IActionResult GetMessageById(int id)
        {
            var data = _service.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        [Permission(PermissionEnum.User)]
        public IActionResult SendMessage(MessageSendRequest message)
        {
            var response = _service.SendMessage(message);
            return Ok(response);
        }

        [HttpDelete]
        [Permission(PermissionEnum.Admin)]
        public IActionResult DeleteMessage(Message message)
        {
            var response = _service.Delete(message);
            return Ok(response);
        }
    }
}
