using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikaZadaca17321
{
    sealed public class Karton : Pacijent
    {
        private List<DateTime> datum_prijema;
        private string sadasnja_bolest_i_alergija;
        private string ranija_bolest_i_alergija;
        private string zdravlje_porodice;
        private List<string> zakljucak_doktora;
        private List<string> propisana_terapija;
        private List<DateTime> datum_propisivanja_terapije;
        private List<int> raspored_za_preglede;
        private string prva_pomoc;
        private string razlog_prve_pomoci;
        private DateTime vrijeme_smrti;
        private string uzrok_smrti;
        private DateTime obdukcija;
        private List<int> koristeno;

        public string Sadasnja_bolest_i_alergija { get => sadasnja_bolest_i_alergija; set => sadasnja_bolest_i_alergija = value; }
        public string Ranija_bolest_i_alergija { get => ranija_bolest_i_alergija; set => ranija_bolest_i_alergija = value; }
        public string Zdravlje_porodice { get => zdravlje_porodice; set => zdravlje_porodice = value; }
        public List<DateTime> Datum_prijema { get => datum_prijema; set => datum_prijema = value; }
        public List<string> Zakljucak_doktora { get => zakljucak_doktora; set => zakljucak_doktora = value; }
        public List<string> Propisana_terapija { get => propisana_terapija; set => propisana_terapija = value; }
        public List<DateTime> Datum_propisivanja_terapije { get => datum_propisivanja_terapije; set => datum_propisivanja_terapije = value; }
        public List<int> Raspored_za_preglede { get => raspored_za_preglede; set => raspored_za_preglede = value; }
        public string Prva_pomoc { get => prva_pomoc; set => prva_pomoc = value; }
        public string Razlog_prve_pomoci { get => razlog_prve_pomoci; set => razlog_prve_pomoci = value; }
        public DateTime Vrijeme_smrti { get => vrijeme_smrti; set => vrijeme_smrti = value; }
        public string Uzrok_smrti { get => uzrok_smrti; set => uzrok_smrti = value; }
        public DateTime Obdukcija { get => obdukcija; set => obdukcija = value; }
        public List<int> Koristeno { get => koristeno; set => koristeno = value; }

        public Karton(Pacijent p, string sadasnjeBolesti, string ranijeBolesti, string stanjePorodice) : base(p)
        {
            datum_prijema = new List<DateTime>();
            datum_prijema.Add(DateTime.Today);
            Sadasnja_bolest_i_alergija = sadasnjeBolesti;
            Ranija_bolest_i_alergija = ranijeBolesti;
            Zdravlje_porodice = stanjePorodice;
            zakljucak_doktora = new List<string>();
            propisana_terapija = new List<string>();
            datum_propisivanja_terapije = new List<DateTime>();
            raspored_za_preglede = new List<int>();
            prva_pomoc = "/";
            razlog_prve_pomoci = "/";
            uzrok_smrti = "/";
            koristeno = new List<int>();
        }
        public int DajBrojZavrsenihPregleda()
        {
            int broj;
            if (!Zakljucak_doktora.Any())
                broj = 0;
            else broj = zakljucak_doktora.Count();
            return broj;
        }

    }
}
