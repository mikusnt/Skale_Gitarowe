using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Skale_Gitarowe {

    // litery dzwiekow
    public enum Litera { zero = -1, C = 0, Cis, D, Dis, E, F, Fis, G, Gis, A, Ais, H, c, cis, d, dis, e, f, fis, g, gis, a, ais, h };

    // nazwy skali
    public enum Skala { chromatyczna = 0, jońska, dorycka, frygijska, lidyjska, miksolidyjska, eolska, lokrycka,
        harmoniczna_mollowa, lokrycka_13, jońska_zwiększona, dorycka_11, frygijska_dominantowa, lidyjska_9, harmoniczna_zmniejszona,
        melodyczna_mollowa, dorycka_b9, lidyjska_zwiększona, lidyjska_dominantowa, miksolidyjska_b13, lokrycka_9, alterowana,
        bopowa_durowa, bopowa_dominantowa, bopowa_molowa
    };

    public static class SkalaR {

        public static String ToCustomString(this Skala skala) {
            switch (skala) {
                case Skala.dorycka_11: return "dorycka #11"; break;
                case Skala.lidyjska_9: return "lidyjska #9"; break;
                default: return skala.ToString().Replace('_', ' '); break;
            }  
        }
    }

    // rodzaje skali
    public enum Rodzaj { dominantowa = 0, durowa, durowa_zwiększona, inna, mollowa, mollowa_toniczna, półzmniejszona, półzmniejszona_dominantowa, zmniejszona };

    // grupy skali
    public enum Grupa { bopowe = 0, durowe, egzotyczne, inne, mollowe_harmoniczne, mollowe_melodyczne, pentatoniki, symetryczne };

} // END namespace Skale_Gitarowe
