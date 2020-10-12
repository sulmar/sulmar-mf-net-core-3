using System;
using System.Collections.ObjectModel;
using System.Linq;
using MF.Rb.Domain;
using MF.Rb.Domain.Repository;
using System.Collections.Generic;

namespace MF.Rb.FakeRepository
{
    public class FakeReportRepository : IReportRepository
    {
        private Collection<Report> reports;

        public IEnumerable<Report> Get(int dysponentId)
        {
            // => wyrażenie lambda
            return reports
                .Where(p => p.Dysponent.Id == dysponentId)
                .ToList();

            // Linq - korzysta z wyrażeń lambda i tłumaczy na inny język:
            // obiekty w pamięci - Linq To Object -> foreach
            // obiekty z bazy danych (Entity Framework) - Linq to Entites -> SQL

            // imperatywny
            Collection<Report> results = new Collection<Report>();

            foreach(Report report in reports)
            {
                if (report.Dysponent.Id == dysponentId)
                {
                    results.Add(report);
                }
            }

            // deklaratywny
            // SQL: SELECT * FROM Reports WHERE dysponentId = @dysponentId

            return results;
        }

        public IEnumerable<Report> Get(DateTime from, DateTime to)
        {
           return reports
                .Where(r => r.CreateDate >= from)
                .Where(r => r.CreateDate <= to)
                .ToList();
        }
    }
}
