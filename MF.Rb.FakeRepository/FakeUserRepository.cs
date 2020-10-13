using MF.Rb.Domain;
using MF.Rb.Domain.Entity;
using MF.Rb.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MF.Rb.FakeRepository
{



    public class FakeEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : Base
    {
        private Collection<TEntity> entities;

        public IEnumerable<TEntity> Get()
        {
            return entities;
        }

        public TEntity Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }
    }


    public class FakeUserRepository : FakeEntityRepository<User>, IUserRepository
    {

    }
}
