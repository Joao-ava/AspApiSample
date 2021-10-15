using System;
using Flunt.Notifications;
using Flunt.Validations;

using Server.Domain.Commands.Contracts;

namespace Server.Domain.Commands
{
    public class DeleteUserCommand : Notifiable<Notification>, ICommand
    {

        public DeleteUserCommand()
        {
        }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<UpdateUserCommand>()
                    .Requires()
                    .IsGreaterThan(Id, 0, "Id")
            );
        }
    }
}