using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class Kulka : IKulka
    {
        public override int ID { get; }
        public override Vector2 pozycja { get { return pozycja_; } } //x i y srodka
        public override Vector2 predkosc { get; set; }
        public override float Masa { get; }
        public override float Promien { get; }

        private List<IObserver<IKulka>> obserwatorzy;
        
        private Task task;

        private Vector2 pozycja_;

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<IKulka>> _observers;
            private IObserver<IKulka> _observer;

            public Unsubscriber(List<IObserver<IKulka>> observers,  IObserver<IKulka> observer)
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

        private async void Rusz() //
        {
            while(true) 
            {
                //************************************************
                //      s
                // t = ----
                //      v
                // okreslamy minimalny krok 0.1 jaki mozna wykonac
                // krok = 0.1
                //
                //************************************************
                Stopwatch stoper = Stopwatch.StartNew();
                float kroki = predkosc.Length() / 0.1f;
                //pozycja_ += Vector2.Normalize(predkosc) * 0.2f;
                foreach (var o in obserwatorzy)
                {
                    o.OnNext(this);
                }
                stoper.Stop();
                pozycja_ += Vector2.Normalize(predkosc) * 0.2f;
                //obliczanie delaya
                int spij = (int)(Convert.ToInt32(0.1f / kroki) - stoper.ElapsedMilliseconds );
                if ((int)(Convert.ToInt32(0.1f / kroki)) == 0) {
                    spij = 10;
                }
                //System.Diagnostics.
                await Task.Delay(spij);
                
            }
        }

        public override IDisposable Subscribe(IObserver<IKulka> observer)//
        {
            if (observer != null) { obserwatorzy.Add(observer); }
            return new Unsubscriber(obserwatorzy, observer);
        }

        public Kulka(int id_, float gora, float lewo, float predkoscX, float predkoscY, float masa, float promien)  //lewo i gora sa powiazane z interfejsem graficznym
        {
            pozycja_ = new Vector2(lewo, gora);
            predkosc = new Vector2(predkoscX, predkoscY);
            Masa = masa; 
            Promien = promien;
            ID = id_;
            obserwatorzy = new List<IObserver<IKulka>>();
            task = Task.Run(Rusz); 
        }
    }
}
