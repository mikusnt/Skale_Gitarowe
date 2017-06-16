using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Skale_Gitarowe {

    // reprezentuje nazwe dzwieku
    public class Nazwa {

        // stala maksymalnej cyfry dzwieku
        private const UInt16 MAX_CYFRA = 2;

        // tekst wyjatku
        private const String EXCEPTION_OUT = "Klasa: Nazwa, cyfra nazwy dźwięku poza zakresem!";

        // litera dzwieku
        public Litera litera { get; set; }

        // cyfra dzwieku
        private int _cyfra;

        // s/g
        public int cyfra {
            get { return _cyfra; }
            set {
                SprawdzPrzepelnienie(value);
                _cyfra = value;
            }
        } // END public UInt16 cyfra

        // sprawdza przepelnienie
        private static void SprawdzPrzepelnienie(int liczba) { if (liczba > MAX_CYFRA) throw new ArgumentOutOfRangeException(EXCEPTION_OUT); }

        // przeciazenie +
        public static Nazwa operator +(Nazwa baza, UInt16 przesuniecie) {
            Litera litera = baza.litera;
            int cyfra = baza.cyfra;
            litera += przesuniecie;
            while (litera > Litera.h) { litera -= (int)12; cyfra++; }
            SprawdzPrzepelnienie(cyfra);
            return new Nazwa(litera, cyfra);
        } // END public static Nazwa operator +

        // przeciazenie -
        public static Nazwa operator -(Nazwa baza, UInt16 przesuniecie) {
            Litera litera = baza.litera;
            int cyfra = baza.cyfra;
            litera -= przesuniecie;
            while (litera > Litera.h) { litera += (int)12; cyfra--; }
            SprawdzPrzepelnienie(cyfra);
            return new Nazwa(litera, cyfra);
        } // END public static Nazwa operator +

        // przeciazenie ==
        public static bool operator ==(Nazwa nL, Nazwa nR) { return ((nL.cyfra == nR.cyfra) && (nL.litera == nR.litera)); }

        //przeciazenie !=
        public static bool operator !=(Nazwa nL, Nazwa nR) { return !((nL.cyfra == nL.cyfra) && (nL.litera == nL.litera)); }

        // przysloniete Equals, konieczne gdy przeciazony ==
        public override bool Equals(Object obj) {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return (this == ((Nazwa)obj));
        } // END public override bool Equals

        // przysloniete GetHashCode, konieczne gdy przeciazony ==
        public override int GetHashCode() { return ((int)litera) ^ cyfra; }

        // konstruktor glowny
        public Nazwa(Litera litera = Litera.C, int tcyfra = 0) {
            cyfra = tcyfra;
            this.litera = litera;
        } // END public Nazwa()

        // konstruktor wykorzystujacy nazwe
        public Nazwa(String text) {
            foreach (Litera i in Enum.GetValues(typeof(Litera))) { if (text.IndexOf(i.ToString(), 0) != -1) litera = i; }
            //cyfra = int.Parse();
            int temp;
            int.TryParse(text.Remove(0, text.Length - 1), out temp);
            cyfra = temp;
        } // END public Nazwa

        // przyslonieta ToString zwracajaca nazwe dzwieku z opcjonalna cyfra
        public override String ToString() {
            if (cyfra > 0)
                return litera.ToString() + _cyfra.ToString();
            else return litera.ToString();
        }
    }; // END public struct Nazwa
}
