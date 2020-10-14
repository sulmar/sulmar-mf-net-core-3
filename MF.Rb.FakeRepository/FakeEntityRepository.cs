using MF.Rb.Domain;
using MF.Rb.Domain.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MF.Rb.FakeRepository
{
    public class FakeEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : Base
    {
        protected Collection<TEntity> entities;

        public FakeEntityRepository()
        {
            entities = new Collection<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return entities;
        }

        public TEntity Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }
    }
}
