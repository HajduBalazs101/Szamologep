using System.Windows;
using System.Windows.Controls;

namespace Szamologep
{
    public partial class MainWindow : Window
    {
        double elozoSzam = 0;
        string muvelet = "";
        bool ujSzam = true;

        public MainWindow()
        {
            InitializeComponent();
            GombokLetrehozasa();
        }

        private void GombokLetrehozasa()
        {
            // 1. sor
            StackPanel sor1 = UjSor();
            GombHozzaadas(sor1, "7", "szam");
            GombHozzaadas(sor1, "8", "szam");
            GombHozzaadas(sor1, "9", "szam");
            GombHozzaadas(sor1, "/", "muvelet");

            // 2. sor
            StackPanel sor2 = UjSor();
            GombHozzaadas(sor2, "4", "szam");
            GombHozzaadas(sor2, "5", "szam");
            GombHozzaadas(sor2, "6", "szam");
            GombHozzaadas(sor2, "*", "muvelet");

            // 3. sor
            StackPanel sor3 = UjSor();
            GombHozzaadas(sor3, "1", "szam");
            GombHozzaadas(sor3, "2", "szam");
            GombHozzaadas(sor3, "3", "szam");
            GombHozzaadas(sor3, "-", "muvelet");

            // 4. sor
            StackPanel sor4 = UjSor();
            GombHozzaadas(sor4, "C", "torles");
            GombHozzaadas(sor4, "0", "szam");
            GombHozzaadas(sor4, "=", "egyenlo");
            GombHozzaadas(sor4, "+", "muvelet");
        }

        private StackPanel UjSor()
        {
            StackPanel sor = new StackPanel();
            sor.Orientation = Orientation.Horizontal;
            sor.HorizontalAlignment = HorizontalAlignment.Center;
            GombokHelye.Children.Add(sor);
            return sor;
        }

        private void GombHozzaadas(StackPanel sor, string ertek, string tipus)
        {
            Gomb gomb = new Gomb(ertek, tipus);
            gomb.Click += Gomb_Kattintas;
            sor.Children.Add(gomb);
        }

        private void Gomb_Kattintas(object sender, RoutedEventArgs e)
        {
            Gomb gomb = (Gomb)sender;

            if (gomb.Tipus == "szam")
            {
                Kijelzo.Text = gomb.Formazottertek(Kijelzo.Text, ujSzam);
                ujSzam = false;
            }
            else if (gomb.Tipus == "muvelet")
            {
                elozoSzam = double.Parse(Kijelzo.Text);
                muvelet = gomb.Ertek;
                ujSzam = true;
            }
            else if (gomb.Tipus == "egyenlo")
            {
                double masodikSzam = double.Parse(Kijelzo.Text);
                double eredmeny = 0;

                if (muvelet == "+") eredmeny = elozoSzam + masodikSzam;
                if (muvelet == "-") eredmeny = elozoSzam - masodikSzam;
                if (muvelet == "*") eredmeny = elozoSzam * masodikSzam;
                if (muvelet == "/") eredmeny = elozoSzam / masodikSzam;

                Kijelzo.Text = eredmeny.ToString();
                ujSzam = true;
            }
            else if (gomb.Tipus == "torles")
            {
                Kijelzo.Text = "0";
                elozoSzam = 0;
                muvelet = "";
                ujSzam = true;
            }
        }
    }
}