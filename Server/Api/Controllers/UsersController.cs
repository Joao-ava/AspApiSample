using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Server.Domain.Commands;
using Server.Domain.Entities;
using Server.Domain.Handlers;
using Server.Domain.Repositories;

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

        [Route("")]
        [HttpGet]
        public IEnumerable<User> GetAll(
            [FromServices]IUsersRepository repository,
            [FromQuery]string name="",
            [FromQuery]bool? active=null
        )
        {
            return repository.GetAll(name, active);
        }
    }
}