using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Dane;

namespace Logika
{
    public abstract class LogikaAbstractApi : IObserver<IKulka>, IObservable<int>
    {
        public static LogikaAbstractApi CreateApi(DaneAbstractApi api)
        {
            return new LogikaApi(api);
        }
        public abstract void TworzKole(float x, float y, float prdX, float prdY, float masa, float promien);

        public abstract void OnCompleted();

        public abstract void OnError(Exception error);

        public abstract void OnNext(IKulka value);

        public abstract IDisposable Subscribe(IObserver<int> observer);
        public abstract float PodajXKulki(int index);
        public abstract float PodajYKulki(int index);
    }

    internal class LogikaApi : LogikaAbstractApi
    {
        private readonly object gate = new object();
        private Random random = new Random();
        private DaneAbstractApi daneApi;
        private List<IObserver<int>> obserwatorzy;

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<int>> _observers;
            private IObserver<int> _observer;

            public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }


        public LogikaApi(DaneAbstractApi apiDanych)
        {
            this.daneApi = apiDanych;
            this.obserwatorzy = new List<IObserver<int>>();
        }

        public override void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public override void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public override void OnNext(IKulka value) //Detekcja kolizji
        {
            lock (gate)
            {
                int index = 0;
                //pamietac spaeawdzic czy nie porownujemy z ta sama
                if (value.pozycja.Y <= 0 || value.pozycja.Y >= 450)
                {
                    value.predkosc = new Vector2(value.predkosc.X, -value.predkosc.Y);
                }
                if (value.pozycja.X <= 0 || value.pozycja.X >= 320)
                {
                    value.predkosc = new Vector2(-value.predkosc.X, value.predkosc.Y);
                }
                for (int i = 0; i < daneApi.otrzymajLiczbeKulek(); i++)
                {

                    IKulka Porownaj = daneApi.otrzymajKulke(i);

                    if (Porownaj == value)
                    {
                        index = i;
                        continue;
                    }


                    if (Math.Abs(value.pozycja.X - Porownaj.pozycja.X) <= (value.Promien + Porownaj.Promien) &&
                        Math.Abs(value.pozycja.Y - Porownaj.pozycja.Y) <= (value.Promien + Porownaj.Promien))
                    {
                        Vector2 nowaPredkoscDlaValue = Porownaj.predkosc;
                        Vector2 nowaPredkoscDlaPorownaj = value.predkosc;

                        value.predkosc = nowaPredkoscDlaValue;
                        Porownaj.predkosc = nowaPredkoscDlaPorownaj;
                    }
                }

                foreach (var o in obserwatorzy)
                {
                    o.OnNext(index);
                }
            }
        }

        public override IDisposable Subscribe(IObserver<int> observer)
        {
            if (observer != null) { obserwatorzy.Add(observer); }
            return new Unsubscriber(obserwatorzy, observer);
        }

        public override void TworzKole(float x, float y, float prdX, float prdY, float masa, float promien)
        {
            daneApi.stworzKulke(x, y, prdX, prdY, masa, promien);
            daneApi.otrzymajKulke(daneApi.otrzymajLiczbeKulek() - 1).Subscribe(this);
        }

        public override float PodajXKulki(int index)
        {
            return daneApi.otrzymajKulke(index).pozycja.X;
        }

        public override float PodajYKulki(int index)
        {
            return daneApi.otrzymajKulke(index).pozycja.Y;
        }
    }

}
