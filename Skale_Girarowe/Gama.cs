using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;


namespace Skale_Gitarowe {

    // reprezentuje zestaw dzwiekow na gryfie przechowujac skale
    public partial class Gama {
        
        // lista dzwiekow
        public List<DzwiekNaGryfie> dzwieki { get; private set; }

        // dzwiek poczatkowy, do uzytku wewnetrznego
        private DzwiekNaGryfie _dzwiekBazowy;

        // nazwa skali, do uzytku wewnetrznego
        private Skala _skala;

        // informacje o skali
        public DaneSkali daneSkali { get; private set; }

        //  stroj, potrzebny do ustalenia pozycju dzwiekow na gryfie
        private Stroj _stroj;

        // s/g
        public Stroj stroj {
            get { return _stroj; }
            set {
                _stroj = value;
                GenerujGame();
            }
        }

        // s/g
        public DzwiekNaGryfie dzwiekBazowy {
            get { return _dzwiekBazowy; }
            set {
                _dzwiekBazowy = value;
                GenerujGame();
            }
        } // END public DzwiekNaGryfie dzwiekBazowy

        // s/g
        public Skala skala {
            get { return _skala; }
            set {
                _skala = value;
                GenerujGame();
            }
        } // END public Skala skala

        // tworzy game
        public void GenerujGame() {
            daneSkali = new DaneSkali(_skala, _dzwiekBazowy);

            dzwieki.Clear();
            dzwieki.Add(_dzwiekBazowy);
            Nazwa nazwa = _dzwiekBazowy.nazwa;

            Boolean wstecz = false;
            int pozycjaPocz = 0;
            if (_dzwiekBazowy.nazwa.litera != Litera.C) wstecz = true;

            int i = 0, stopien0 = 2;

            do {
                try {
                    nazwa += daneSkali.poltony[i++];
                    if ((wstecz) && (nazwa.cyfra < 1) && (nazwa.litera >= Litera.c)) 
                        dzwieki.Insert(pozycjaPocz, new DzwiekNaGryfie(nazwa - 12, stopien0, _stroj));
                    
                    dzwieki.Add(new DzwiekNaGryfie(nazwa, stopien0++, _stroj));
                    if (i >= daneSkali.poltony.Count) i = 0;
                    if (((daneSkali.poltony.Count > 1) && (stopien0 > daneSkali.poltony.Count)) || (stopien0 > 12)) stopien0 = 1;
                } catch { break; }
            } while (true);
        } // END public void GenerujGame

        // glowny kostruktor
        public Gama(Skala skala = Skala.chromatyczna, DzwiekNaGryfie dzwiekBazowy = null, Stroj stroj = null)  {
            dzwieki = new List<DzwiekNaGryfie>();
            _dzwiekBazowy = dzwiekBazowy ?? new DzwiekNaGryfie();
            _skala = skala;
            _stroj = stroj;
            GenerujGame();
        } // END public Gama

    } // END public class Gama

} // END namespace Skale_Gitarowe
