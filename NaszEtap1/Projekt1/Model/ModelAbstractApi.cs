using Dane;
using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class ModelAbstractApi : IObserver<int>
    {
       // public abstract Kulka tworzKule();
        public abstract void Start(int value);

        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }

        public abstract void OnCompleted();

        public abstract void OnError(Exception error);

        public abstract void OnNext(int value);

        public abstract ModelKulka GetKulka(int index);

        public abstract void ZakonczLogowanie();
    }

    internal class ModelApi : ModelAbstractApi
    {
        private LogikaAbstractApi LogikaApi;
        private List<ModelKulka> kulki;

        public ModelApi()
        {
            this.LogikaApi = LogikaAbstractApi.CreateApi(DaneAbstractApi.CreateApi());
            this.kulki = new List<ModelKulka>();
            LogikaApi.Subscribe(this);
        }

        public override void ZakonczLogowanie()
        {
            LogikaApi.zakonczLogowanie();
        }

        public override ModelKulka GetKulka(int index)
        {
            return kulki[index];
        }

        public override void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public override void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public override void OnNext(int value)
        {
            kulki[value].wspX = LogikaApi.PodajXKulki(value);
            kulki[value].wspY = LogikaApi.PodajYKulki(value);
        }

        public override void Start(int value)
        {
            if (value >= 1)
            {
                LogikaApi.TworzKole(1, 50, 300, 0.2f, 0.2f, 1, 25);
                kulki.Add(new ModelKulka(50, 50, 300));
            }
            if (value >= 2)
            {
                LogikaApi.TworzKole(2, 50, 100, 0.2f, -0.2f, 1, 25);
                kulki.Add(new ModelKulka(50, 50, 100));
            }
            if (value >= 3)
            {
                LogikaApi.TworzKole(3, 150, 250, -0.2f, 0.2f, 1, 25);
                kulki.Add(new ModelKulka(50, 150, 250));
            }
            if (value >= 4)
            {
                LogikaApi.TworzKole(4, 200, 150, 0.2f, 0.2f, 1, 25);
                kulki.Add(new ModelKulka(50, 200, 150));
            }
            if (value == 5)
            {
                LogikaApi.TworzKole(5, 300, 300, -0.2f, -0.2f, 1, 25);
                kulki.Add(new ModelKulka(50, 300, 300));
            }
            /*
            LogikaApi.TworzKole(50, 300, 0.2f, 0.2f, 1, 25); <
            LogikaApi.TworzKole(50, 100, 0.2f, -0.2f, 1, 25); <
            LogikaApi.TworzKole(150, 250, -0.2f, 0.2f, 1, 25); <
            LogikaApi.TworzKole(200, 150, 0.2f, 0.2f, 1, 25); <
            LogikaApi.TworzKole(300, 300, -0.2f, -0.2f, 1, 25); 
            kulki.Add(new ModelKulka(50, 50, 300)); <
            kulki.Add(new ModelKulka(50, 50, 100)); <
            kulki.Add(new ModelKulka(50, 150, 250)); <
            kulki.Add(new ModelKulka(50, 200, 150));
            kulki.Add(new ModelKulka(50, 300, 300));
            */

        }
    }
}
