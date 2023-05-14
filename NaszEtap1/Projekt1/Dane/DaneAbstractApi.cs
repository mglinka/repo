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
        public abstract void stworzKulke(float gora, float lewo, float predkoscX, float predkoscY, float masa, float promien);
        public abstract Kulka otrzymajKulke(int index);
        public abstract int otrzymajLiczbeKulek();
    }

    internal class DaneApi : DaneAbstractApi
    {
        private List<Kulka> kulki;
        private Prostokat prostokat;

        public DaneApi()
        {
            this.kulki = new List<Kulka>();
            this.prostokat = new Prostokat();
        }
        public override Kulka otrzymajKulke(int index)
        {
            return kulki[index];
        }

        public override int otrzymajLiczbeKulek()
        {
            return kulki.Count;
        }

        public override void stworzKulke(float gora, float lewo, float predkoscX, float predkoscY, float masa, float promien)
        {
            kulki.Add(new Kulka(gora, lewo, predkoscX, predkoscY, masa, promien));
        }
    }
}
