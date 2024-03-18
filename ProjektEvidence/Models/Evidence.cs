using Microsoft.JSInterop;
using System.Globalization;
using System.Xml.Serialization;

namespace ProjektEvidence.Models
{
    public class Evidence
    {
        public Evidence(IJSRuntime js)
        {
            JS = js;
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("cs-CZ");
        }
        private IJSRuntime JS { get; set; }

        public List<Polozka> Polozky { get; set; } = new List<Polozka>();
        public Polozka Polozka { get; set; } = new Polozka();

        public string Vypis { get; set; } = "";

        public bool IsEditace { get; set; } = false;

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

        public void Statistiky()
        {
            Vypis = "";
            Vypis += $"Minimum: {Minimum()}<br>";
            Vypis += $"Maximum: {Maximum()}<br>";
            Vypis += $"Průměr: {Prumer()}";
        }

        private double Maximum()
        {
            if (Polozky.Count == 0)
            {
                return double.NaN;
            }
            else
            {
                return Polozky.Max(x => x.Zisk);
            }
        }

        private double Minimum()
        {
            if (Polozky.Count == 0)
            {
                return double.NaN;
            }
            else
            {
                return Polozky.Min(x=>x.Zisk);
            }
        }
        private double Prumer()
        {
            if (Polozky.Count == 0)
            {
                return double.NaN;
            }
            else
            {
                return Polozky.Average(x => x.Zisk);
            }
        }

        public async Task SmazatZaznamAsync(Models.Polozka polozka)
        {
            //JavaScript.InvokeVoidAsync("alert", "Hlaska"); //zavorky: prvni je fce z JS a pak funkce
            var zprava = $"Chcete odebrat {polozka.Datum} - Zisk {polozka.Zisk}?";

            if (await JS.InvokeAsync<bool>("confirm", zprava))
            {
                Polozky.Remove(polozka);
            }
        }

        public void Edituj(Models.Polozka polozka)
        {
            Polozka = polozka;

            IsEditace = true;
        }

        public void UkonciEditaci()
        {
            IsEditace = false;
            Polozka = new Polozka();
        }
    }
}
