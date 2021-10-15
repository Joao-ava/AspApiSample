using System;
using System.Linq.Expressions;
using Server.Domain.Entities;

namespace Server.Domain.Queries
{
    public static class SexQueries
    {
        public static Expression<Func<Sex, bool>> GetById(int id)
        {
            return sex => sex.Id == id;
        }
    }
}