using System;
using System.Collections.ObjectModel;

namespace MF.Rb.Domain
{

    public class Report : Base
    {
        public Customer Dysponent { get; set; }
        public Collection<ReportDetail> Details { get; set; }
        public DateTime CreateDate { get; set; }

    }

}
