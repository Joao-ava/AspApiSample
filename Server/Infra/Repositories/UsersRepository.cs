using System.Linq;

using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infra.Data;

namespace Server.Infra.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        private readonly DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}