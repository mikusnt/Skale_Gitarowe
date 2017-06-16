using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Skale_Gitarowe {

    // glowny obiekt, kompletne informacje
    public class Gitara {

        // przechowuje stroj
        private Stroj _stroj;

        // przechowuje pozycje na gryfie
        private int _pozycja;

        // przechowuje game
        private Gama _gama;

        // przechowuje reprezentacje graficzna dzwiekow na gryfie
        public List<DzwiekGraficzny> dzwieki { get; set; }

        // przechowuje polozenie na gryfie
       // private PozycjaNaGryfie pozycjaStrun;

        // odniesienie do formy glownej
        private Form1 forma;

        // obrazy potrzebne do wyswietlania dzwiekow graficznych
        private Image kropka = Image.FromFile(@"images\kropka.png");
        private Image kropkaBazowa = Image.FromFile(@"images\kropkaBazowa.png");
        private Image kropkaZaznaczona = Image.FromFile(@"images\kropkaZaznaczona.png");

        // aktualnie wybrany dzwiek
        private Nazwa zaznaczonyDzwiek;

        // s/g
        public int pozycja {
            get { return _pozycja + 1; }
            set {
                _pozycja = value - 1;
                //pozycjaStrun.poczatek = _pozycja;
                RysujDzwieki();
            }
        } // END public int pozycja

        // s/g
        public Stroj stroj {
            get { return _stroj; }
            set {
                _stroj = value;
                _gama.stroj = value;
                //pozycjaStrun.stroj = value;
                RysujDzwieki();
            }
        } // END public Stroj stroj

        // s/g
        public Gama gama {
            get { return _gama; }
            set {
                _gama = value;
                _gama.stroj = _stroj;
                RysujDzwieki();
            }
        } // END public Gama gama

        // resetuje nazwe zaznaczonego dzwieku do podstawowego
        public void ResetujzaznaczonyDzwiek() { zaznaczonyDzwiek = new Nazwa(Litera.zero); }

        public void RysujDzwieki() {
            //Console.WriteLine("a");
            for (int i = 0; i < dzwieki.Count; i++) dzwieki[i].Czysc();
            dzwieki.Clear();
            for (int i = 0; i < _gama.dzwieki.Count; i++) {
                dzwieki.Add(new DzwiekGraficzny(forma, this, kropka, kropkaBazowa, kropkaZaznaczona, _gama.dzwieki[i], _stroj, zaznaczonyDzwiek, _pozycja));
            }
        } // END public void RysujDzwieki()

        // konstruktor glowny
        public Gitara(Form1 forma, int nPozycja = 0) {
            dzwieki = new List<DzwiekGraficzny>();
            ResetujzaznaczonyDzwiek();
            this.forma = forma;
            _pozycja = nPozycja - 1;
            _stroj = new Stroj();
            _gama = new Gama();
            RysujDzwieki();
        } // END Gitara

    } // END class Gitara

} // END namespace Skale_Gitarowe
