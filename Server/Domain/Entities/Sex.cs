namespace Server.Domain.Entities
{
    public class Sex : Entity
    {
        public Sex(string description) {
            Description = description;
        }

        public string Description { get; set; }
    }
}