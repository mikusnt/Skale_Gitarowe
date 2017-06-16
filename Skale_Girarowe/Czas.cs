using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Skale_Gitarowe {

    // klasa upraszczajaca odmierzanie czasu
    public class Czas {
        private Stopwatch czasomierz;
        private TimeSpan czas;

        public void Start(Boolean testCzasu) {
            if (testCzasu) {
                czasomierz = new Stopwatch();
                czasomierz.Start();
            }
        } // public void Start

        public void Stop() { czas = czasomierz.Elapsed; }

        public void StopToConsole(Boolean testCzasu) {
            if (testCzasu) {
                Stop();
                Console.WriteLine(ToString());
            }
        }

        public override string ToString() {
            return String.Concat(Math.Round(czas.TotalMilliseconds, 1).ToString(), "ms");
        }
        // glowny konstruktor
        public Czas(Boolean testCzasu = false) { czasomierz = new Stopwatch(); czas = new TimeSpan(); Start(testCzasu); }
    }
}
