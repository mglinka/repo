using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace Dane
{
    public abstract class IKulka : IObservable<IKulka>
    {
        public abstract int ID { get ; }
        public abstract IDisposable Subscribe(IObserver<IKulka> observer);
        public abstract Vector2 pozycja { get ; }
        public abstract Vector2 predkosc { get; set; }
        public abstract float Masa { get; }
        public abstract float Promien { get; }
    }
    public abstract class DaneAbstractApi
    {
        public static DaneAbstractApi CreateApi()
        { return new DaneApi(); }
        public abstract void stworzKulke(int id_, float gora, float lewo, float predkoscX, float predkoscY, float masa, float promien);
        public abstract Kulka otrzymajKulke(int index);
        public abstract int otrzymajLiczbeKulek();
        public abstract void loguj(IKulka kulka);
        public abstract void zakoncz();
    }

    internal class DaneApi : DaneAbstractApi
    {
        private List<Kulka> kulki;
        private Prostokat prostokat;
        private DataToFile Logger;

        public DaneApi()
        {
            this.kulki = new List<Kulka>();
            this.prostokat = new Prostokat();
            Logger = new DataToFile();
            Logger.zapiszDoPlikuDane();
        }
        public override Kulka otrzymajKulke(int index)
        {
            return kulki[index];
        }

        public override int otrzymajLiczbeKulek()
        {
            return kulki.Count;
        }

        public override void stworzKulke(int id_, float gora, float lewo, float predkoscX, float predkoscY, float masa, float promien)
        {
            kulki.Add(new Kulka(id_, gora, lewo, predkoscX, predkoscY, masa, promien));
        }

        public override void loguj(IKulka kulka)
        {
            Logger.dodawanieDoKolejki(kulka);
        }

        public override void zakoncz()
        {
            Logger.ZakonczDzialanieLogera();
        }
    }
}
