using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Logika;

namespace Model
{
    public class ModelKulka : INotifyPropertyChanged
    {
        public float srednica { get; }
        public float wspolrzednaX { get; set; } //tu jako top - x
        public float wspolrzednaY { get; set; } //tu jako top - y
        public event PropertyChangedEventHandler? PropertyChanged;

        public ModelKulka(int srednica, int wspolrzednaX, int wspolrzednaY)
        {
            this.srednica = srednica;
            this.wspolrzednaX = wspolrzednaX;
            this.wspolrzednaY = wspolrzednaY;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public float wspX
        {
            get { return wspolrzednaX; }
            set
            {
                wspolrzednaX = value;
                OnPropertyChanged();
            }
        }


        public float wspY
        {
            get { return wspolrzednaY; }
            set
            {
                wspolrzednaY = value;
                OnPropertyChanged();
            }
        }

        public float srd
        {
            get { return srednica; }
        }

        public void ruszKulka(float x, float y)
        {
            wspX = x;
            wspY = y;
            //this.wspolrzednaY = y;
        }

    }
}
