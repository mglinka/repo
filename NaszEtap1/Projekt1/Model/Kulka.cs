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
    public class Kulka : INotifyPropertyChanged
    {
        public int srednica { get; set; }
        private int wspolrzednaX;
        public int wspolrzednaY { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public Kulka(int srednica, int wspolrzednaX, int wspolrzednaY)
        {
            this.srednica = srednica;
            this.wspolrzednaX = wspolrzednaX;
            this.wspolrzednaY = wspolrzednaY;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int wspX
        {
            get { return wspolrzednaX; }
            set
            {
                wspolrzednaX = value;
                OnPropertyChanged();
            }
        }


        public int wspY
        {
            get { return wspolrzednaY; }
            set
            {
                wspolrzednaY = value;
                OnPropertyChanged();
            }
        }

        public int srd
        {
            get { return srednica; }
        }

        public void ruszKulka(int x, int y)
        {
            wspX = x;
            wspY = y;
            //this.wspolrzednaY = y;
        }

    }
}
