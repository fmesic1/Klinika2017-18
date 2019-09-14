using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlinikaZadaca17321;
using System.Text.RegularExpressions;

namespace Klinika17321
{
    public partial class UpravaForma : Form
    {
        public UpravaForma()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 800;
            this.Height = 700;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Visible = true;
            chart1.Visible = false;
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add("Uposleni u upravi");
            treeView1.Nodes.Add("Doktori");
            treeView1.Nodes.Add("Tehnicari");
            
            for(int i = 0; i < Login.k.KolekcijaUposlenih.Count; i++)
            {
                if (Login.k.KolekcijaUposlenih[i] is Doktor)
                {
                    string ime = "";
                    ime += Login.k.KolekcijaUposlenih[i].Ime + " " + Login.k.KolekcijaUposlenih[i].Id_uposlenika;
                    treeView1.Nodes[1].Nodes.Add(ime);
                }
                else if (Login.k.KolekcijaUposlenih[i] is Uprava)
                    treeView1.Nodes[0].Nodes.Add(Login.k.KolekcijaUposlenih[i].Ime + " " + Login.k.KolekcijaUposlenih[i].Id_uposlenika);
                else if (Login.k.KolekcijaUposlenih[i] is Tehnicar)
                    treeView1.Nodes[2].Nodes.Add(Login.k.KolekcijaUposlenih[i].Ime + " " + Login.k.KolekcijaUposlenih[i].Id_uposlenika);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            treeView1.Visible = true;
            chart1.Visible = false;
            treeView1.Nodes.Add("Muski pacijenti");
            treeView1.Nodes.Add("Zenski pacijenti");
            for(int i = 0; i < Login.k.KolekcijaPacijenata.Count; i++)
            {
                if (Login.k.KolekcijaPacijenata[i].Spol == 1)
                    treeView1.Nodes[0].Nodes.Add(Login.k.KolekcijaPacijenata[i].Ime);
                else treeView1.Nodes[1].Nodes.Add(Login.k.KolekcijaPacijenata[i].Ime);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            treeView1.Visible = false;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            for (int i = 0; i < Login.k.KolekcijaOrdinacija.Count; i++)
            {
                double suma = 0;
                int brRadnikaUord = 0;
                for (int j = 0; j < Login.k.KolekcijaUposlenih.Count; j++)
                    if (Login.k.KolekcijaUposlenih[j] is Doktor && Login.k.DajDoktora(Login.k.KolekcijaUposlenih[i].Username).Id_ordinacije_u_kojoj_radi == Login.k.KolekcijaOrdinacija[i].Id_ordinacije)
                    {
                        suma += Login.k.DajDoktora(Login.k.KolekcijaUposlenih[i].Username).Cijena_njegovih_usluga;
                        brRadnikaUord++;
                    }
                suma /= brRadnikaUord;
                chart1.Series["prosjecnePlate"].Points.AddXY(Login.k.KolekcijaOrdinacija[i].Ime, suma);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dadadaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            RestartujErrorProvajdere();
            if (!Validiraj()) return;
            int prvi;
            int.TryParse(richTextBox5.Text, out prvi);
            int drugi;
            int.TryParse(richTextBox1.Text, out drugi);
            int treci;
            int.TryParse(richTextBox6.Text, out treci);
            int cetvrti;
            int.TryParse(richTextBox1.Text, out cetvrti);
            Login.k.RegistrujDoktora(richTextBox9.Text, prvi, drugi, treci, cetvrti, richTextBox2.Text, richTextBox3.Text);
            MessageBox.Show("Novi doktor uspjesno registrovan!", "Uspjesna registracija", MessageBoxButtons.OK);
        }

        private bool Validiraj()
        {
            bool sveUredu = true;
            int num;
            if(richTextBox9.Text == String.Empty)
            {
                errorProvider1.SetError(richTextBox9, "Ime mora biti navedeno!");
                sveUredu = false;
            }
            else if(Regex.IsMatch(richTextBox9.Text, @"\d"))
            {
                errorProvider1.SetError(richTextBox9, "Ime mora sadrzavati samo slova!");
                sveUredu = false;
            }

            if(richTextBox1.Text == String.Empty)
            {
                errorProvider2.SetError(richTextBox1, "Id uposlenika mora biti naveden!");
                sveUredu = false;
            }
            else if (!int.TryParse(richTextBox1.Text, out num))
            {
                errorProvider2.SetError(richTextBox1, "Id uposlenika mora sadrzavati samo brojeve!");
                sveUredu = false;
            }
            else if (Login.k.KolekcijaUposlenih.Where(t => t is Uposlenik).Select(t=> t as Uposlenik).ToList().Exists(t => t.Id_uposlenika == num))
            {
                errorProvider2.SetError(richTextBox1, "Id uposlenika koji je unesen vec koristi neko drugi!");
                sveUredu = false;
            }

            if (richTextBox2.Text == String.Empty)
            {
                errorProvider3.SetError(richTextBox2, "Username mora biti naveden!");
                sveUredu = false;
            }
            else if (Login.k.KolekcijaUposlenih.Where(t => t is Uposlenik).Select(t => t as Uposlenik).ToList().Exists(t => t.Username == richTextBox2.Text))
            {
                errorProvider3.SetError(richTextBox1, "Navedeni username vec koristi neko drugi!");
                sveUredu = false;
            }

            if (richTextBox3.Text == String.Empty)
            {
                errorProvider4.SetError(richTextBox3, "Sifra mora biti naveden!");
                sveUredu = false;
            }

            if (richTextBox4.Text == String.Empty)
            {
                errorProvider5.SetError(richTextBox4, "Obavezno potvrditi sifru!");
                sveUredu = false;
            }
            else if (richTextBox3.Text != richTextBox4.Text)
            {
                errorProvider4.SetError(richTextBox3, "Sifre nisu iste");
                errorProvider5.SetError(richTextBox4, "Sifre nisu iste");
                sveUredu = false;
            }

            if(richTextBox5.Text == String.Empty)
            {
                errorProvider6.SetError(richTextBox5, "Morate navesti platu");
                sveUredu = false;
            }
            else if (!int.TryParse(richTextBox5.Text, out num))
            {
                errorProvider6.SetError(richTextBox5, "Plata mora biti cjelobrojna vrijednost!");
                sveUredu = false;
            }

            if (richTextBox6.Text == String.Empty)
            {
                errorProvider7.SetError(richTextBox6, "Morate navesti cijenu njegovih usluga!");
                sveUredu = false;
            }
            else if (!int.TryParse(richTextBox6.Text, out num))
            {
                errorProvider7.SetError(richTextBox6, "Cijena usluga mora biti cjelobrojna vrijednost!");
                sveUredu = false;
            }

            if (richTextBox7.Text == String.Empty)
            {
                errorProvider8.SetError(richTextBox7, "Morate navesti id ordinacije u kojoj ce doktor raditi!");
                sveUredu = false;
            }
            else if (!int.TryParse(richTextBox6.Text, out num))
            {
                errorProvider8.SetError(richTextBox7, "Id ordinacije mora biti cjelobrojna vrijednost!");
                sveUredu = false;
            }
            else if(!Login.k.KolekcijaOrdinacija.Exists(ord => ord.Id_ordinacije == num))
            {
                errorProvider8.SetError(richTextBox7, "Ne postoji ordinacija sa navedenim id-om, IDovi ordinacija su u opsegu [1,11]");
                sveUredu = false;
            }
            return sveUredu;
        }
        private void RestartujErrorProvajdere()
        {
            errorProvider1.SetError(richTextBox9, "");
            errorProvider2.SetError(richTextBox1, "");
            errorProvider3.SetError(richTextBox2, "");
            errorProvider4.SetError(richTextBox3, "");
            errorProvider5.SetError(richTextBox4, "");
            errorProvider6.SetError(richTextBox5, "");
            errorProvider7.SetError(richTextBox6, "");
            errorProvider8.SetError(richTextBox7, "");
        }

        private void doktoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel1.Hide();
        }

        private void analizaRadaKlinikeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
        }
        
        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login nova = new Login();
            nova.Show();
        }
    }

}
