using System.Collections.Generic;
using Server.Domain.Entities;

namespace Server.Domain.Repositories
{
    public interface IUsersRepository
    {
        void Create(User user);
        IEnumerable<User> GetAll(string name, bool? active);
    }
}