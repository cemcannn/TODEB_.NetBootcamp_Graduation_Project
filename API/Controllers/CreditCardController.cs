using API.Configuration.Filters.Auth;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Common;
using Models.Document;
using MongoDB.Bson;

namespace API.Controllers
{
    [Authorize]
    [Permission(PermissionEnum.Admin | PermissionEnum.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _service;

        public CreditCardController(ICreditCardService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(CreditCard creditCard)
        {
            _service.Add(creditCard);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(CreditCard creditCard)
        {
            _service.Update(creditCard);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(ObjectId id)
        {
            _service.Delete(id);
            return Ok();
        }

        [HttpGet("GetById")]
        public CreditCard Get(string id)
        {
            return _service.Get(new ObjectId(id));
        }
    }
}
