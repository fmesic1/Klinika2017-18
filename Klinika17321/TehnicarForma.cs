using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Klinika17321
{
    public partial class TehnicarForma : Form
    {
        public TehnicarForma()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 800;
            this.Height = 700;
            this.MaximizeBox = false;
            TabRegistruj.Hide();
            ObrisiPacijenta.Hide();
            Raspored.Hide();
        }
        
        private void registrujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabRegistruj.Show();
            ObrisiPacijenta.Hide();
            Raspored.Hide();
        }

        private void obrisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObrisiPacijenta.Show();
            TabRegistruj.Hide();
            Raspored.Hide();
        }

        private void naplatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabRegistruj.Hide();
            Raspored.Hide();
            ObrisiPacijenta.Hide();
        }

        private void prikaziRasporedPregledaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Raspored.Show();
            TabRegistruj.Hide();
            ObrisiPacijenta.Hide();
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
        
        
        
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void TehnicarForma_Load(object sender, EventArgs e)
        {

        }

        private void Raspored_Paint(object sender, PaintEventArgs e)
        {

        }

        //Buttoni za Registruj Pacijenta
        private void button14_Click(object sender, EventArgs e)
        {
            if (!Validiraj4()) return;
            if (Login.k.KoristioKlinikuPrije(richTextBox1.Text))
                statusPrijavaGreske.Text = "Pacijent sa navedenim JMBG vec je registrovan u klinici";
            else if (!Login.k.KoristioKlinikuPrije(richTextBox1.Text))
            {
                panelZaUnosJMBG.Hide();
                InfoOPacijentu.Show();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(richTextBox2, "");
            errorProvider2.SetError(richTextBox3, "");
            errorProvider3.SetError(radioButton2, "");
            errorProvider4.SetError(richTextBox4, "");
            errorProvider5.SetError(richTextBox5, "");

            if(!ValidirajUnesenePodatkeZaNovogPacijenta()) return;
            int spol;
            if (radioButton1.Checked) spol = 1;
            else spol = 2;
            Login.k.RegistrujPacijenta(richTextBox2.Text, richTextBox3.Text, dateTimePicker1.Value, richTextBox1.Text, spol, richTextBox4.Text, richTextBox5.Text);
            MessageBox.Show("Pacijent uspjesno registrovan", "Uspjesna registracija", MessageBoxButtons.OK);

            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            if (radioButton1.Checked) radioButton1.Checked = false;
            if (radioButton2.Checked) radioButton2.Checked = false;
            richTextBox4.Clear();
            richTextBox5.Clear();

            InfoOPacijentu.Hide();
            panelZaUnosJMBG.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            if (radioButton1.Checked) radioButton1.Checked = false;
            if (radioButton2.Checked) radioButton2.Checked = false;
            richTextBox4.Clear();
            richTextBox5.Clear();

            InfoOPacijentu.Hide();
            panelZaUnosJMBG.Show();
        }

        //Buttoni za Registruj Pregled
        private void button10_Click(object sender, EventArgs e)
        {
            if (!Validiraj3()) return;
            if (Login.k.ImaLiKarton(richTextBox14.Text))
            {
                // ON KAD KLIKNE ENTER AUTOMATSKI TREBA DA ZABRANI ONE PREGLEDE KOJI SU VEC REGISTROVANI
                
                if (Login.k.DajKarton(richTextBox14.Text).Raspored_za_preglede.Exists(x => x == 1))
                    checkBox1.Enabled = false;
                else checkBox1.Enabled = true;
                if (Login.k.DajKarton(richTextBox14.Text).Raspored_za_preglede.Exists(x => x == 2))
                    checkBox2.Enabled = false;
                else checkBox2.Enabled = true;
                if (Login.k.DajKarton(richTextBox14.Text).Raspored_za_preglede.Exists(x => x == 3))
                    checkBox3.Enabled = false;
                else checkBox3.Enabled = true;
                if (Login.k.DajKarton(richTextBox14.Text).Raspored_za_preglede.Exists(x => x == 4))
                    checkBox4.Enabled = false;
                else checkBox4.Enabled = true;
                if (Login.k.DajKarton(richTextBox14.Text).Raspored_za_preglede.Exists(x => x == 5))
                    checkBox5.Enabled = false;
                else checkBox5.Enabled = true;
                if (Login.k.DajKarton(richTextBox14.Text).Raspored_za_preglede.Exists(x => x == 6))
                    checkBox6.Enabled = false;
                else checkBox6.Enabled = true;
                if (Login.k.DajKarton(richTextBox14.Text).Raspored_za_preglede.Exists(x => x == 7))
                    checkBox7.Enabled = false;
                else checkBox7.Enabled = true;
                if (Login.k.DajKarton(richTextBox14.Text).Raspored_za_preglede.Exists(x => x == 8))
                    checkBox8.Enabled = false;
                else checkBox8.Enabled = true;
                if (Login.k.DajKarton(richTextBox14.Text).Raspored_za_preglede.Exists(x => x == 9))
                    checkBox9.Enabled = false;
                else checkBox9.Enabled = true;
                if (Login.k.DajKarton(richTextBox14.Text).Raspored_za_preglede.Exists(x => x == 10))
                    checkBox10.Enabled = false;
                else checkBox10.Enabled = true;
                if (Login.k.DajKarton(richTextBox14.Text).Raspored_za_preglede.Exists(x => x == 11))
                    checkBox11.Enabled = false;
                else checkBox11.Enabled = true;

                panel3.Hide();
                panel1.Show();
            }
            else if (!Login.k.ImaLiKarton(richTextBox14.Text))
            {
                toolStripStatusLabel1.Text = "Pacijent sa navedenim JMBG nema registrovan karton u klinici";
                richTextBox14.Clear();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            richTextBox14.Clear();
            panel1.Hide();
            panel3.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            List<int> pregledi = new List<int>();
            
            if (checkBox1.Checked) pregledi.Add(1);
            if (checkBox2.Checked) pregledi.Add(2);
            if (checkBox3.Checked) pregledi.Add(3);
            if (checkBox4.Checked) pregledi.Add(4);
            if (checkBox5.Checked) pregledi.Add(5);
            if (checkBox6.Checked) pregledi.Add(6);
            if (checkBox7.Checked) pregledi.Add(7);
            if (checkBox8.Checked) pregledi.Add(8);
            if (checkBox9.Checked) pregledi.Add(9);
            if (checkBox10.Checked) pregledi.Add(10);
            if (checkBox11.Checked) pregledi.Add(11);

            Login.k.RegistrujPreglede(Login.k.DajKarton(richTextBox14.Text), pregledi);
            MessageBox.Show("Pregledi uspjesno registrovani", "Registracija pregleda", MessageBoxButtons.OK);

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            

            panel1.Hide();
            panel3.Show();
        }

        //Buttoni za Registruj Karton
        private void button13_Click_1(object sender, EventArgs e)
        {
            if (!Validiraj2()) return;
            if (Login.k.ImaLiKarton(richTextBox10.Text))
                statusPrijavaGreske.Text = "Pacijent sa navedenim JMBG vec ima registrovan karton";
            else if (!Login.k.ImaLiKarton(richTextBox10.Text) && !Login.k.KoristioKlinikuPrije(richTextBox10.Text))
                statusPrijavaGreske.Text = "Pacijent sa navedenim JMBG nije registrovan u klinici";
            else if (!Login.k.ImaLiKarton(richTextBox10.Text) && Login.k.KoristioKlinikuPrije(richTextBox10.Text))
            {
                panel4.Hide();
                DodatniPodaciUKartonu.Show();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(richTextBox9, "");
            if(!ValidirajAnamnezu()) return;
            Login.k.RegistrujKarton(Login.k.DajPacijenta(richTextBox10.Text), richTextBox7.Text, richTextBox8.Text, richTextBox9.Text);
            MessageBox.Show("Karton pacijenta uspjesno registrovan!", "Registracija kartona", MessageBoxButtons.OK);
            DodatniPodaciUKartonu.Hide();
            richTextBox10.Clear();
            panel4.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox7.Clear();
            richTextBox8.Clear();
            richTextBox9.Clear();
            richTextBox10.Clear();
            panel4.Show();
            DodatniPodaciUKartonu.Hide();
        }

        //Buttoni za Brisanje pacijenta
        private void button15_Click(object sender, EventArgs e)
        {
            if (!Validiraj1()) return;
            if (!Login.k.ImaLiKarton(richTextBox6.Text))
                statusPrijavaGreske.Text = "Pacijent sa navedenim JMBG nema registrovan karton u klinici";
            else if (Login.k.ImaLiKarton(richTextBox6.Text))
            {
                if (DialogResult.Yes == MessageBox.Show("Da li ste sigurni da zelite ukloniti pacijenta ciji ste JMBG unijeli?", "Provjera", MessageBoxButtons.YesNo))
                {
                    Login.k.ObrisiPacijenta(richTextBox6.Text);
                    MessageBox.Show("Pacijent uspjesno uklonjen", "Potvrda o brisanju", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Pacijent nije uklonjen iz baze", "Potvrda o brisanju", MessageBoxButtons.OK);
                richTextBox6.Clear();
            }
        }
        
        //Buttoni za prikaz pregleda
        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = "";
            if (!Validiraj()) return;

            if (!Login.k.KoristioKlinikuPrije(richTextBox11.Text))
                toolStripStatusLabel4.Text = "Pacijent sa navedenim JMBG nije koristio kliniku prije";
            else if (!Login.k.ImaLiKarton(richTextBox11.Text))
                toolStripStatusLabel4.Text = "Pacijent sa navedenim JMBG nema registrovan karton u klinici";
            else
            {
                RasporedPregleda.Show();
                string raspored = "Raspored po ordinacijama: ";
                if (Login.k.DajKarton(richTextBox11.Text).Raspored_za_preglede.Count == 0)
                    richTextBox13.Text = "Nema registrovanih pregleda";
                else
                {
                    for (int i = 0; i < Login.k.DajKarton(richTextBox11.Text).Raspored_za_preglede.Count; i++)
                    {
                        raspored += Login.k.DajKarton(richTextBox11.Text).Raspored_za_preglede[i].ToString() + "; ";
                    }
                    richTextBox13.Text = raspored;
                }
                richTextBox13.Show();
            }
            richTextBox11.Clear();
        }

        //Odjava Button
        private void button9_Click(object sender, EventArgs e)
        {
            Login nova = new Login();
            this.Hide();
            nova.Show();
        }
        private bool Validiraj()
        {
            if (richTextBox11.Text == String.Empty)
            {
                errorProvider1.SetError(richTextBox11, "Polje ne moze biti prazno");
                return false;
            }
            else if (!richTextBox11.Text.All(c => char.IsDigit(c)))
            {
                errorProvider1.SetError(richTextBox11, "JMBG mora sadrzavati samo cjelobrojne vrijednosti!");
                return false;
            }
            else if (richTextBox11.Text.Length != 13)
            {
                errorProvider1.SetError(richTextBox11, "JMBG mora sadrzavati 13 cifara");
                return false;
            }
            else
            {
                errorProvider1.SetError(richTextBox11, "");
                return true;
            }
        }
        //Ovo kad si glup, kad si idiot, pa moras ovako, al ovo sam skonto da moze drugacije tek nakon 45+ h rada..
        private bool Validiraj1()
        {
            if (richTextBox6.Text == String.Empty)
            {
                errorProvider1.SetError(richTextBox6, "Polje ne moze biti prazno");
                return false;
            }
            else if (!richTextBox6.Text.All(c => char.IsDigit(c)))
            {
                errorProvider1.SetError(richTextBox6, "JMBG mora sadrzavati samo cjelobrojne vrijednosti!");
                return false;
            }
            else if (richTextBox6.Text.Length != 13)
            {
                errorProvider1.SetError(richTextBox6, "JMBG mora sadrzavati 13 cifara");
                return false;
            }
            else
            {
                errorProvider1.SetError(richTextBox6, "");
                return true;
            }
        }
        private bool Validiraj2()
        {
            if (richTextBox10.Text == String.Empty)
            {
                errorProvider1.SetError(richTextBox10, "Polje ne moze biti prazno");
                return false;
            }
            else if (!richTextBox10.Text.All(c => char.IsDigit(c)))
            {
                errorProvider1.SetError(richTextBox10, "JMBG mora sadrzavati samo cjelobrojne vrijednosti!");
                return false;
            }
            else if (richTextBox10.Text.Length != 13)
            {
                errorProvider1.SetError(richTextBox10, "JMBG mora sadrzavati 13 cifara");
                return false;
            }
            else
            {
                errorProvider1.SetError(richTextBox10, "");
                return true;
            }
        }
        private bool Validiraj3()
        {
            if (richTextBox14.Text == String.Empty)
            {
                errorProvider1.SetError(richTextBox14, "Polje ne moze biti prazno");
                return false;
            }
            else if (!richTextBox14.Text.All(c => char.IsDigit(c)))
            {
                errorProvider1.SetError(richTextBox14, "JMBG mora sadrzavati samo cjelobrojne vrijednosti!");
                return false;
            }
            else if (richTextBox14.Text.Length != 13)
            {
                errorProvider1.SetError(richTextBox14, "JMBG mora sadrzavati 13 cifara");
                return false;
            }
            else errorProvider1.SetError(richTextBox14, "");
            return true;
            
        }
        private bool Validiraj4()
        {
            if (richTextBox1.Text == String.Empty)
            {
                errorProvider1.SetError(richTextBox1, "Polje ne moze biti prazno");
                return false;
            }
            else if (!richTextBox1.Text.All(c => char.IsDigit(c)))
            {
                errorProvider1.SetError(richTextBox1, "JMBG mora sadrzavati samo cjelobrojne vrijednosti!");
                return false;
            }
            else if (richTextBox1.Text.Length != 13)
            {
                errorProvider1.SetError(richTextBox1, "JMBG mora sadrzavati 13 cifara");
                return false;
            }
            else errorProvider1.SetError(richTextBox1, "");
            return true;

        }
        private bool ValidirajUnesenePodatkeZaNovogPacijenta()
        {
            bool sveOkej = true;
            //Ime
            if (richTextBox2.Text == String.Empty)
            {
                errorProvider1.SetError(richTextBox2, "Obavezno navesti prezime");
                sveOkej = false;
            }
            else if (Regex.IsMatch(richTextBox2.Text, @"\d"))
            {
                errorProvider1.SetError(richTextBox2, "Ime mora sadrzavati samo slova!");
                sveOkej = false;
            }

            //Prezime
            if (richTextBox3.Text == String.Empty)
            {
                errorProvider2.SetError(richTextBox3, "Obavezno navesti prezime");
                sveOkej = false;
            }
            else if (Regex.IsMatch(richTextBox3.Text, @"\d"))
            {
                errorProvider2.SetError(richTextBox3, "Prezime mora sadrzavati samo slova!");
                sveOkej = false;
            }

            //Spol
            if(!radioButton1.Checked && !radioButton2.Checked)
            {
                errorProvider3.SetError(radioButton2, "Obavezno odabrati spol");
                sveOkej = false;
            }

            //Adresa stanovanja
            if (richTextBox4.Text == String.Empty)
            {
                errorProvider4.SetError(richTextBox4, "Obavezno navesti adresu stanovanja");
                sveOkej = false;
            }

            //Bracno stanje
            if (richTextBox5.Text == String.Empty)
            {
                errorProvider5.SetError(richTextBox5, "Polje ne moze biti prazno");
                sveOkej = false;
            }
            return sveOkej;
        }
        private bool ValidirajAnamnezu()
        {
            if(richTextBox9.Text == String.Empty)
            {
                errorProvider1.SetError(richTextBox9, "Obavezno opisati zdravstveno stanje u porodici");
                return false;
            }
            return true;
        }
    }
}
