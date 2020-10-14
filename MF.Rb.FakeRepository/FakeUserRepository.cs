using MF.Rb.Domain.Entity;
using MF.Rb.Domain.Repository;
using System;
using System.Linq;
using System.Text;

namespace MF.Rb.FakeRepository
{


    public class FakeUserRepository : FakeEntityRepository<User>, IUserRepository
    {
        public FakeUserRepository()
        {
            entities.Add(new User(1, "John", "Smith", "john.smith@domain.com"));
            entities.Add(new User(2, "Ann", "Smith", "ann.smith@domain.com"));
            entities.Add(new User(3, "Marcin", "Sulecki", "marcin.sulecki@sulmar.pl"));
        }

        public void Add(User user)
        {
            // Linq (oparty o wyrażenia lambda)
            int lastId = entities.Max(u => u.Id);

            // inkrementacja
            lastId++;

            // przypisanie
            user.Id = lastId;

            // dodanie pbiektu do zbioru
            entities.Add(user);
        }
    }
}
