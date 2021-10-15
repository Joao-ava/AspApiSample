using Flunt.Notifications;
using Server.Domain.Commands;
using Server.Domain.Commands.Contracts;
using Server.Domain.Entities;
using Server.Domain.Handlers.Contracts;
using Server.Domain.Repositories;

namespace Server.Domain.Handlers
{
    public class UserHandler :
        Notifiable<Notification>,
        IHandler<CreateUserCommand>
    {
        private readonly IUsersRepository _userRepository;
        private readonly ISexesRepository _sexRepository;

        public UserHandler(
            IUsersRepository userRepository,
            ISexesRepository sexRepository)
        {
            _userRepository = userRepository;
            _sexRepository = sexRepository;
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, parece que não foi possivel criar um usuario!", command.Notifications);

            Sex sex = _sexRepository.GetById(command.SexId);
            User user = new User(command.Name, command.Birth, command.Email, command.SexId, command.Password);
            _userRepository.Create(user);
            return new GenericCommandResult(true, "Usuário salvo", user);
        }
    }
}