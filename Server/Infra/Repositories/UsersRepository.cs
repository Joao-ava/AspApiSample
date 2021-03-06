using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using Server.Domain.Entities;
using Server.Domain.Queries;
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

        public IEnumerable<User> GetAll(string name, bool? active)
        {
            return _context.Users
                .Include(x => x.Sex)
                .Where(UserQueries.GetAll(name, active));
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(UserQueries.GetById(id));
        }

        public void Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }
    }
}