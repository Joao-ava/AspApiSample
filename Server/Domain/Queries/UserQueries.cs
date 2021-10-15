using System;
using System.Linq.Expressions;
using Server.Domain.Entities;

namespace Server.Domain.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> GetAll(string name, bool? active)
        {
            return user => (name == "" || user.Name.Contains(name)) && (active == null || user.Active == active);
        }
    }
}