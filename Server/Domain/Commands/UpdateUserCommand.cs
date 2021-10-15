using System;
using Flunt.Notifications;
using Flunt.Validations;

using Server.Domain.Commands.Contracts;

namespace Server.Domain.Commands
{
    public class UpdateUserCommand : Notifiable<Notification>, ICommand
    {

        public UpdateUserCommand()
        {
        }

        public UpdateUserCommand(int id, string name, DateTime birth, string email, int sexId, string password, Boolean active)
        {
            Id = id;
            Name = name;
            Birth = birth;
            Email = email;
            SexId = sexId;
            Password = password;
            Active = active;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }
        public int SexId { get; set; }
        public string Password { get; set; }
        public Boolean Active { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<UpdateUserCommand>()
                    .Requires()
                    .IsGreaterThan(Id, 0, "Id")
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