namespace ProjektEvidence.Models
{
    public class Polozka
    {
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
        public double Zisk => Vynosy - Naklady;

    }
}
