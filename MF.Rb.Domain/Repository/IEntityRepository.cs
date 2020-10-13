using System.Collections.Generic;

namespace MF.Rb.Domain.Repository
{
    // Interfejs generyczny
    public interface IEntityRepository<TEntity>
        where TEntity : Base
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
    }
}
