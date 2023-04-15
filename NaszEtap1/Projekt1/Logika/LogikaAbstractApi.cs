using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;

namespace Logika
{
    public abstract class LogikaAbstractApi
    {
        public abstract void tworzKule();
        public abstract void poruszajKulkami();
        public static LogikaAbstractApi CreateApi()
        {
            return new LogikaApi();
        }
        public abstract int zwrocXkulki(int index);
        public abstract int zwrocYkulki(int index);
        public abstract int ileKulek();
    }

    internal class LogikaApi : LogikaAbstractApi
    {
        private Prostokat prostokat;
        private Random random = new Random();
        private DaneAbstractApi daneApi;

        public LogikaApi()
        {
            this.prostokat = new Prostokat(370, 500);
            this.daneApi = DaneAbstractApi.CreateApi();
        }

        public Prostokat getProstokat() { return prostokat; }

        public override void tworzKule() 
        {
            getProstokat().dodajKulke(new Kulka(random.Next(0, 360), random.Next(0, 490), random.Next(-3, 3), random.Next(1, 3)));
        }
        public override void poruszajKulkami() {
            for (int i = 0; i < prostokat.getKulki().Count; i++)
            {
                prostokat.getKulka(i).zmienPolozenieKulki();
            }
        }
        public override int zwrocXkulki(int index)
        {
            return prostokat.getKulka(index).getWspolrzednaX();
        }

        public override int zwrocYkulki(int index)
        {
            return prostokat.getKulka(index).getWspolrzednaY();
        }
        public override int ileKulek()
        {
            return prostokat.getKulki().Count;
        }

    }
}
