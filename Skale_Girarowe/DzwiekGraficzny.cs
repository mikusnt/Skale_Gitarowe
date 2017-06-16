using System;
using System.Collections.Generic;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skale_Gitarowe {

    // reprezentacja graficzna dzwiekow na gryfie
    public class DzwiekGraficzny : DzwiekNaGryfie {

        // poczatkowe wspolrzedne xy
        private readonly Point poczatek = new Point(96, 30);

        // zmiana wspolrzednych xy na zmiane polozenia
        private readonly Point dxy = new Point(41, 27);

        // czcionka nazw dzwiekow
        private readonly Font czcionka = new Font("Arial", 7, FontStyle.Bold);

        // kolor nazw dzwiekow
        private readonly SolidBrush kolor = new SolidBrush(Color.Black);

        // rozmiar w px obrazu dzwiekow
        private readonly Size rozmiar = new Size(23, 23);

        // min, dzieki niej klasa ustala jakie dzwieki maja byc wyswietlane
        private int pozycjaPocz;

        // lista obiektow z obrazami
        private List<PictureBox> obraz;

        // odniesienie do formy glownej
        private Form1 forma;

        // odniesienie do obiektu wywolujacego
        private Gitara gitara;

        // obrazy potrzebne do wyswietlanie dzwiekow
        private Image kropka;
        private Image kropkaBazowa;
        private Image kropkaZaznaczona;

        // aktualnie zaznaczony dzwiek, wszystkie obiekty klasy powinny miec ta sama referencje
        private Nazwa zaznaczonyDzwiek;

        // przesuniecie dla opisu dzwiekow w px
        private int dfont = 0;

        // sprawdza czy nazwa obiektu jest rowna zaznaczonyDzwiek
        private Boolean SprawdzNazwe(DzwiekGraficzny obiekt) { return (String.Compare(obiekt.nazwa.ToString(), zaznaczonyDzwiek.ToString()) == 0); }

        // ustawia obraz dla listy PictureBoxow
        private void SetImage(Boolean czyZaznaczone) {
            if (czyZaznaczone) 
                foreach (PictureBox i in obraz) i.Image = kropkaZaznaczona;    
            else 
            foreach (PictureBox i in obraz) {
                if (base.stopienSkali == 1)
                    i.Image = kropkaBazowa;
                else i.Image = kropka;
            }
        } // END private void SetImage

        // ZDARZENIA

        // wypisuje tekst do grafiki obiektu, akcja PictureBox
        private void nowyPaint(object sender, PaintEventArgs e) {
            e.Graphics.DrawString(base.nazwa.ToString(), czcionka, new SolidBrush(Color.White), new Point(dfont, 5));
        } // END private void nowyPaint 

        // podmienia obrazek obiektu, akcja PictureBox
        private void nowyClick(object sender, EventArgs e) {
            forma.pomiarCzasu.Start(forma.TEST_CZASU);
            List<DzwiekGraficzny> tempdz = gitara.dzwieki.FindAll(SprawdzNazwe);
            foreach (DzwiekGraficzny i in tempdz) { i.SetImage(false); }

            Nazwa temp = new Nazwa(((PictureBox)sender).Name);
            zaznaczonyDzwiek.cyfra = temp.cyfra;
            zaznaczonyDzwiek.litera = temp.litera;

            SetImage(true);
            forma.TolabelInfo(base.nazwa.ToString(), base.czestotliwosc.ToString(), base.stopienSkali.ToString());

            forma.pomiarCzasu.StopToConsole(forma.TEST_CZASU);
            
        } // END private void nowyClick

        // glowna funkcja generujaca obraz
        private void GenerujObraz() {
            obraz.Clear();
            int dx = 0;

            for (int i = base.adres.Count - 1; i >= 0; i--) {

                // warunki gry caly gryf
                if (((base.adres[i].X >= stroj[base.adres[i].Y].posX) 
                        && (base.adres[i].X <= stroj[base.adres[i].Y].posX + 12) 
                        && (pozycjaPocz == -1))
                    // warunki gdy okreslona pozycja
                    || ((base.adres[i].X >= (stroj[base.adres[i].Y].posX + pozycjaPocz)) 
                        && (base.adres[i].X <= (stroj[base.adres[i].Y].posX + pozycjaPocz + stroj.przesuniecie[base.adres[i].Y])) 
                        && (pozycjaPocz != -1)
                        //&& ((base.adres[i].Y != 1) || (base.adres[i].X <= (stroj[base.adres[i].Y].posX + pozycjaStrun.poczatek + 4)))
                        )) {
                    //&& (((base.adres[i].Y != 1) || (pozycjaStrun.koniec[base.adres[i].Y] <= 4)))) {

                    //if ((base.adres[i].Y == 1) && (base.adres[i].X > (stroj[base.adres[i].Y].posX + pozycjaStrun.poczatek + 4))) continue;

                    if ((pozycjaPocz < 1) && ((base.adres[i].X - stroj[base.adres[i].Y].posX) == 0)) dx = -10;
                    else dx = 0;
                    obraz.Add(new PictureBox());

                    dfont = 8 - (base.nazwa.ToString().Length * 2);

                    //obraz[obraz.Count - 1].Visible = false;
                    obraz[obraz.Count - 1].Location = new Point(poczatek.X + (base.adres[i].X - stroj[base.adres[i].Y].posX) * dxy.X + dx, poczatek.Y + base.adres[i].Y * dxy.Y);
                    obraz[obraz.Count - 1].SizeMode = PictureBoxSizeMode.StretchImage;
                    obraz[obraz.Count - 1].Size = rozmiar;
                    obraz[obraz.Count - 1].Name = base.nazwa.ToString();
                    obraz[obraz.Count - 1].Tag = i;
                    obraz[obraz.Count - 1].Paint += new PaintEventHandler(nowyPaint);
                    obraz[obraz.Count - 1].Click += new EventHandler(nowyClick);
                    obraz[obraz.Count - 1].BackColor = Color.Transparent;

                    forma.Controls.Add(obraz[obraz.Count - 1]);
                    obraz[obraz.Count - 1].BringToFront();

                    if (pozycjaPocz != -1) break;

                }

            }
            SetImage(base.nazwa == zaznaczonyDzwiek);

        } // END private void GenerujObraz     

        public void Czysc() {
            for (int i = 0; i < obraz.Count; i++) forma.Controls.Remove(obraz[i]);
        }

        // glowny konstruktor
        public DzwiekGraficzny(Form1 forma, Gitara gitara, Image kropka, Image kropkaBazowa, Image kropkaZaznaczona, DzwiekNaGryfie baza, Stroj stroj, 
            Nazwa zaznaczonyDzwiek, int pozycjaPocz) : base(baza.nazwa) {

            obraz = new List<PictureBox>();
            this.forma = forma;
            this.gitara = gitara;
            this.kropka = kropka;
            this.kropkaBazowa = kropkaBazowa;
            this.kropkaZaznaczona = kropkaZaznaczona;
            base.stopienSkali = baza.stopienSkali;
            this.stroj = stroj;
            this.zaznaczonyDzwiek = zaznaczonyDzwiek;
            this.pozycjaPocz = pozycjaPocz;
            
            GenerujObraz();
        } // END public DzwiekGraficzny

        //public void SetVisible() { for (int i = 0; i < obraz.Count; i++) obraz[i].Visible = true; }


    } // END public class DzwiekGraficzny : DzwiekNaGryfie
}
