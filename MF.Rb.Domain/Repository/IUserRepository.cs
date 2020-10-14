using MF.Rb.Domain.Entity;
using System.Collections.Generic;

namespace MF.Rb.Domain.Repository
{
    //public interface IUserRepository : IEntityRepository<User>
    //{

    //}

    public interface IUserRepository
    {
        IEnumerable<User> Get();
        User Get(int id);
        void Add(User user);
    }
}
