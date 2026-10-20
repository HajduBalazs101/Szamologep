using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Szamologep
{
    public class Gomb : Button
    {
        public string Ertek { get; set; }
        public string Tipus { get; set; }

        public Gomb(string ertek, string tipus)
        {
            this.Ertek = ertek;
            this.Tipus = tipus;
            this.Content = ertek;

            this.FontSize = 20;
            this.Width = 50;
            this.Height = 40;
            this.Margin = new Thickness(2);

            if (tipus == "torles") this.Background = Brushes.LightCoral;
            else if (tipus == "egyenlo") this.Background = Brushes.LightGreen;
            else if (tipus == "muvelet") this.Background = Brushes.LightSkyBlue;
            else this.Background = Brushes.LightGray;
        }

        public string Formazottertek(string jelenlegiText, bool ujSzam)
        {
           if (ujSzam)
            {
                return this.Ertek;
            }

            string nyersSzoveg = jelenlegiText + this.Ertek;

            if (double.TryParse(nyersSzoveg, out double szam))
            {
                return szam.ToString();
            }
            return jelenlegiText;
        }
    }
}