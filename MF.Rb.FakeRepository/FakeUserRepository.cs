using MF.Rb.Domain.Entity;
using MF.Rb.Domain.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Rb.FakeRepository
{

    // Standardowa obsług opcji konfiguracyjnych
    // odbywa się za pomocą wstrzykiwania obiektu poprzez konstruktor z użyciem interfejsu IOptions<T>

    // 1. Tworzymy klasę, która reprezentuje opcje
    // 2. Przekazujemy tą klasę poprzez konstruktor i intefejs IOptions<T> 
    // 3. Rejestrujemy w klasie Startup services.Configure<FakeUserRepositoryOptions>(Configuration.GetSection("FakeUserRepositoryOptions"));

    public class FakeUserRepositoryOptions
    {
        public int Qty { get; set; }
        public string Domain { get; set; }
    }

    public class FakeUserRepository : FakeEntityRepository<User>, IUserRepository
    {
        // Dodaj pakiet Microsoft.Extensions.Options
        public FakeUserRepository(IOptions<FakeUserRepositoryOptions> options)
        {
            //entities.Add(new User(1, "John", "Smith", "john.smith@domain.com"));
            //entities.Add(new User(2, "Ann", "Smith", "ann.smith@domain.com"));
            //entities.Add(new User(3, "Marcin", "Sulecki", "marcin.sulecki@sulmar.pl"));

            for (int i = 0; i < options.Value.Qty; i++)
            {
                entities.Add(new User(i, "John", "Smith", $"john.smith@{options.Value.Domain}"));

            }
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

        public Task<IEnumerable<User>> GetAsync()
        {
            return Task.Run(() => Get());
        }
    }
}
