using System.Collections.Generic;
using Server.Domain.Entities;

namespace Server.Domain.Repositories
{
    public interface IUsersRepository
    {
        void Create(User user);
        IEnumerable<User> GetAll(string name, bool? active);
        User GetById(int id);
        void Update(User user);
        void Delete(User user);
    }
}