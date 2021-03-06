﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MF.Rb.Domain.Repository
{
    public interface IReportRepository
    {
        IEnumerable<Report> Get(int dysponentId);
        IEnumerable<Report> Get(DateTime from, DateTime to);
        Report GetById(int reportId);
        void Add(Report report);
        void Update(Report report);
        void Remove(int reportId);

    }
}
