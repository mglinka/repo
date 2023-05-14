using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class Kulka : IKulka
    {
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
                System.Diagnostics.Trace.WriteLine(pozycja_);
                // += predkosc;
                foreach (var o in obserwatorzy)
                {
                    o.OnNext(this);
                }
                pozycja_ += predkosc;
                await Task.Delay(10);
            }
        }

        public override IDisposable Subscribe(IObserver<IKulka> observer)//
        {
            if (observer != null) { obserwatorzy.Add(observer); }
            return new Unsubscriber(obserwatorzy, observer);
        }

        public Kulka(float gora, float lewo, float predkoscX, float predkoscY, float masa, float promien)  //lewo i gora sa powiazane z interfejsem graficznym
        {
            pozycja_ = new Vector2(lewo, gora);
            predkosc = new Vector2(predkoscX, predkoscY);
            Masa = masa; 
            Promien = promien;
            obserwatorzy = new List<IObserver<IKulka>>();
            task = Task.Run(Rusz); 
        }
    }
}
