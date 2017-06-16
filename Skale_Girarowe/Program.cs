using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Skale_Gitarowe
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try {
                Form1 forma = new Form1();
                Application.Run(forma);
            } catch (Exception e) {
                MessageBox.Show(e.Message, e.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                StreamWriter plik = new StreamWriter(@"error_log.ms", true);
                plik.WriteLine(DateTime.Now);
                plik.WriteLine(e.ToString());
                plik.Close();
            }

            //Stroj nowy = new Stroj();
            //DzwiekNaGryfie dzwiek = new DzwiekNaGryfie(new Nazwa(Litera.E), 1, nowy);
            //Console.Write(dzwiek.ToString());
            //Console.Write(Skala.bopowa_dominantowa.ToCustomString());

            // Console.ReadKey();
        }
    }

} // END namespace testy_skale
