using System;

namespace Server.Domain.Entities
{
    public class Entity: IEquatable<Entity>
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}