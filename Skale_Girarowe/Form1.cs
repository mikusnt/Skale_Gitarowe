using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Skale_Gitarowe {
    public partial class Form1 : Form {
        private Gitara gitara;
        private Boolean init = true;
        public readonly Boolean TEST_CZASU = false;
        public Czas pomiarCzasu;
        // glowny konstruktor
        public Form1() {
            InitializeComponent();
            pomiarCzasu = new Czas();
            gitara = new Gitara(this);

            FilldataSkale0(true);

            comboS0.SelectedIndex = 4;
            comboS1.SelectedIndex = 4;
            comboS2.SelectedIndex = 4;
            comboS3.SelectedIndex = 4;
            comboS4.SelectedIndex = 4;
            comboS5.SelectedIndex = 4;

            for (Litera i = Litera.C; i <= Litera.H; i++)
                comboDzwiek0.Items.Add(i);

            comboDzwiek0.SelectedIndex = 0;
            //comboGrupa0.SelectedIndex = 0;
            comboRodzaj0.SelectedIndex = 0;

            //comboGrupa0.SelectedValueChanged += new EventHandler(Filtruj);
            comboRodzaj0.SelectedValueChanged += new EventHandler(Filtruj);

            radioPoz0.Checked = true;

            SetChromatyczna();
            init = false;

        } // END  public Form1()

        // wypelnia tabele danych skal
        private void FilldataSkale0(Boolean cala) {
            DaneSkali temp = new DaneSkali();
            temp.dzwiekBazowy = gitara.gama.dzwiekBazowy;
            if (cala) {
                dataSkale0.Rows.Clear();
                for (Skala i = Skala.chromatyczna; i <= Skala.bopowa_molowa; i++) {
                    temp.skala = i;

                    dataSkale0.Rows.Add(temp.skala.ToCustomString(), temp.interwaly, temp.dzwieki, temp.rodzaj.ToString().Replace('_', ' '));
                    dataSkale0.Rows[(int)i].Cells[0].Tag = temp.skala;

                }
                dataSkale0.Sort(dataSkale0.Columns[0], ListSortDirection.Ascending);
                SetChromatyczna();
            } else {
                for (int i = 0; i < dataSkale0.Rows.Count; i++) {
                    temp.skala = (Skala)dataSkale0.Rows[i].Cells[0].Tag;
                    dataSkale0.Rows[i].Cells[2].Value = temp.dzwieki;
                }
            }
        } // END private void FilldataSkale0

        // laduje informacje o dzwieku do etykiet
        public void TolabelInfo(String nazwa, String czestotliwosc, String stopien) {
            groupInfo.Enabled = true;
            labelInfoT0.Text = nazwa;
            labelInfoT1.Text = String.Concat(czestotliwosc, " Hz");
            labelInfoT2.Text = stopien;
        } // END public void TolabelInfo

        // czysci etykiety informacji o dzwieku
        private void ClearDzwiekInfo() {
            groupInfo.Enabled = false;
            labelInfoT0.Text = "";
            labelInfoT1.Text = "";
            labelInfoT2.Text = "";
        } // END private void ClearDzwiekInfo

        // laduje dane aktywnej skali do dolnego paska statusu
        private void ToStatusLabelO(DaneSkali daneSkali) {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            statusLabel0.Text = ti.ToTitleCase(daneSkali.skala.ToCustomString()) + " | " + daneSkali.interwaly + " | " + daneSkali.dzwieki
                + " | " + daneSkali.rodzaj.ToString().Replace('_', ' ') + " | " + daneSkali.opis;
        } // END private void ToStatusLabelO

        // zaznacza skale chromatyczna
        private void SetChromatyczna() {
            int i;
            for (i = 0; i < dataSkale0.Rows.Count; i++)
                if (dataSkale0.Rows[i].Cells[0].Value.Equals("chromatyczna")) break;

            dataSkale0.Rows[i].Visible = true;
            dataSkale0.Rows[i].Selected = true;
            dataSkale0.CurrentCell = dataSkale0.Rows[i].Cells[0];
        } // END private void SetChromatyczna()

        //private void OpisSkaliKursor(MouseEventArgs e) {
        //    DataGridView.HitTestInfo testinfo = dataSkale0.HitTest(e.X, e.Y);
        //    if (testinfo.RowIndex >= 0) gitara.gama.skala = (Skala) dataSkale0.Rows[testinfo.RowIndex].Cells[1].Value;
        //    ToStatusLabelO(gitara.gama.daneSkali);
        //}

        // zmiana aktualnie wybranej skali
        private void OpisSkaliAktywnej() {
            if (dataSkale0.SelectedRows.Count > 0) {

                gitara.gama.skala = (Skala)dataSkale0.SelectedRows[0].Cells[0].Tag;
                gitara.ResetujzaznaczonyDzwiek();
                ToStatusLabelO(gitara.gama.daneSkali);

                gitara.RysujDzwieki();
            }
        } // END private void OpisSkaliAktywnej

        // akcja zmiany dzwieku bazowego
        private void comboDzwiek0_SelectedValueChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (!init) {
                gitara.gama.dzwiekBazowy = new DzwiekNaGryfie(new Nazwa((Litera)comboDzwiek0.SelectedItem));
                gitara.ResetujzaznaczonyDzwiek();
                ClearDzwiekInfo();
                ToStatusLabelO(gitara.gama.daneSkali);
                FilldataSkale0(false);
                gitara.RysujDzwieki();
            }

            pomiarCzasu.StopToConsole(TEST_CZASU);
        } // END private void comboDzwiek0_SelectedValueChanged

        // akcje zmiany dzwieku stroju
        private void comboS0_SelectedValueChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (!init) {
                gitara.stroj.StrojStrune(0, new Nazwa(comboS0.SelectedItem.ToString()));
                gitara.RysujDzwieki();
            }
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        private void comboS1_SelectedValueChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (!init) {
                gitara.stroj.StrojStrune(1, new Nazwa(comboS1.SelectedItem.ToString()));
                gitara.RysujDzwieki();
            }
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        private void comboS2_SelectedValueChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (!init) {
                gitara.stroj.StrojStrune(2, new Nazwa(comboS2.SelectedItem.ToString()));
                gitara.RysujDzwieki();
            }
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        private void comboS3_SelectedValueChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (!init) {
                gitara.stroj.StrojStrune(3, new Nazwa(comboS3.SelectedItem.ToString()));
                gitara.RysujDzwieki();
            }
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        private void comboS4_SelectedValueChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (!init) {
                gitara.stroj.StrojStrune(4, new Nazwa(comboS4.SelectedItem.ToString()));
                gitara.RysujDzwieki();
            }
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        private void comboS5_SelectedValueChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (!init) {
                gitara.stroj.StrojStrune(5, new Nazwa(comboS5.SelectedItem.ToString()));
                gitara.RysujDzwieki();
            }
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        // akcja zmiany zaznaczonej skali
        private void dataSkale0_SelectionChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);

            if (!init) {
                OpisSkaliAktywnej();
                ClearDzwiekInfo();
            }

            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        // akcje zmiany pozycji na gryfie
        private void radioPoz0_CheckedChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if ((!init) && (radioPoz0.Checked)) gitara.pozycja = 0;
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        private void radioPoz1_CheckedChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (radioPoz1.Checked) gitara.pozycja = 1;
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        private void radioPoz2_CheckedChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (radioPoz2.Checked) gitara.pozycja = 2;
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        private void radioPoz3_CheckedChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (radioPoz3.Checked) gitara.pozycja = 3;
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        private void radioPoz4_CheckedChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (radioPoz4.Checked) gitara.pozycja = 4;
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        private void radioPoz5_CheckedChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (radioPoz5.Checked) gitara.pozycja = 5;
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        private void radioPoz6_CheckedChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (radioPoz6.Checked) gitara.pozycja = 6;
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        private void radioPoz7_CheckedChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (radioPoz7.Checked) gitara.pozycja = 7;
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        private void radioPoz8_CheckedChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (radioPoz8.Checked) gitara.pozycja = 8;
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        private void radioPoz9_CheckedChanged(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (radioPoz9.Checked) gitara.pozycja = 9;
            pomiarCzasu.StopToConsole(TEST_CZASU);
        }

        private void textNazwa_TextChanged(object sender, EventArgs e) {

        }

        // zdarzenie filtrowania tabeli skal
        private void Filtruj(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            if (!init) {
                for (int i = 0; i < dataSkale0.Rows.Count; i++) dataSkale0.Rows[i].Visible = true;
                foreach (DataGridViewRow i in dataSkale0.Rows) {
                    if (i.Cells[0].Value.ToString().IndexOf(textNazwa.Text) == -1) i.Visible = false;
                    //if ((!comboGrupa0.SelectedItem.ToString().Equals("wszystkie")) && (!comboGrupa0.SelectedItem.ToString().Equals(i.Cells[0].Value.ToString()))) i.Visible = false;
                    if (i.Cells[2].Value.ToString().IndexOf(textDzwieki.Text) == -1) i.Visible = false;
                    if ((!comboRodzaj0.SelectedItem.ToString().Equals("wszystkie")) && (!comboRodzaj0.SelectedItem.ToString().Equals(i.Cells[3].Value.ToString()))) i.Visible = false;
                }
                SetChromatyczna();
            }
            pomiarCzasu.StopToConsole(TEST_CZASU);
        } // END private void Filtruj

        // zdarzenie przycisku resetu pol wyszukiwan
        private void buttonReset0_Click(object sender, EventArgs e) {
            pomiarCzasu.Start(TEST_CZASU);
            init = true;
            textNazwa.Text = "";
            textDzwieki.Text = "";
            //comboGrupa0.SelectedIndex = 0;
            comboRodzaj0.SelectedIndex = 0;

            init = false;
            SetChromatyczna();
            
            Filtruj(sender, e);
            
            pomiarCzasu.StopToConsole(TEST_CZASU);
        } // private void buttonReset0_Click

        // zdarzenie obslugi textboxu dzwiekow skali
        private void textDzwieki_TextChanged(object sender, EventArgs e) {
            if (!init) {
                if (textDzwieki.Text.Length > 2) {
                    String temp0 = textDzwieki.Text[textDzwieki.Text.Length - 1].ToString();
                    String temp1 = textDzwieki.Text[textDzwieki.Text.Length - 2].ToString();
                    String temp2 = textDzwieki.Text[textDzwieki.Text.Length - 3].ToString();
                    if ((temp1.Equals(" ")) && (!temp0.Equals(" ")) && (temp0.ToUpper().Equals(temp0)) && (!temp2.Equals(" ")) && (temp2.ToUpper().Equals(temp2))) {
                        textDzwieki.Text = textDzwieki.Text.Insert(textDzwieki.Text.Length - 2, "  ");
                        textDzwieki.SelectionStart = textDzwieki.Text.Length;
                    }
                }
                Filtruj(sender, e);
            }
        } // END private void textDzwieki_TextChanged

    } // END  public partial class Form1 : Form

} // END namespace Skale_Gitarowe
