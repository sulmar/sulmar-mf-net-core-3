using MF.Rb.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MF.Rb.Domain.Repository
{
    //public interface IUserRepository : IEntityRepository<User>
    //{

    //}

    public interface IUserRepository
    {
        IEnumerable<User> Get();
        Task<IEnumerable<User>> GetAsync();

        User Get(int id);
        void Add(User user);
    }


    // interfejs z metodami asynchronicznymi
    // wzorzec: Task<T> MetodaAsync()

    public interface IUserRepositoryAsync
    {
        Task<IEnumerable<User>> GetAsync();
        Task<User> GetAsync(int id);
        Task AddAsync(User user);
    }
}
