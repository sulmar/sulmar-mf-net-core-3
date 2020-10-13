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


        // snippet: ctor
        public FakeReportRepository()
        {
            reports = new Collection<Report>();

            Customer dysponent = new Customer(1, "FirmaA", "A", "65675767434");
            Report report1 = new Report(dysponent);

            Klasyfikacja klasyfikacja1 = new Klasyfikacja("010", "01095", "0750");
            Klasyfikacja klasyfikacja2 = new Klasyfikacja("010", "01095", "2010");
            Klasyfikacja klasyfikacja3 = new Klasyfikacja("010", "01095", "3865");

            ReportDetail reportDetail1 = new ReportDetail(klasyfikacja1, 0, 427);
            ReportDetail reportDetail2 = new ReportDetail(klasyfikacja2, 30, 999);
            ReportDetail reportDetail3 = new ReportDetail(klasyfikacja3, 670, 1007);

            report1.Details.Add(reportDetail1);
            report1.Details.Add(reportDetail2);
            report1.Details.Add(reportDetail3);

            reports.Add(report1);

        }

        public IEnumerable<Report> Get(int dysponentId)
        {
            // => wyrażenie lambda
            return reports
                .Where(report => report.Dysponent.Id == dysponentId)
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

        public void Add(Report report)
        {
            int lastId = reports.Max(r => r.Id);
            report.Id = ++lastId;

            reports.Add(report);
        }
        public Report GetById(int reportId)
        {
            return reports.SingleOrDefault(r => r.Id == reportId);
        }

        public void Update(Report report)
        {
            Remove(report.Id);
            Add(report);
        }

        public void Remove(int reportId)
        {
            Report report = GetById(reportId);
            reports.Remove(report);
        }
    }
}
