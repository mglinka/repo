using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class KulkaModel
    {
        public interface Ikulka : INotifyPropertyChanged
        {
            int srednica { get; set; }
            int wspolrzednaX { get; set; }
            int wspolrzednaY { get; set; }
        }
        public class Kulka : INotifyPropertyChanged
        {
            public int srednica { get; set; }
            public int wspolrzednaX { get; set; }
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
                    OnPropertyChanged("wspX");
                }
            }


            public int wspY
            {
                get { return wspolrzednaY; }
                set
                {
                    wspolrzednaY = value;
                    OnPropertyChanged("wspY");
                }
            }

            public int srd
            {
                get { return srednica; }
            }

            public void ruszKulka(int x, int y)
            {
                this.wspolrzednaX = x;
                this.wspolrzednaY = y;
            }

        }
    }
}
