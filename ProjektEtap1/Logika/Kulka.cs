using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    internal class Kulka
    {
        private int wspolrzednaX;
        private int wspolrzednaY;
        private int wartoscPredkosciX;
        private int wartoscPredkosciY;
        private const int promien = 5;

        public Kulka(int wspX, int wspY, int prdX, int prdY)
        {
            this.wspolrzednaX = wspX;
            this.wspolrzednaY = wspY;
            this.wartoscPredkosciX = prdX;
            this.wartoscPredkosciY = prdY;
        }

        public int getWspolrzednaX() { return wspolrzednaX; }
        public int getWspolrzednaY() { return wspolrzednaY; }
        public int getWartoscPredkosciX() { return wartoscPredkosciX; }
        public int getWartoscPredkosciY() { return wartoscPredkosciY; }
        public int getPromien() { return promien; }

        public void setWspolrzednaX(int x) { wspolrzednaX = x; }
        public void setWspolrzednaY(int y) { wspolrzednaY = y; }
        public void setWartoscPredkosciX(int x) { wartoscPredkosciX = x; }
        public void setWartoscPredkosciY(int y) { wartoscPredkosciY = y; }

        public void zmienPolozenieKulki()
        {
            System.Diagnostics.Trace.WriteLine("Poruszylam sie");
            setWspolrzednaX(getWspolrzednaX() + getWartoscPredkosciX());
            setWspolrzednaY(getWspolrzednaY() + getWartoscPredkosciY());
        }
    }
}