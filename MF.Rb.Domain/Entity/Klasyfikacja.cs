namespace MF.Rb.Domain
{
    public struct Klasyfikacja
    {
        public string Dzial { get; set; }
        public string Rozdzial { get; set; }
        public string Paragraf { get; set; }

        public Klasyfikacja(string dzial, string rozdzial, string paragraf)
        {
            this.Dzial = dzial;
            this.Rozdzial = rozdzial;
            this.Paragraf = paragraf;
        }
    }

}
