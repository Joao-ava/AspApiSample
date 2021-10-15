using System;
using Flunt.Notifications;
using Flunt.Validations;

using Server.Domain.Commands.Contracts;

namespace Server.Domain.Commands
{
    public class CreateUserCommand : Notifiable<Notification>, ICommand
    {

        public CreateUserCommand()
        {
        }

        public CreateUserCommand(string name, DateTime birth, string email, int sexId, string password)
        {
            Name = name;
            Birth = birth;
            Email = email;
            SexId = sexId;
            Password = password;
        }

        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }
        public int SexId { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            //  Nome, Data de Nascimento, E-mail e Sexo
            AddNotifications(
                new Contract<CreateUserCommand>()
                    .Requires()
                    .IsNotNullOrEmpty(Name, "Name")
                    .IsNotNull(Birth, "Birth")
                    .IsGreaterThan(Birth, DateTime.Now.AddYears(-100), "Birth")
                    .IsNotNullOrEmpty(Email, "Email")
                    .IsNotNull(SexId, "SexId")
                    .IsGreaterThan(SexId, 0, "SexId")
                    .IsEmail(Email, "Email")
                    .IsGreaterThan(Name, 3, "Name")
            );
        }
    }
}