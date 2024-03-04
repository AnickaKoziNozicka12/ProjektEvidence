namespace ProjektEvidence.Models
{
    public class Polozka
    {
        //je to construktor, musi se jmenovat stejne jako trida
        public Polozka()
        {
            Datum = DateOnly.FromDateTime(DateTime.Now);
        }

        public Polozka(DateOnly datum, double vynosy, double naklady)
        {
            Datum = datum;
            Vynosy = vynosy;
            Naklady = naklady;
        }

        //v poli v C# nejde menit velikost. Proto vyuzijeme seznam (pomoci tridy jako objekt)
        public DateOnly Datum { get; set; }
        private double vynosy;

        public double Vynosy
        {
            get { return vynosy; }
            set
            { 
                if (vynosy != value)
                {
                    if (value < 0)
                    {
                        vynosy = 0;
                    }
                    else
                    {
                        vynosy = value;
                    }
                }
            }
        }
        private double naklady;

        public double Naklady
        {
            get { return naklady; }
            set
            {
                if (naklady != value)
                {
                    if (value < 0)
                    {
                        naklady = Math.Abs(value);
                    }
                    else
                    {
                        naklady = value;
                    }
                }
            }
        }
        public double Zisk => Vynosy - Naklady;

    }
}
