using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Skale_Gitarowe {

    // przechowuje informacje o skalach gitarowych
    public class DaneSkali {

        // lista odstepow pomiedzy dzwiekami
        public List<UInt16> poltony { private set; get; }

        // tekst zawierajacy nazwy interwalow
        public String interwaly { private set; get; }

        // tekst zawierajacy krotki opis skali
        public String opis { private set; get; }

        // typ skali
        public Rodzaj rodzaj { private set; get; }

        // tekst zawierajacy liste dzwiekow od dzwieku bazowego
        public String dzwieki { private set; get; }

        //Grupa, do ktorej nalezy skala
        public Grupa grupa { private set; get; }

        // nazwa skali
        private Skala _skala;

        // podstawowy dzwiek
        private DzwiekNaGryfie _dzwiekBazowy;
        
        // s/g
        public Skala skala {
            get { return _skala; }
            set {
                _skala = value;
                GenerujInfo();
            }
        } // END public Skala skala

        // s/g
        public DzwiekNaGryfie dzwiekBazowy {
            get { return _dzwiekBazowy; }
            set {
                _dzwiekBazowy = value;
                GenerujInfo();
            }
        } // END public DzwiekNaGryfie dzwiekBazow

        // tworzy kompletnych danych skali
        private void GenerujInfo() {

            // generowanie opisu, interwalow
            poltony.Clear();
            switch (_skala) {
                case Skala.chromatyczna: {
                        poltony.Add(1);
                        interwaly = "";
                        opis = "wszystkie dźwięki";
                        rodzaj = Rodzaj.inna;
                        grupa = Grupa.inne;
                    }
                    break;
                case Skala.jońska: {
                        // c
                        poltony.Add(2); // d
                        poltony.Add(2); // e
                        poltony.Add(1); // f
                        poltony.Add(2); // g
                        poltony.Add(2); // a
                        poltony.Add(2); // b
                        poltony.Add(1); // c
                        interwaly = "1  2  3  4  5  6  7";
                        opis = "naturalna";
                        rodzaj = Rodzaj.durowa;
                        grupa = Grupa.durowe;
                    }
                    break;
                case Skala.dorycka: {
                        // c
                        poltony.Add(2); // d
                        poltony.Add(1); // dis
                        poltony.Add(2); // f
                        poltony.Add(2); // g
                        poltony.Add(2); // a
                        poltony.Add(1); // ais
                        poltony.Add(2); // c
                        interwaly = "1  2  b3 4  5  6  b7";
                        opis = "podstawowa skala mollowa w jazzie";
                        rodzaj = Rodzaj.mollowa;
                        grupa = Grupa.durowe;
                    }
                    break;
                case Skala.frygijska: {
                        // c
                        poltony.Add(1); // cis
                        poltony.Add(2); // dis
                        poltony.Add(2); // f
                        poltony.Add(2); // g
                        poltony.Add(1); // gis
                        poltony.Add(2); // ais
                        poltony.Add(2); // c
                        interwaly = "1  b2 b3 4  5  b6 7";
                        opis = "mroczne brzmienie, dobra do metalu";
                        rodzaj = Rodzaj.mollowa;
                        grupa = Grupa.durowe;
                    }
                    break;
                case Skala.lidyjska: {
                        // c
                        poltony.Add(2); // d
                        poltony.Add(2); // e
                        poltony.Add(2); // fis
                        poltony.Add(1); // g
                        poltony.Add(2); // a
                        poltony.Add(2); // b
                        poltony.Add(1); // c
                        interwaly = "1  2  3  #4 5  6  7";
                        opis = "podstawowa skala do ogrywania akordów durowych (maj7) w jazzie i fusion";
                        rodzaj = Rodzaj.durowa;
                        grupa = Grupa.durowe;
                    }
                    break;
                case Skala.miksolidyjska: {
                        // c
                        poltony.Add(2); // d
                        poltony.Add(2); // e
                        poltony.Add(1); // f
                        poltony.Add(2); // g
                        poltony.Add(2); // a
                        poltony.Add(1); // ais
                        poltony.Add(2); // c
                        interwaly = "1  2  3  4  5  6  b7";
                        opis = "";
                        rodzaj = Rodzaj.dominantowa;
                        grupa = Grupa.durowe;
                    }
                    break;
                case Skala.eolska: {
                        // c
                        poltony.Add(2); // d
                        poltony.Add(1); // dis
                        poltony.Add(2); // f
                        poltony.Add(2); // g
                        poltony.Add(1); // gis
                        poltony.Add(2); // b
                        poltony.Add(2); // c
                        interwaly = "1  2  b3 4  5  b6 b7";
                        opis = "naturalna";
                        rodzaj = Rodzaj.mollowa;
                        grupa = Grupa.durowe;
                    }
                    break;
                case Skala.lokrycka: {
                        // c
                        poltony.Add(1); // cis
                        poltony.Add(2); // dis
                        poltony.Add(2); // f
                        poltony.Add(1); // fis
                        poltony.Add(2); // gis
                        poltony.Add(2); // b
                        poltony.Add(2); // c
                        interwaly = "1  b2 b3 4  b5 b6 7";
                        opis = "rzadko używana, lekko orientalne/mroczne brzmienie";
                        rodzaj = Rodzaj.półzmniejszona;
                        grupa = Grupa.durowe;
                    }
                    break;
                case Skala.harmoniczna_mollowa: {
                        // c
                        poltony.Add(2); 
                        poltony.Add(1); 
                        poltony.Add(2); 
                        poltony.Add(2);
                        poltony.Add(1); 
                        poltony.Add(3); 
                        poltony.Add(1); 
                        interwaly = "1  2  b3 4  5  b6 7";
                        opis = "dobra do akordów molowych tonicznych – Xm(maj7)";
                        rodzaj = Rodzaj.mollowa_toniczna;
                        grupa = Grupa.mollowe_harmoniczne;
                    }
                    break;
                case Skala.lokrycka_13: {
                        // c
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(3);
                        poltony.Add(1);
                        poltony.Add(2);
                        interwaly = "1  b2 b3 4  b5 6  b7";
                        opis = "";
                        rodzaj = Rodzaj.półzmniejszona;
                        grupa = Grupa.mollowe_harmoniczne;
                    }
                    break;
                case Skala.jońska_zwiększona: {
                        // c
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(3);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(1);
                        interwaly = "1  2  3  4  #5 6  7";
                        opis = "dobra do akordów Xaug(maj7) i do zwyklych durowych (wprowadza napięcie)";
                        rodzaj = Rodzaj.półzmniejszona;
                        grupa = Grupa.mollowe_harmoniczne;
                    }
                    break;
                case Skala.dorycka_11: {
                        // c
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(3);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        interwaly = "1  2  b3 #4 5  6  b7";
                        opis = "dobra do bluesa";
                        rodzaj = Rodzaj.mollowa;
                        grupa = Grupa.mollowe_harmoniczne;
                    }
                    break;
                case Skala.frygijska_dominantowa: {
                        // c
                        poltony.Add(1);
                        poltony.Add(3);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(2);
                        interwaly = "1  b2 3  4  5  b6 b7";
                        opis = "do akordów X7b9, arabskie brzmienie";
                        rodzaj = Rodzaj.dominantowa;
                        grupa = Grupa.mollowe_harmoniczne;
                    }
                    break;
                case Skala.lidyjska_9: {
                        // c
                        poltony.Add(3);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(1);
                        interwaly = "1  #2 3  #4 5  6  7";
                        opis = "charakterystyczne brzmienie, wprowadza dużo koloru (napiecia)";
                        rodzaj = Rodzaj.durowa;
                        grupa = Grupa.mollowe_harmoniczne;
                    }
                    break;
                case Skala.harmoniczna_zmniejszona: {
                        // c
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(3);
                        interwaly = "1  b2 3  4  5  b6 b7";
                        opis = "";
                        rodzaj = Rodzaj.zmniejszona;
                        grupa = Grupa.mollowe_harmoniczne;
                    }
                    break;
                case Skala.melodyczna_mollowa: {
                        // c
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(1);
                        interwaly = "1  2  b3 4  5  6  7";
                        opis = "dobra do akordów molowych tonicznych – Xm(maj7)";
                        rodzaj = Rodzaj.mollowa_toniczna;
                        grupa = Grupa.mollowe_melodyczne;
                    }
                    break;
                case Skala.dorycka_b9: {
                        // c
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        interwaly = "1  b2 b3 4  5  6  b7";
                        opis = "frygijska 13";
                        rodzaj = Rodzaj.mollowa;
                        grupa = Grupa.mollowe_melodyczne;
                    }
                    break;
                case Skala.lidyjska_zwiększona: {
                        // c
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(1);
                        interwaly = "1  2  3  #4 #5 6  7";
                        opis = "do akordów Xaug(maj7), dobrze też koloruje (wprowadza napięcie) zwykłe durowe";
                        rodzaj = Rodzaj.durowa_zwiększona;
                        grupa = Grupa.mollowe_melodyczne;
                    }
                    break;
                case Skala.lidyjska_dominantowa: {
                        // c
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        interwaly = "1  2  3  #4 5  6  b7";
                        opis = "";
                        rodzaj = Rodzaj.dominantowa;
                        grupa = Grupa.mollowe_melodyczne;
                    }
                    break;
                case Skala.miksolidyjska_b13: {
                        // c
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(2);
                        interwaly = "1  2  3  4  5  b6 b7";
                        opis = "góralska";
                        rodzaj = Rodzaj.dominantowa;
                        grupa = Grupa.mollowe_melodyczne;
                    }
                    break;
                case Skala.lokrycka_9: {
                        // c
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(2);
                        interwaly = "1  2  b3 4  b5 b6 b7";
                        opis = "eolska b5";
                        rodzaj = Rodzaj.półzmniejszona;
                        grupa = Grupa.mollowe_melodyczne;
                    }
                    break;
                case Skala.alterowana: {
                        // c
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(2);
                        interwaly = "1  b2 b3 b4 b5 b6 b7";
                        opis = "ma w sobie wszystkie alteracje akordu dominantowego";
                        rodzaj = Rodzaj.półzmniejszona_dominantowa;
                        grupa = Grupa.mollowe_melodyczne;
                    }
                    break;
                case Skala.bopowa_durowa: {
                        // c
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(1);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(1);
                        interwaly = "1  2  3  4  #4 5  6  7";
                        opis = "";
                        rodzaj = Rodzaj.durowa;
                        grupa = Grupa.bopowe;
                    }
                    break;
                case Skala.bopowa_dominantowa: {
                        // c
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(1);
                        poltony.Add(1);
                        interwaly = "1  2  3  4  5  6  b7 7";
                        opis = "uzywajac nieeksponować D#";
                        rodzaj = Rodzaj.dominantowa;
                        grupa = Grupa.bopowe;
                    }
                    break;
                case Skala.bopowa_molowa: {
                        // c
                        poltony.Add(1);
                        poltony.Add(1);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(2);
                        poltony.Add(1);
                        poltony.Add(2);
                        poltony.Add(2);
                        interwaly = "1  b2 2  b3 4  5  b6 b7";
                        opis = "dobra też do metalu";
                        rodzaj = Rodzaj.mollowa;
                        grupa = Grupa.bopowe;
                    }
                    break;
            } // END switch (_skala)

            // generowanie listy dźwięków
            dzwieki = "";
            if (_skala != Skala.chromatyczna) {
                DzwiekNaGryfie kopia = new DzwiekNaGryfie(_dzwiekBazowy.nazwa);
                String temp;
                for (int i = 0; i < poltony.Count; i++) {
                    temp = kopia.nazwa.ToString();
                    if (temp.Length == 1) temp += "   ";
                    else temp += " ";
                    dzwieki = String.Concat(dzwieki, temp);
                    kopia = new DzwiekNaGryfie(new Nazwa(kopia.nazwa.litera + poltony[i]));
                } 
            }
        } // END private void GenerujInfo()

        // podstawowy kostruktor
        public DaneSkali(Skala skala = Skala.chromatyczna, DzwiekNaGryfie dzwiekBazowy = null) {
            poltony = new List<UInt16>();
            _skala = skala;
            _dzwiekBazowy = dzwiekBazowy?? new DzwiekNaGryfie();
            GenerujInfo();
        } // END  public DaneSkali

    } // END public partial class Gama

} // END namespace Skale_Gitarowe
