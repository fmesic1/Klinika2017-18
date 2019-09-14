using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikaZadaca17321
{
    public class Doktor : Uposlenik
    {
        private int broj_pregledanih;
        private int cijena_njegovih_usluga;
        private int id_ordinacije_u_kojoj_radi;

        public override Uposlenik DajKopiju()
        {
            return this;
        }

        public Doktor(string ime, int plata, int id, int cijenaNjegovihUsluga, int idOrdinacije, string username, string sifra) : base(ime, plata, id, username, sifra)
        {
            broj_pregledanih = 0;
            cijena_njegovih_usluga = cijenaNjegovihUsluga;
            Id_ordinacije_u_kojoj_radi = idOrdinacije;
        }
        public int Broj_pregledanih { get => broj_pregledanih; set => broj_pregledanih = value; }
        public int Cijena_njegovih_usluga { get => cijena_njegovih_usluga; set => cijena_njegovih_usluga = value; }
        public int Id_ordinacije_u_kojoj_radi { get => id_ordinacije_u_kojoj_radi; set => id_ordinacije_u_kojoj_radi = value; }
        
        public override double IznosPlateSaSvimUracunatimDodacima()
        {
            return Plata_dnevna + Plata_dnevna * 0.1 * broj_pregledanih;
        }
        public override string IspisiPrimanje()
        {
            string povratna = "Ime: " + Ime + "\n" + "Dnevna plata iznosi: " + Plata_dnevna + "\n";
            if (Broj_pregledanih != 0)
            {
                povratna += "Danas je kod navedenog doktora bilo " + Broj_pregledanih + " pacijenata.\n";
                povratna += "Dodatak po svakom pacijentu iznosi: " + Plata_dnevna * 0.1 + " KM.\n";
            }
            else
            {
                povratna += "Danas kod navedenog doktora nije bilo pacijenata.\n";
            }
            povratna += "Doktor je danas ukupno zaradio: " + IznosPlateSaSvimUracunatimDodacima() + " KM.\n";
            return povratna;
        }
    }
}