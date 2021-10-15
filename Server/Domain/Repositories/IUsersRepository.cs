using Server.Domain.Entities;

namespace Server.Domain.Repositories
{
    public interface IUsersRepository
    {
        void Create(User user);
    }
}