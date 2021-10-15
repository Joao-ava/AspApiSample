using Server.Domain.Entities;

namespace Server.Domain.Repositories
{
    public interface ISexesRepository
    {
        Sex GetById(int id);
    }
}