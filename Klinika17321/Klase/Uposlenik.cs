using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace KlinikaZadaca17321
{
    public abstract class Uposlenik : IznosPrimanja
    {
        private int id_uposlenika;
        private string ime;
        private int plata_dnevna;
        private string username;
        private string sifra;

        public Uposlenik(string ime, int plata, int id, string username, string sifra)
        {
            this.ime = ime;
            this.plata_dnevna = plata;
            this.id_uposlenika = id;
            this.Username = username;
            this.sifra = ZakodirajSifruKoristeceiMD5(sifra);
        }

        public int Id_uposlenika { get => id_uposlenika; set => id_uposlenika = value; }
        public string Ime { get => ime; set => ime = value; }
        public int Plata_dnevna { get => plata_dnevna; set => plata_dnevna = value; }
        public string Username { get => username; set => username = value; }
        public string Sifra { get => sifra; set => sifra = ZakodirajSifruKoristeceiMD5(value); }
        public abstract Uposlenik DajKopiju();

        public abstract double IznosPlateSaSvimUracunatimDodacima();
        public abstract string IspisiPrimanje();
        
        private string ZakodirajSifruKoristeceiMD5(string sifra)
        {
            string result;
            using (var md5 = MD5.Create())
            {
                byte[] hashmeHashed = md5.ComputeHash(Encoding.UTF8.GetBytes(sifra));
                result = BitConverter.ToString(hashmeHashed).Replace("-", "");
            }
            return result;
        }
    }
}