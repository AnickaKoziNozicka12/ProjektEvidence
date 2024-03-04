namespace ProjektEvidence.Models
{
    public class Evidence
    {
        public List<Polozka> Polozky { get; set; } = new List<Polozka>();
        public Polozka Polozka { get; set; } = new Polozka();

        public void Pridat()
        {
            //Polozky.Add(Polozka);
            //Polozka = new Polozka();

            Polozky.Add(new Polozka(datum: Polozka.Datum, vynosy: Polozka.Vynosy, naklady: Polozka.Naklady));
        }
    }
}
