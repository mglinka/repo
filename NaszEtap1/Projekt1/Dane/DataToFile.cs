using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections;
using System.Xml;

//Konieczne jest logowanie do pliku polozenia kulki

namespace Dane
{
    internal class DataToFile
    {
        private Task logger;
        private XmlWriter writer;
        private BlockingCollection<DaneOKulce> kolejka;
        private string sciezka = "PLIK_XML_Z_DANYMI.xml";
        private float wysokosc;
        private float szerokosc;

        public DataToFile() 
        {
            wysokosc = 370;
            szerokosc = 500;
            kolejka = new BlockingCollection<DaneOKulce>();
            //zapiszDoPlikuDane();
            //writer = XmlWriter.Create;
            //logger = Task.Run(zapiszDoPlikuDane);
        }

        public void zapiszDoPlikuDane()
        {
            logger = Task.Run(() =>
            {
                using (writer = XmlWriter.Create(sciezka, new XmlWriterSettings
                {
                    OmitXmlDeclaration = true,
                    Indent = true
                }))
                {
                    writer.WriteStartElement("Aktywnosc_kulek");
                    foreach (DaneOKulce kulka in kolejka.GetConsumingEnumerable())
                    {
                        writer.WriteStartElement("Kulka");
                        writer.WriteElementString("ID_KULKI", XmlConvert.ToString(kulka.id));
                        writer.WriteElementString("WSP_X", XmlConvert.ToString(kulka.wsp_x));
                        writer.WriteElementString("WSP_Y", XmlConvert.ToString(kulka.wsp_y));
                        writer.WriteElementString("CZAS", kulka.czas);
                        writer.WriteEndElement();
                    }
                }
            });
        }

        public void dodawanieDoKolejki(IKulka ikulka)
        {
            //na poczatku trzeba sprawdzić czy nie przekazujemy nulla
            if (ikulka == null)
            {
                return;
            }

            if (!kolejka.IsAddingCompleted)
            {
                kolejka.Add(new DaneOKulce(ikulka.ID, ikulka.pozycja.X, ikulka.pozycja.Y));
            }
        }

        internal void ZakonczDzialanieLogera()
        {
            kolejka.CompleteAdding();
        }

    }
    internal class DaneOKulce
    {
        public int id { get; set; }
        public float wsp_x { get; set; }
        public float wspy { get; set; }
        public string czas { get; set; }

        public DaneOKulce(int id, float wspx, float wspy)
        {
            id = id_;
            wsp_x = wspx;
            wsp_y = wspy;
            czas = DateTime.Now.ToString("h:mm:ss tt");
        }
    }

}
