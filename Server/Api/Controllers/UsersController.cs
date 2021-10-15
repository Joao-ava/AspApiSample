using Microsoft.AspNetCore.Mvc;
using Server.Domain.Commands;
using Server.Domain.Handlers;

namespace Server.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromServices]UserHandler handler,
            [FromBody]CreateUserCommand input
        )
        {
            return (GenericCommandResult) handler.Handle(input);
        }
    }
}