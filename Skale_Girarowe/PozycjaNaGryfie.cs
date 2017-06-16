using System;
using System.Collections.Generic;
using System.Text;

namespace Skale_Gitarowe {

    // zawiera minimalne i maksymalne polozenie dla poszczegolnych strun
    public class PozycjaNaGryfie {
        // potrzebny do wyznaczenia koncowej pozycji
        private Stroj _stroj;

        // okresla pocatkowa pozycje
        private int _poczatek;

        // okresla koncowa pozycje
        public int[] koniec { get; private set; }

        // g/s
        public Stroj stroj {
            get { return _stroj; }
            set {
                stroj = value;
                MaxPozycja();
            }
        } // END  public Stroj stroj

        // g/s
        public int poczatek {
            get { return _poczatek; }
            set {
                _poczatek = value;
                MaxPozycja();
            }
        } // END public int poczatek

        // zwraca tablice maksymalnej pozycji na gryfie, liczac od aktualnej
        private void MaxPozycja() {
            for (int i = 5; i >= 1; i--) koniec[i] = Dzwiek.GetPrzesuniecie(_stroj[i - 1].nazwa) - Dzwiek.GetPrzesuniecie(_stroj[i].nazwa) - 1;
            koniec[0] = 4;
            //Console.WriteLine(koniec[5].ToString());
        } 

        // glowny konstruktor
        public PozycjaNaGryfie(Stroj stroj = null, int pozycja = 1) {
            koniec = new int[6];
            _stroj = stroj ?? new Stroj();
            poczatek = pozycja;
            MaxPozycja();
        }
    }
}
