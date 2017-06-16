using System;
using System.Collections.Generic;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skale_Gitarowe {

    // klasa abstrakcyjna bedaca baza dla dzwiekow roznych rodzajow
    public abstract class Dzwiek : ICloneable {

        // nazwa dzwieku
        public Nazwa nazwa { get; protected set; }

        // czestotliwosc drgan dzwieku
        public Double czestotliwosc {
            get;
            protected set;
        } // END  public Double czestotliwosc

        // setter nazwa, różna implementacja ze względu na ilosc dzwieków (atrybut adresy)
        public abstract void SetNazwa(Nazwa nazwa); 

        // funkcja obliczajaca przesuniecie dzwiekow od poczatkowgo C0
        public static int GetPrzesuniecie(Nazwa nazwa) { return  (int) nazwa.litera + (nazwa.cyfra * 12); }

        // funkcja obliczajaca czestotliwosc drgan dzwieku
        public static Double LiczCzestotliwosc(int przesuniecie) { return Math.Round(65.406391 * Math.Pow(2, (1d / 12d) * przesuniecie), 1); }

        // umozliwia kopiowanie dzwieku
        public object Clone() { return this.MemberwiseClone(); }

    } // END public abstract class Dzwiek

    // klasa reprezentujaca dzwiek, ktory ma swoje miejsce na gryfie
    public class DzwiekNaGryfie : Dzwiek {

        // lista adresow polozenia dzwieku na gryfia
        public List<Point> adres { get; private set; }

        // stroj, ktory jest potrzebny do przesuniec w obliczaniu polozenia
        protected Stroj stroj;

        // okresla nr dzwieku wedlug skali
        public int stopienSkali { get; protected set; }

        // setter nazwa obliczajacy polozenia dzwieku na gryfia 
        public override void SetNazwa(Nazwa nazwa) {
            adres.Clear();
            this.nazwa = nazwa;
            int przesuniecie = GetPrzesuniecie(nazwa);
            this.czestotliwosc = LiczCzestotliwosc(przesuniecie);

            // od dzwieku najnizszego w gore
            for (int i = 5; i >= 0; i--) {
                if (przesuniecie < 22) adres.Add(new Point(przesuniecie, i));
                if (i > 0) przesuniecie -= Dzwiek.GetPrzesuniecie(stroj[i - 1].nazwa) - Dzwiek.GetPrzesuniecie(stroj[i].nazwa);
                else przesuniecie = 4;
                if (przesuniecie < 0) break;
            } // END for

        } // END override public void SetNazwa()

        // przyslonieta ToString zwracajaca wszystkie adresy punktow
        public override String ToString() {
            String str = "";
            for (int i = 0; i < adres.Count; i++)
                str = String.Concat(str, adres[i].ToString());
            return str;
        } // END public override String ToString

        // kostruktor glowny
        public DzwiekNaGryfie(Nazwa nazwa = null, int stopienSkali = 1, Stroj stroj = null) {
            adres = new List<Point>();
            this.stroj = stroj ?? new Stroj();
            this.stopienSkali = stopienSkali;
            SetNazwa(nazwa ?? new Nazwa(Litera.C));
        } // END  DzwiekNaGryfie

    } // END public class DzwiekNaGryfie : Dzwiek

    // klasa reprezentujaca dziwk, ktory reprezentuje stroj gitary
    public class DzwiekStroju : Dzwiek {

        // przesuniecie dzwieku wzgledem dzwieku podstawowego
        public int posX { get; private set; }

        // polozenie y dzwieku liczac od dzwieku najwyzszego
        private int nrStruny;

        // tekst wyjatku, gdy nastapi przekroczenie zakresu
        private const String EXCEPTION_OUT = "Klasa: DzwiekStroju, cyfra indeksu struny poza zakresem!";

        // przysloniety setter obliczajacy polozenie x dzwieku stroju
        public override void SetNazwa(Nazwa nazwa) {
            this.nazwa = nazwa;
            int temp = 0;
            switch (nrStruny) {
                case 5: temp = GetPrzesuniecie(new Nazwa(Litera.C)); break;
                case 4: temp = GetPrzesuniecie(new Nazwa(Litera.F)); break;
                case 3: temp = GetPrzesuniecie(new Nazwa(Litera.Ais)); break;
                case 2: temp = GetPrzesuniecie(new Nazwa(Litera.dis)); break;
                case 1: temp = GetPrzesuniecie(new Nazwa(Litera.g)); break;
                case 0: temp = GetPrzesuniecie(new Nazwa(Litera.c, 1)); break;
            } // END switch (nrStruny)

            posX = GetPrzesuniecie(nazwa) - temp;
            this.czestotliwosc = LiczCzestotliwosc(posX);
            
        } // END public override void SetNazwa(Nazwa nazwa)

        // glowny kostruktor
        public DzwiekStroju(int nrStruny, Nazwa nazwa = null) {
            if (nrStruny > 5) throw new ArgumentOutOfRangeException(EXCEPTION_OUT);
            this.nrStruny = nrStruny;
            SetNazwa(nazwa ?? new Nazwa(Litera.C));
        } // END public DzwiekStroju(int nrStruny, Nazwa nazwa = null)

    } // END public class DzwiekStroju : Dzwiek

} // END namespace Skale_Gitarowe
