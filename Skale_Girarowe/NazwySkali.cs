using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skale_Gitarowe {

    public class DaneSkali {
        public List<UInt16> interwaly;
        public String opis;
        public Rodzaj Rodzaj;
        private Skala nazwa;

        public void SetNazwa(Skala nazwa) {
            this.nazwa = nazwa;
            interwaly.Clear();
            switch (nazwa) {
                case Skala.brak: {
                        interwaly.Add(1);
                        opis = "wszystkie dzwieki";
                        Rodzaj = Rodzaj.inna;
                    } break;
                case Skala.durowa: {
                        // c
                        interwaly.Add(2); // d
                        interwaly.Add(2); // e
                        interwaly.Add(1); // f
                        interwaly.Add(2); // g
                        interwaly.Add(2); // a
                        interwaly.Add(2); // b
                        interwaly.Add(1); // c
                        opis = "naturalna";
                        Rodzaj = Rodzaj.durowa;
                    } break;
                case Skala.dorycka: {
                        // c
                        interwaly.Add(2); // d
                        interwaly.Add(1); // dis
                        interwaly.Add(2); // f
                        interwaly.Add(2); // g
                        interwaly.Add(2); // a
                        interwaly.Add(1); // ais
                        interwaly.Add(2); // c
                        opis = "podstawowa skala mollowa w jazzie";
                        Rodzaj = Rodzaj.molowa;
                    } break;
                case Skala.frygijska: {
                        // c
                        interwaly.Add(1); // cis
                        interwaly.Add(2); // dis
                        interwaly.Add(2); // f
                        interwaly.Add(2); // g
                        interwaly.Add(1); // gis
                        interwaly.Add(2); // ais
                        interwaly.Add(2); // c
                        opis = "mroczne brzmienie, dobra do metalu";
                        Rodzaj = Rodzaj.molowa;
                    } break;
                case Skala.lidyjska: {
                        // c
                        interwaly.Add(2); // d
                        interwaly.Add(2); // e
                        interwaly.Add(2); // fis
                        interwaly.Add(1); // g
                        interwaly.Add(2); // a
                        interwaly.Add(2); // b
                        interwaly.Add(1); // c
                        opis = "podstawowa skala do ogrywania akordów durowych (maj7) w jazzie i fusion";
                        Rodzaj = Rodzaj.durowa;
                    } break;
                case Skala.miksolidyjska: {
                        // c
                        interwaly.Add(2); // d
                        interwaly.Add(2); // e
                        interwaly.Add(1); // f
                        interwaly.Add(2); // g
                        interwaly.Add(2); // a
                        interwaly.Add(1); // ais
                        interwaly.Add(2); // c
                        opis = "";
                        Rodzaj = Rodzaj.inna;
                    } break;
                case Skala.eolska: {
                        // c
                        interwaly.Add(2); // d
                        interwaly.Add(1); // dis
                        interwaly.Add(2); // f
                        interwaly.Add(2); // g
                        interwaly.Add(1); // gis
                        interwaly.Add(2); // b
                        interwaly.Add(2); // c
                        opis = "naturalna";
                        Rodzaj = Rodzaj.molowa;
                    } break;
                case Skala.lokrycka: {
                        // c
                        interwaly.Add(1); // cis
                        interwaly.Add(2); // dis
                        interwaly.Add(2); // f
                        interwaly.Add(1); // fis
                        interwaly.Add(2); // gis
                        interwaly.Add(2); // b
                        interwaly.Add(2); // c
                        opis = "naturalna";
                        Rodzaj = Rodzaj.inna;
                    } break;
            }
        }
        public Skala GetNazwa() { return nazwa; }

        public DaneSkali() { interwaly = new List<UInt16>(); }
        public DaneSkali(Skala nazwa) : this() { SetNazwa(nazwa); }
    } // END public partial class Gama

} // END namespace Skale_Gitarowe
