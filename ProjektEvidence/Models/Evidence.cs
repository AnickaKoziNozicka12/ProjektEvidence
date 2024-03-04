namespace ProjektEvidence.Models
{
    public class Evidence
    {
        public List<Polozka> Polozky { get; set; } = new List<Polozka>();
        public Polozka Polozka { get; set; } = new Polozka();

        public string Vypis { get; set; } = "";

        public void Pridat()
        {
            //Polozky.Add(Polozka);
            //Polozka = new Polozka();

            Polozky.Add(new Polozka(datum: Polozka.Datum, vynosy: Polozka.Vynosy, naklady: Polozka.Naklady));
        }

        public void ZobrazPocetZaznamu()
        {
            Vypis = $"Počet záznamů je {Polozky.Count}";
        }

        public void ZobrazAll()
        {
            Vypis = $"Jednotlivé záznamy: <br>" + string.Join("<br>", Polozky);
        }
    }
}
