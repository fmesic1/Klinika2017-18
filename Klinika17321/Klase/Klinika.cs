using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace KlinikaZadaca17321
{
    public partial class Klinika
    {
        public List<Pacijent> KolekcijaPacijenata;
        private List<Karton> KolekcijaKartona;
        public List<Ordinacija> KolekcijaOrdinacija;
        public List<Uposlenik> KolekcijaUposlenih;
        public Klinika()
        {
            KolekcijaPacijenata = new List<Pacijent>();
            KolekcijaKartona = new List<Karton>();
            KolekcijaOrdinacija = new List<Ordinacija>();
            KolekcijaUposlenih = new List<Uposlenik>();

            KolekcijaOrdinacija.Add(new Ordinacija("Opsta Medicina", 1));
            KolekcijaOrdinacija.Add(new Ordinacija("HITNA SLUZBA", 2));
            KolekcijaOrdinacija.Add(new Ordinacija("Ortopedska ordinacija", 3));
            KolekcijaOrdinacija.Add(new Ordinacija("Kardioloska ordinacija", 4));
            KolekcijaOrdinacija.Add(new Ordinacija("Dermatoloska ordinacija", 5));
            KolekcijaOrdinacija.Add(new Ordinacija("Internisticka ordinacija", 6));
            KolekcijaOrdinacija.Add(new Ordinacija("Otorinolaringoloska ordinacija", 7));
            KolekcijaOrdinacija.Add(new Ordinacija("Oftamoloska ordinacija", 8));
            KolekcijaOrdinacija.Add(new Ordinacija("Laboratorijska ordinacija", 9));
            KolekcijaOrdinacija.Add(new Ordinacija("Stomatoloska ordinacija", 10));
            KolekcijaOrdinacija.Add(new Ordinacija("Hirurska ordinacija", 11));
            // sad dodam doktore; id doktora pocinje od [121
            KolekcijaUposlenih.Add(new Doktor("Prof. dr. Music Mirza dipl. ing. el.", 300, 121, 30, 1, "doc", "docpw"));
            KolekcijaUposlenih.Add(new Doktor("Hamo Hofman sa Hitne", 250, 122, 25, 2, "doktor2", "doktor2"));
            KolekcijaUposlenih.Add(new Doktor("Za noge majstor, prva klasa", 320, 123, 32, 3, "doktor3", "doktor3"));
            KolekcijaUposlenih.Add(new Doktor("Za srce onaj, ako se ne varam ?", 700, 124, 120, 4, "doktor4", "doktor4"));
            KolekcijaUposlenih.Add(new Doktor("Ibro Dermatolog", 400, 125, 40, 5, "doktor5", "doktor5"));
            KolekcijaUposlenih.Add(new Doktor("Internista", 680, 126, 68, 6, "doktor6", "doktor6"));
            KolekcijaUposlenih.Add(new Doktor("Safet", 200, 127, 10, 7, "doktor7", "doktor7"));
            KolekcijaUposlenih.Add(new Doktor("Enver Oftamolog", 220, 128, 35, 8, "doktor8", "doktor8"));
            KolekcijaUposlenih.Add(new Doktor("Laboratorista", 170, 129, 23, 9, "doktor9", "doktor9"));
            KolekcijaUposlenih.Add(new Doktor("Ismet Dizdarevic", 600, 130, 30, 10, "doktor10", "doktor10"));
            KolekcijaUposlenih.Add(new Doktor("Miro sa hirurgije", 1000, 131, 300, 11, "doktor11", "doktor11"));
            // sad dodam uposlene, id tehnicara pocinje od [200
            KolekcijaUposlenih.Add(new Tehnicar("Toni", 600, 200, "teh1", "teh1"));
            KolekcijaUposlenih.Add(new Tehnicar("Besa", 600, 201, "tehnicar2", "tehnicar2"));
            //sad dodam uprave, dosta 1 covjek, id = 1
            KolekcijaUposlenih.Add(new Uprava("Mesic Ferhad", 15000, 1, "uprava1", "uprava1"));
            //dodati i jednog pacijenta, na racun kuce
            Pacijent p = new Pacijent("Probni", "pacijent", DateTime.Now, "1111222233334", 1, "ulica Zaboravljenih osoba bb", "Nerealno");
            KolekcijaPacijenata.Add(p);
            KolekcijaKartona.Add(new Karton(p, "dobar", "dobar", "dobar"));
        }
        public void RegistrujPacijenta()
        {
            //ova se metoda poziva samo kada je hitan slucaj odnosno kada ne znamo nista o pacijentu
            Pacijent hitan = new Pacijent();
            KolekcijaPacijenata.Add(hitan);
            Karton noviKarton = new Karton(hitan, "", "", "");
            KolekcijaKartona.Add(noviKarton);
            KolekcijaOrdinacija.Find(x => x.Id_ordinacije == 2).Raspored_pregleda.Add(noviKarton);
        }
        public void RegistrujPacijenta(Pacijent p)
        {
            KolekcijaPacijenata.Add(p);
        }
        public void RegistrujPacijenta(string ime, string prezime, DateTime datum_rodjenja, string maticni, int spol, string adresa_stanovanja, string bracno_stanje)
        {
            Pacijent p = new Pacijent(ime, prezime, datum_rodjenja, maticni, spol, adresa_stanovanja, bracno_stanje);
            KolekcijaPacijenata.Add(p);
        }
        public bool ObrisiPacijenta(string jmbg)
        {
            if (KolekcijaKartona.Exists(x => x.Jmbg == jmbg))
            {
                KolekcijaKartona.Remove(KolekcijaKartona.Find(x => x.Jmbg == jmbg));
                return true;
            }
            return false;
        }
        public void RegistrujKarton(Pacijent p, string sadasnjeBolesti, string ranijeBolesti, string zdravljePorodice)
        {
            KolekcijaKartona.Add(new Karton(p, sadasnjeBolesti, ranijeBolesti, zdravljePorodice));
        }
        public void RegistrujKarton(Karton k)
        {
            KolekcijaKartona.Add(k);
        }
        public bool KoristioKlinikuPrije(string maticni)
        {
            if (KolekcijaPacijenata.Exists(x => x.Jmbg == maticni))
                return true;
            return false;
        }
        public bool ImaLiKarton(string maticni)
        {
            // NESTO zeza, NE RADI KAKO TREBA
            //UPDATE : radi ono kako treba vjrv ALI je problem to sto nije registrovan karton nigdje 
            //pa i ne moze vratiti sta se ocekuje.
            if (KolekcijaKartona.Exists(x => x.Jmbg == maticni))
                return true;
            return false;
        }
        public Pacijent DajPacijenta(string maticni)
        {
            return KolekcijaPacijenata.Find(x => x.Jmbg == maticni);
        }
        public Karton DajKarton(string maticni)
        {
            Pacijent novi = new Pacijent();
            Karton a = new Karton(novi, "", "", "");
            if (KolekcijaKartona.Find(x => x.Jmbg == maticni) != null)
                return KolekcijaKartona.Find(x => x.Jmbg == maticni);
            return a;
        }
        public Ordinacija DajOrdinaciju(int idOrd)
        {
            return KolekcijaOrdinacija.Find(x => x.Id_ordinacije == idOrd);
        }
        public string IspisiKarton(string jmbg)
        {
            Karton k = KolekcijaKartona.Find(x => x.Jmbg == jmbg);
            string info = "\nInformacije o pacijentu: " + "\nIme: " + k.Ime + "\nPrezime: " + k.Prezime;
            info += "\nDatum rodjenja: " + k.Datum_rodjenja;
            info += "\nJMBG: " + jmbg;
            if (k.Spol == 1) info += "\nSpol : musko";
            else info += "\nSpol : zensko";
            info += "\nAdresa stanovanja: " + k.Adresa_stanovanja;
            info += "\nBracno stanje: " + k.Bracno_stanje;
            info += "\nSadasnja bolest i alergija: " + k.Sadasnja_bolest_i_alergija;
            info += "\nRanija bolest i alergija: " + k.Ranija_bolest_i_alergija;
            info += "\nZdravlje porodice: " + k.Zdravlje_porodice;
            for (int i = 0; i < k.DajBrojZavrsenihPregleda(); i++)
            {
                info += "\nInformacije o pregledu {0}. :" + i;
                info += "\nDatum prijema: " + k.Datum_prijema[i];
                info += "\nZakljucak doktora: " + k.Zdravlje_porodice[i];
                info += "\nPropisana terapija: " + k.Propisana_terapija[i];
                info += "\nDatum propisivanja terapije: " + k.Datum_propisivanja_terapije[i] + "\n";
            }
            return info;
        }
        public bool JeLiAktivnaOrdinacija(int id)
        {
            if (!KolekcijaOrdinacija.Find(x => x.Id_ordinacije == id).Aparatura_ispravna||
                !KolekcijaOrdinacija.Find(x => x.Id_ordinacije == id).Doktor_unutra)
                return false;
            return true;
        }
        public void RegistrujPregled(Karton k, int id_ord)
        {
            KolekcijaOrdinacija.Find(x => x.Id_ordinacije == id_ord).DodajPregled(k);
            k.Raspored_za_preglede.Add(id_ord);
        }
        public void RegistrujPreglede(Karton k, List<int> ordinacije)
        {
            for (int i = 0; i < ordinacije.Count; i++)
            {
                KolekcijaOrdinacija.Find(x => x.Id_ordinacije == ordinacije[i]).DodajPregled(k);
                k.Raspored_za_preglede.Add(ordinacije[i]);
            }
        }
        public Pacijent DajNajPacijenta()
        {
            Pacijent max = new Pacijent();
            if (KolekcijaPacijenata.Count > 0)
                max = KolekcijaPacijenata[0];
            foreach(Pacijent p in KolekcijaPacijenata)
            {
                if (p.Dug > max.Dug)
                    max = p;
            }
            return max;
        }
        public int DajBrojRegistrovanihPacijenata()
        {
            return KolekcijaPacijenata.Count;
        }
        public int DajBrojUmrlih()
        {
            int umrlih = 0;
            foreach (Pacijent p in KolekcijaPacijenata)
                if (p.Ziv == 2)
                    umrlih++;
            return umrlih;
        }
        public int DajBrojMuskihPacijenata()
        {
            int muskih = 0;
            foreach (Pacijent p in KolekcijaPacijenata)
                if (p.Spol == 1)
                    muskih++;
            return muskih;
        }
        public Karton DajKarton(int idOrd)
        {
            return KolekcijaOrdinacija[idOrd - 1].Raspored_pregleda[0];
        }
        public int DajBrojPacijenataKojiCekajuIspred(int idOrd)
        {
            return KolekcijaOrdinacija[idOrd - 1].Raspored_pregleda.Count;
        }
        public Doktor DajDoktora(int idOrd)
        {
            return KolekcijaUposlenih.Where(t => t is Doktor).Select(t => t as Doktor).ToList().Find(t => t.Id_ordinacije_u_kojoj_radi == idOrd);
        }
        public Doktor DajDoktora(string username)
        {
            return KolekcijaUposlenih.Where(t => t is Doktor).Select(t => t as Doktor).ToList().Find(t => t.Username == username);
        }

        public void UkloniPacijentaIzHitne(int idOrd)
        {
            KolekcijaOrdinacija.Find(x => x.Id_ordinacije == idOrd).Raspored_pregleda.RemoveAt(0);
        }
        public void UkloniPacijentaIzOrdinacije(int idOrd, string jmbg)
        {
            KolekcijaOrdinacija.Find(x => x.Id_ordinacije == idOrd).Raspored_pregleda.RemoveAt(0);
            KolekcijaKartona.Find(x => x.Jmbg == jmbg).Raspored_za_preglede.RemoveAt(0);
        }
        public bool JeLiKoristen(int broj, string jmbg)
        {
            for (int i = 0; i < KolekcijaKartona.Find(x => x.Jmbg == jmbg).Raspored_za_preglede.Count(); i++)
                    if (KolekcijaKartona.Find(x => x.Jmbg == jmbg).Raspored_za_preglede[0] == broj)
                        return false;
            return true;
        }


        public void DoktorAktivanNeaktivan(int idOrdinacije)
        {
            if (KolekcijaOrdinacija.Find(x => x.Id_ordinacije == idOrdinacije).Doktor_unutra)
                KolekcijaOrdinacija.Find(x => x.Id_ordinacije == idOrdinacije).Doktor_unutra = false;
            else KolekcijaOrdinacija.Find(x => x.Id_ordinacije == idOrdinacije).Doktor_unutra = true;
        }
        public void AparaturaIspravna(int idOrd)
        {
            if (KolekcijaOrdinacija.Find(x => x.Id_ordinacije == idOrd).Aparatura_ispravna)
                KolekcijaOrdinacija.Find(x => x.Id_ordinacije == idOrd).Aparatura_ispravna = false;
            else KolekcijaOrdinacija.Find(x => x.Id_ordinacije == idOrd).Aparatura_ispravna = true;
        }
        public void DodajOrdinaciju(string ime, int idOrd)
        {
            KolekcijaOrdinacija.Add(new Ordinacija(ime, idOrd));
        }
        public void NajviseZaradio()
        {
            Uposlenik max = KolekcijaUposlenih[0];
            foreach(Uposlenik u in KolekcijaUposlenih)
            {
                if (u.IznosPlateSaSvimUracunatimDodacima() > max.IznosPlateSaSvimUracunatimDodacima())
                    max = u;
            }
            Console.WriteLine(max.IspisiPrimanje());
        }
        public bool PostojiLiTehnicar(string username, string sifra)
        {
            // PRVO JE POTREBNO KODIRATI OVU SIFRU KORISTECI MD5 PA JE POSLATI JER SE SIFRE CUVAJU KODIRANE U KLASI Uposlenik
            if (KolekcijaUposlenih.Where(t => t is Tehnicar).Select(t => t as Tehnicar).ToList().Exists(t => t.Username == username && t.Sifra == ZakodirajSifruKoristeceiMD5(sifra)))
                return true;
            return false;
        }
        public bool PostojiLiDoktor(string username, string sifra)
        {
            // PRVO JE POTREBNO KODIRATI OVU SIFRU KORISTECI MD5 PA JE POSLATI JER SE SIFRE CUVAJU KODIRANE U KLASI Uposlenik

            if (KolekcijaUposlenih.Where(t => t is Doktor).Select(t => t as Doktor).ToList().Exists(t => t.Username == username && t.Sifra == ZakodirajSifruKoristeceiMD5(sifra)))
                return true;
            return false;
        }
        public bool PostojiLiUprava(string username, string sifra)
        {
            // PRVO JE POTREBNO KODIRATI OVU SIFRU KORISTECI MD5 PA JE POSLATI JER SE SIFRE CUVAJU KODIRANE U KLASI Uposlenik
            if (KolekcijaUposlenih.Where(t => t is Uprava).Select(t => t as Uprava).ToList().Exists(t => t.Username == username && t.Sifra == ZakodirajSifruKoristeceiMD5(sifra)))
                return true;
            return false;
        }
        public bool PostojiLiTeh(string username)
        {
            if (KolekcijaUposlenih.Where(t => t is Tehnicar).Select(t => t as Tehnicar).ToList().Exists(t => t.Username == username))
                return true;
            return false;
        }
        public bool PostojiLiDok(string username)
        {
            if (KolekcijaUposlenih.Where(t => t is Doktor).Select(t => t as Doktor).ToList().Exists(t => t.Username == username))
                return true;
            return false;
        }
        public bool PostojiLiUpr(string username)
        {
            if (KolekcijaUposlenih.Where(t => t is Uprava).Select(t => t as Uprava).ToList().Exists(t => t.Username == username))
                return true;
            return false;
        }
        public Tehnicar DajTehnicara(string username)
        {
            return KolekcijaUposlenih.Where(t => t is Tehnicar).Select(t => t as Tehnicar).ToList().Find(t => t.Username == username);
        }
        
        public Uprava DajUpravu(string username)
        {
            return KolekcijaUposlenih.Where(t => t is Uprava).Select(t => t as Uprava).ToList().Find(t => t.Username == username);
        }
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

        public void RegistrujDoktora(string ime, int plata, int id, int cijenaUsluga, int idOrd, string username, string sifra)
        {
            KolekcijaUposlenih.Add(new Doktor(ime, plata, id, cijenaUsluga, idOrd, username, sifra));
        }
    }
}
