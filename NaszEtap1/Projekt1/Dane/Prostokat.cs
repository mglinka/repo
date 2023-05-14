using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    internal class Prostokat
    {
        public float wysokosc { get; private set; }
        public float szerokosc { get; private set; }
        public Prostokat()
        {
            this.wysokosc = 370;
            this.szerokosc = 500;
        }
    }
}
