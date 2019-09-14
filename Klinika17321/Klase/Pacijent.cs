using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace KlinikaZadaca17321
{
    public class Pacijent
    {
        private string ime;
        private string prezime;
        private DateTime datum_rodjenja;
        private string jmbg;
        private int spol;
        private string adresa_stanovanja;
        private string bracno_stanje;
        private int bio_u_bolnici_puta;
        private int ziv;
        private int dug;
        private Image slikaPacijenta;
        private bool imaSliku;

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTime Datum_rodjenja { get => datum_rodjenja; set => datum_rodjenja = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
        public int Spol { get => spol; set => spol = value; }
        public string Adresa_stanovanja { get => adresa_stanovanja; set => adresa_stanovanja = value; }
        public int Bio_u_bolnici_puta { get => bio_u_bolnici_puta; set => bio_u_bolnici_puta = value; }
        public string Bracno_stanje { get => bracno_stanje; set => bracno_stanje = value; }
        public int Ziv { get => ziv; set => ziv = value; }
        public int Dug { get => dug; set => dug = value; }
        public Image SlikaPacijenta { get => slikaPacijenta; set => slikaPacijenta = value; }
        public bool ImaSliku { get => imaSliku; set => imaSliku = value; }

        public Pacijent(string ime, string prezime, DateTime datum_rodjenja, string maticni, int spol,
            string adresa_stanovanja, string bracno_stanje)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.datum_rodjenja = datum_rodjenja;
            this.jmbg = maticni;
            this.spol = spol;
            this.adresa_stanovanja = adresa_stanovanja;
            this.bracno_stanje = bracno_stanje;
            this.bio_u_bolnici_puta = 0;
            this.ziv = 1;
            this.dug = 0;
            ImaSliku = false;
        }
        public Pacijent()
        {
            //Konstruktor za hitan slucaj
            //-1 oznacava da je informacija nepoznata
            this.ime = "";
            this.prezime = "";
            this.datum_rodjenja = DateTime.Today;
            this.jmbg = "";
            this.spol = -1;
            this.adresa_stanovanja = "";
            this.bracno_stanje = "";
            bio_u_bolnici_puta = 0;
            ziv = 2;
        }
        public Pacijent(Pacijent p)
        {
            this.ime = p.Ime;
            this.prezime = p.Prezime;
            this.datum_rodjenja = p.Datum_rodjenja;
            this.spol = p.Spol;
            this.jmbg = p.Jmbg;
            this.adresa_stanovanja = p.Adresa_stanovanja;
            this.bracno_stanje = p.Bracno_stanje;
            this.bio_u_bolnici_puta = p.Bio_u_bolnici_puta;
            this.ziv = p.Ziv;
            this.dug = p.Dug;
        }
        public void DodajDug(int trosak)
        {
            this.dug += trosak;
        }
    }
}
