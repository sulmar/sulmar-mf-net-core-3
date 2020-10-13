namespace MF.Rb.Domain
{
    public class ReportDetail : Base
    {
        public Klasyfikacja Klasyfikacja { get; set; }
        public decimal Plan { get; set; }
        public decimal Naleznosci { get; set; }

        public ReportDetail(Klasyfikacja klasyfikacja, decimal plan, decimal naleznosci)
        {
            this.Klasyfikacja = klasyfikacja;
            this.Plan = plan;
            this.Naleznosci = naleznosci;
        }
    }

}
