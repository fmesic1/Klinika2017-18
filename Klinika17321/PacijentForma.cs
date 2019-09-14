using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinika17321
{
    public partial class PacijentForma : Form
    {
        public PacijentForma()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 800;
            this.Height = 700;
            this.MaximizeBox = false;

            PopuniInfoOPacijentu();
            PopuniListeCekanja();
            PopuniAnamnezu();
            SrediZakazanePreglede();
        }
                
        private void PopuniInfoOPacijentu()
        {
            richTextBox2.Text = Login.k.DajPacijenta(Login.prijavljeniPacijent.Jmbg).Ime;
            richTextBox3.Text = Login.k.DajPacijenta(Login.prijavljeniPacijent.Jmbg).Prezime;
            richTextBox1.Text = Login.k.DajPacijenta(Login.prijavljeniPacijent.Jmbg).Datum_rodjenja.ToString("dd/MM/yyyy");
            richTextBox4.Text = Login.k.DajPacijenta(Login.prijavljeniPacijent.Jmbg).Jmbg;
            if (Login.k.DajPacijenta(Login.prijavljeniPacijent.Jmbg).Spol == 1)
                richTextBox5.Text = "Musko";
            else richTextBox5.Text = "Zensko";
            richTextBox6.Text = Login.k.DajPacijenta(Login.prijavljeniPacijent.Jmbg).Adresa_stanovanja;
            richTextBox7.Text = Login.k.DajPacijenta(Login.prijavljeniPacijent.Jmbg).Bracno_stanje;
        }
        private void PopuniListeCekanja()
        {
            textBox1.Text = Login.k.DajOrdinaciju(1).Raspored_pregleda.Count.ToString();
            textBox10.Text = Login.k.DajOrdinaciju(2).Raspored_pregleda.Count.ToString();
            textBox2.Text = Login.k.DajOrdinaciju(3).Raspored_pregleda.Count.ToString();
            textBox3.Text = Login.k.DajOrdinaciju(4).Raspored_pregleda.Count.ToString();
            textBox4.Text = Login.k.DajOrdinaciju(5).Raspored_pregleda.Count.ToString();
            textBox5.Text = Login.k.DajOrdinaciju(6).Raspored_pregleda.Count.ToString();
            textBox6.Text = Login.k.DajOrdinaciju(7).Raspored_pregleda.Count.ToString();
            textBox7.Text = Login.k.DajOrdinaciju(8).Raspored_pregleda.Count.ToString();
            textBox8.Text = Login.k.DajOrdinaciju(9).Raspored_pregleda.Count.ToString();
            textBox9.Text = Login.k.DajOrdinaciju(10).Raspored_pregleda.Count.ToString();
        }
        private void PopuniAnamnezu()
        {
            if (Login.k.DajKarton(Login.prijavljeniPacijent.Jmbg).Sadasnja_bolest_i_alergija.Length != 0)
                richTextBox9.Text = Login.k.DajKarton(Login.prijavljeniPacijent.Jmbg).Sadasnja_bolest_i_alergija;
            else richTextBox9.Text = "/";
            if (Login.k.DajKarton(Login.prijavljeniPacijent.Jmbg).Ranija_bolest_i_alergija.Length != 0)
                richTextBox10.Text = Login.k.DajKarton(Login.prijavljeniPacijent.Jmbg).Ranija_bolest_i_alergija;
            else richTextBox10.Text = "/";
            if (Login.k.DajKarton(Login.prijavljeniPacijent.Jmbg).Zdravlje_porodice.Length != 0)
                richTextBox11.Text = Login.k.DajKarton(Login.prijavljeniPacijent.Jmbg).Zdravlje_porodice;
            else richTextBox11.Text = "/";

            string zakljucakDoktora = "";
            if (Login.k.DajKarton(Login.prijavljeniPacijent.Jmbg).Zakljucak_doktora.Count != 0)
            {
                for (int i = 0; i < Login.k.DajKarton(Login.prijavljeniPacijent.Jmbg).Zakljucak_doktora.Count; i++)
                    zakljucakDoktora += "Zakljucak " + (i + 1) + ": " + Login.k.DajKarton(Login.prijavljeniPacijent.Jmbg).Zakljucak_doktora[i] + "; ";
                richTextBox12.Text = zakljucakDoktora;
            }
            else richTextBox12.Text = "/";

            string terapija = "";
            if (Login.k.DajKarton(Login.prijavljeniPacijent.Jmbg).Propisana_terapija.Count != 0)
            {
                for (int i = 0; i < Login.k.DajKarton(Login.prijavljeniPacijent.Jmbg).Propisana_terapija.Count; i++)
                    terapija += "Zakljucak " + (i + 1) + ": " + Login.k.DajKarton(Login.prijavljeniPacijent.Jmbg).Propisana_terapija[i] + "; ";
                richTextBox8.Text = terapija;
            }
            else richTextBox8.Text = "/";
        }
        private void SrediZakazanePreglede()
        {
            string pregledi;
            if (Login.k.DajKarton(Login.prijavljeniPacijent.Jmbg).Raspored_za_preglede.Count == 0)
                pregledi = "Pacijent nema zakazanih pregleda";
            else pregledi = "";
            for (int i = 0; i < Login.k.DajKarton(Login.prijavljeniPacijent.Jmbg).Raspored_za_preglede.Count; i++)
                pregledi += Login.k.DajKarton(Login.prijavljeniPacijent.Jmbg).Raspored_za_preglede[i] + "; ";
            richTextBox13.Text = pregledi;
        }

        //Odjava button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login novi = new Login();
            novi.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
