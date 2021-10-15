using System.Linq;

using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Domain.Queries;
using Server.Infra.Data;

namespace Server.Infra.Repositories
{
    public class SexesRepository: ISexesRepository
    {
        private readonly DataContext _context;

        public SexesRepository(DataContext context)
        {
            _context = context;
        }

        public Sex GetById(int id)
        {
            return _context.Sexes
                .FirstOrDefault(SexQueries.GetById(id));
        }
    }
}