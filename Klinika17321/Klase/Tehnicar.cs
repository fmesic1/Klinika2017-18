using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikaZadaca17321
{
    public class Tehnicar : Uposlenik
    {
        public Tehnicar(string ime, int plata, int id, string username, string sifra) : base(ime, plata, id, username, sifra){}
        public override double IznosPlateSaSvimUracunatimDodacima()
        {
            return Plata_dnevna;
        }
        public override string IspisiPrimanje()
        {
            string povratna = "Ime: " + Ime + "\n" + "Dnevna plata iznosi: " + Plata_dnevna + "\n";
            return povratna;
        }
        public override Uposlenik DajKopiju()
        {
            return this;
        }
    }
}
