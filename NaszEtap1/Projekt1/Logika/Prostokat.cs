using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class Prostokat
    {
        private int wysokosc;
        private int szerokosc;
        private List<Kulka> kulki = new List<Kulka>();

        public Prostokat(int wysokosc, int szerokosc)
        {
            this.wysokosc = wysokosc;
            this.szerokosc = szerokosc;
        }

        public int getWysokosc() { return wysokosc; }
        public int getSzerokosc() { return szerokosc; }
        public List<Kulka> getKulki() { return kulki; }
        public Kulka getKulka(int indeks) { return getKulki()[indeks]; }

        public void setDlugosc(int wys) { wysokosc = wys; }
        public void setSzerokosc(int szr) { szerokosc = szr; }
        public void dodajKulke(Kulka kulka) { kulki.Add(kulka); }
        public int podajXKulki(int indeks) { return kulki[indeks].getWspolrzednaX(); }
        public int podajYKulki(int indeks) { return kulki[indeks].getWspolrzednaY(); }
        public int podajPredkoscXKulki(int indeks) { return kulki[indeks].getWartoscPredkosciX(); }
        public int podajPredkoscYKulki(int indeks) { return kulki[indeks].getWartoscPredkosciY(); }
    }
}
