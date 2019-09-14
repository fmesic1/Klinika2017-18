using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikaZadaca17321
{
    public class Ordinacija
    {
        private string ime;
        private bool doktor_unutra;
        private bool aparatura_ispravna;
        private List<Karton> raspored_pregleda;
        private int id_ordinacije;


        public string Ime { get => ime; set => ime = value; }
        public bool Doktor_unutra { get => doktor_unutra; set => doktor_unutra = value; }
        public bool Aparatura_ispravna { get => aparatura_ispravna; set => aparatura_ispravna = value; }
        public int Id_ordinacije { get => id_ordinacije; set => id_ordinacije = value; }
        public List<Karton> Raspored_pregleda { get => raspored_pregleda; set => raspored_pregleda = value; }

        public Ordinacija(string ime, int id)
        {
            this.ime = ime;
            doktor_unutra = aparatura_ispravna = true;
            raspored_pregleda = new List<Karton>();
            this.id_ordinacije = id;
        }
        public void DodajPregled(Karton k)
        {
            raspored_pregleda.Add(k);
        }
        public int DajBrojPregleda()
        {
            if (!raspored_pregleda.Any())
                return 0;
            return raspored_pregleda.Count();
        }
        
    }
}
