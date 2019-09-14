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
    public partial class DoktorForma : Form
    {
        public DoktorForma()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 800;
            this.Height = 700;
            this.MaximizeBox = false;
        }
        
        //Odjava button
        private void button2_Click(object sender, EventArgs e)
        {
            Login nova = new Login();
            nova.Show();
            this.Hide();
        }

        //Tab gdje je Red cekanja
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
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

        //Button Potvrdi, kada se unese JMBG
        private void button11_Click(object sender, EventArgs e)
        {
            if (!ValidirajUlaz()) return;
            if (!Login.k.KoristioKlinikuPrije(richTextBox12.Text))
                statusStripLogin.Text = "Pacijent ciji je JMBG unesen nije korisnik klinike";
            else if (Login.k.DajKarton(richTextBox12.Text).Raspored_za_preglede.Exists(x => x == Login.prijavljeniDoktor.Id_ordinacije_u_kojoj_radi))
            {
                //prikazi i omoguci editovanje
                panel1.Show();
                groupBox1.Visible = true;
                PopuniInfoOPacijentu();
                JMBGPretraga.Hide();
            }
            else
            {
                //prikazi ali nemoj omoguciti editovanje
                panel1.Show();
                JMBGPretraga.Hide();
                richTextBox9.ReadOnly = true;
                richTextBox15.ReadOnly = true;
                groupBox1.Visible = true;
                PopuniInfoOPacijentu();
                MessageBox.Show("Pacijent ciji je JMBG unesen nema registrovan pregled ali se informacije o njemu mogu vidjeti!", "NEMA REGISTROVAN PREGLED", MessageBoxButtons.OK);
            }
        }

        private void PopuniInfoOPacijentu()
        {
            richTextBox2.Text = Login.k.DajPacijenta(richTextBox12.Text).Ime;
            richTextBox3.Text = Login.k.DajPacijenta(richTextBox12.Text).Prezime;
            richTextBox1.Text = Login.k.DajPacijenta(richTextBox12.Text).Datum_rodjenja.ToString("dd/MM/yyyy");
            richTextBox4.Text = Login.k.DajPacijenta(richTextBox12.Text).Jmbg;
            if(Login.k.DajPacijenta(richTextBox12.Text).Spol == 1)
                richTextBox5.Text = "Musko";
            else richTextBox5.Text = "Zensko";
            richTextBox6.Text = Login.k.DajPacijenta(richTextBox12.Text).Adresa_stanovanja;
            richTextBox7.Text = Login.k.DajPacijenta(richTextBox12.Text).Bracno_stanje;
            richTextBox10.Text = Login.k.DajKarton(richTextBox12.Text).Sadasnja_bolest_i_alergija;
            richTextBox13.Text = Login.k.DajKarton(richTextBox12.Text).Ranija_bolest_i_alergija;
            richTextBox11.Text = Login.k.DajKarton(richTextBox12.Text).Zdravlje_porodice;

            string zakljucakDoktora = "";
            for (int i = 0; i < Login.k.DajKarton(richTextBox12.Text).Zakljucak_doktora.Count; i++)
                zakljucakDoktora += "Zakljucak " + (i + 1) + ": " + Login.k.DajKarton(richTextBox12.Text).Zakljucak_doktora[i];
            if (zakljucakDoktora == "")
                richTextBox9.Text = "Pacijent nikad nije pregledan";
            else richTextBox9.Text = zakljucakDoktora;

            string propisanaTerapija = "";
            for (int i = 0; i < Login.k.DajKarton(richTextBox12.Text).Propisana_terapija.Count; i++)
                propisanaTerapija += "Terapija " + (i + 1) + ": " + Login.k.DajKarton(richTextBox12.Text).Propisana_terapija[i];
            if (propisanaTerapija == "")
                richTextBox15.Text = "Pacijent nikad nije pregledan";
            else richTextBox15.Text = propisanaTerapija;
        }
        //Button Zavrsi sa Pacijentom
        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox9.ReadOnly)
            {
                panel1.Hide();
                JMBGPretraga.Show();
            }
            else
            {
                Login.k.DajKarton(richTextBox12.Text).Zakljucak_doktora.Add(richTextBox9.Text);
                Login.k.DajKarton(richTextBox12.Text).Propisana_terapija.Add(richTextBox15.Text);
                MessageBox.Show("Uspjesno azurirane informacije o pacijentu", "Azurirano", MessageBoxButtons.OK);
                richTextBox12.Show();
                panel1.Hide();
                JMBGPretraga.Show();
                Login.k.DajOrdinaciju(Login.prijavljeniDoktor.Id_ordinacije_u_kojoj_radi).Raspored_pregleda.Remove(Login.k.DajKarton(richTextBox12.Text));
                Login.k.DajKarton(richTextBox12.Text).Raspored_za_preglede.Remove(Login.prijavljeniDoktor.Id_ordinacije_u_kojoj_radi);
                richTextBox12.Text = "";
            }
        }
        
        private bool ValidirajUlaz()
        {
            if (richTextBox12.Text == String.Empty)
            {
                errorProvider1.SetError(richTextBox12, "Polje ne moze biti prazno!");
                return false;
            }
            else if (!richTextBox12.Text.All(c => char.IsDigit(c)))
            {
                errorProvider1.SetError(richTextBox12, "JMBG mora sadrzavati samo cjelobrojne vrijednosti!");
                return false;
            }
            else if (richTextBox12.Text.Length != 13)
            {
                errorProvider1.SetError(richTextBox12, "JMBG mora sadrzavati 13 cifara");
                return false;
            }
            else errorProvider1.SetError(richTextBox12, "");
            return true;
            
        }
    }
}
