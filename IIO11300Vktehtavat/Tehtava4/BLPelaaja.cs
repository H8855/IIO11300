using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava4
{
    class Pelaaja
    {
        #region PROPERTIES

        private string etunimi;

        public string Etunimi
        {
            get { return etunimi; }
            set { etunimi = value; }
        }

        private string sukunimi;

        public string Sukunimi
        {
            get { return sukunimi; }
            set { sukunimi = value; }
        }

        private string kokonimi;

        public string Kokonimi
        {
            get { return kokonimi; }
        }

        private string esitysnimi;

        public string Esitysnimi
        {
            get { return esitysnimi; }
        }

        private string seura;

        public string Seura
        {
            get { return seura; }
            set { seura = value; }
        }

        private int siirtohinta;

        public int Siirtohinta
        {
            get { return siirtohinta; }
            set { siirtohinta = value; }
        }

        public String DataMuoto
        {
            get { return etunimi + ";" + sukunimi + ";" + seura + ";" + siirtohinta; }
        }

        #endregion

        #region CONSTRUCTORS

        public Pelaaja(string etunimi, string sukunimi, string seura, int siirtohinta)
        {
            this.etunimi = etunimi;
            this.sukunimi = sukunimi;
            this.seura = seura;
            this.siirtohinta = siirtohinta;
        }

        public Pelaaja()
        {
            this.etunimi = "Matti";
            this.sukunimi = "Meikäläinen";
            this.seura = "Tappara";
            this.siirtohinta = 2500;
        }

        #endregion

        public override string ToString()
        {
            return esitysnimi;
        }

        #region METHODS

        public void UpdateNames()
        {
            kokonimi = etunimi + " " + sukunimi;
            esitysnimi = kokonimi + ", " + seura;
        }

        public static void SaveDataToFile(List<Pelaaja> dataa, string filu)
        {
            //kirjoitetaan data tiedostoon, jos tiedosto on jo olemassa, liitetään se olemassaolevaan
            try
            {
                //tutkitaan onko tiedosto olemassa
                if (!System.IO.File.Exists(filu))
                {
                    //luodaan uusi
                    using (StreamWriter sw = File.CreateText(filu))
                    {
                        //käydään kokoelma läpi
                        foreach (var item in dataa)
                        {
                            sw.WriteLine(item.DataMuoto);
                        }
                    }
                }
                else
                {
                    //lisätään olemassaolevaan tiedostoon
                    using (StreamWriter sw = File.AppendText(filu))
                    {
                        foreach (var item in dataa)
                        {
                            sw.WriteLine(item.DataMuoto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
