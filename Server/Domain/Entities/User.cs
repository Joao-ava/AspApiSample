using System;

namespace Server.Domain.Entities
{
    public class User : Entity
    {
        public User(string name, DateTime birth, string email, int sexId, string password)
        {
            Name = name;
            Birth = birth;
            Email = email;
            SexId = sexId;
            Password = password;
            Active = true;
        }

        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }
        public int SexId { get; set; }
        public Sex Sex { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}