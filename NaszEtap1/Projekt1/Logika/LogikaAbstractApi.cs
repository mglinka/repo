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
        private int prdX;
        private int prdY;

        public LogikaApi()
        {
            this.prostokat = new Prostokat(370, 500);
            this.daneApi = DaneAbstractApi.CreateApi();
        }

        public Prostokat getProstokat() { return prostokat; }

        public override void tworzKule()
        {
            prdX = random.Next(2); //zero w gore jeden w dol
            prdY = random.Next(2); //zero w lewo jeden w prawo
            if(prdX == 0)
            {
                prdX = -1;
            }
            if(prdY == 0)
            {
                prdY = -1;
            }
            Console.WriteLine("X: " +  prdX);
            getProstokat().dodajKulke(new Kulka(random.Next(10, 350), random.Next(10, 480), prdX, prdY));
        }
        public override void poruszajKulkami()
        {
            for (int i = 0; i < prostokat.getKulki().Count; i++)
            {
                //Sprawdz kolizje na osi X 
                if (prostokat.podajYKulki(i) == 0 || prostokat.podajYKulki(i) == 490)
                {
                    prostokat.getKulka(i).setWartoscPredkosciY(prostokat.getKulka(i).getWartoscPredkosciY() * (-1));
                }

                if (prostokat.podajXKulki(i) == 0 || prostokat.podajXKulki(i) == 360)
                {
                    prostokat.getKulka(i).setWartoscPredkosciX(prostokat.getKulka(i).getWartoscPredkosciX() * (-1));
                }

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
