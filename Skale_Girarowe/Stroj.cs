using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Skale_Gitarowe {

    // reprezentuje stroj gitary
    public class Stroj {

        // lista 6 dzwiekow stroju
        private DzwiekStroju[] struny;

        // przesuniecia pomiedzy poszczegolnymi strunami
        public int[] przesuniecie { get; private set; }

        // tekst wyjatku przeepelnienia
        private const String EXCEPTION_OUT= "Klasa: Stroj, cyfra indeksu struny poza zakresem!";

        // g/s odniesienia tablicowego 
        public DzwiekStroju this[int index] {
            private set {
                if ((index > 5) || (index < 0)) throw new ArgumentOutOfRangeException(EXCEPTION_OUT);
                struny[index] = value;

            }
            get {
                if ((index > 5) || (index < 0)) throw new ArgumentOutOfRangeException(EXCEPTION_OUT);
                return struny[index];
            }
        } // END public DzwiekStroju this

        // funkcja zmieniajaca stroj danej struny
        public void StrojStrune(int nrStruny, Nazwa nazwa) {
            struny[nrStruny] = new DzwiekStroju(nrStruny, nazwa);
            for (int i = nrStruny - 1 ; i >= 0; i--) struny[i] = new DzwiekStroju(i, struny[i].nazwa);
            LiczPrzesuniecie();
        } // END public void StrojStrune


        // funkcja generujaca przesuniecie
        private void LiczPrzesuniecie() {
            for (int i = 5; i >= 1; i--) przesuniecie[i] = Dzwiek.GetPrzesuniecie(struny[i - 1].nazwa) - Dzwiek.GetPrzesuniecie(struny[i].nazwa) - 1;
            przesuniecie[0] = 4;
        } // END private void LiczPrzesuniecie

        // glowny konstruktor
        public Stroj() {
            przesuniecie = new int[6];
            struny = new DzwiekStroju[6];
            struny[5] = new DzwiekStroju(5, new Nazwa(Litera.E));
            struny[4] = new DzwiekStroju(4, new Nazwa(Litera.A));
            struny[3] = new DzwiekStroju(3, new Nazwa(Litera.d));
            struny[2] = new DzwiekStroju(2, new Nazwa(Litera.g));
            struny[1] = new DzwiekStroju(1, new Nazwa(Litera.h));
            struny[0] = new DzwiekStroju(0, new Nazwa(Litera.e, 1));
            LiczPrzesuniecie();
        } // END public Stroj

    } // END public class Stroj

} // END namespace Skale_Gitarowe
