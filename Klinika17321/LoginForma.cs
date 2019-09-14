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

namespace Klinika17321
{
    public partial class Login : Form
    {
        public static Klinika k = new Klinika();

        public static Doktor prijavljeniDoktor;
        public static Tehnicar prijavljeniTehnicar;
        public static Pacijent prijavljeniPacijent;
        public static UpravaForma prijavljenaUprava;

        private bool jmbgDugmePritisnuto = true;
        private bool button2Clicked = false;
        private bool button3Clicked = false;
        private bool button5Clicked = false;

        //Konstruktor
        public Login()
        {   
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 800;
            this.Height = 700;
            this.MaximizeBox = false;
            statusStripLogin.Visible = false;
            SlideA.Hide();
        }

        //Logo
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Brush vanjska = new SolidBrush(Color.SlateGray);
            Brush unutrasnja = new SolidBrush(Color.FromArgb(36,49,60));
            g.FillRectangle(vanjska, 295, 45, 160, 160);
            g.FillRectangle(unutrasnja, 300, 50, 150, 150);
            g.FillRectangle(vanjska, 305, 55, 45, 140);
            g.FillRectangle(vanjska, 400, 55, 45, 140);
            g.FillRectangle(vanjska, 350, 110, 50, 35);

            Pen crvenaLinija = new Pen(Color.FromArgb(179, 0, 0));
            crvenaLinija.Width = 4;
            g.DrawLine(crvenaLinija, 340, 205, 382, 205);
            g.DrawLine(crvenaLinija, 382, 205, 390, 175);
            g.DrawLine(crvenaLinija, 390, 175, 400, 210);
            g.DrawLine(crvenaLinija, 400, 210, 408, 155);
            g.DrawLine(crvenaLinija, 408, 155, 420, 275);
            g.DrawLine(crvenaLinija, 420, 275, 440, 80);
            g.DrawLine(crvenaLinija, 440, 80, 445, 215);
            g.DrawLine(crvenaLinija, 445, 215, 458, 145);
            g.DrawLine(crvenaLinija, 458, 145, 468, 250);
            g.DrawLine(crvenaLinija, 468, 250, 477, 205);
            g.DrawLine(crvenaLinija, 477, 205, 570, 205);

            Brush crvenaCetka = new SolidBrush(Color.FromArgb(179, 0, 0));
            Int32 radius = 7;
            Int32 centerX = 440;
            Int32 centerY = 80;
            g.FillEllipse(crvenaCetka, centerX - radius, centerY - radius, radius + radius, radius + radius);

            g.FillEllipse(crvenaCetka, 333, 198, 14, 14);
            g.FillEllipse(crvenaCetka, 324, 200, 10, 10);
            g.FillEllipse(crvenaCetka, 318, 202, 7, 7);

            g.FillEllipse(crvenaCetka, 569, 198, 14, 14);
            g.FillEllipse(crvenaCetka, 582, 200, 10, 10);
            g.FillEllipse(crvenaCetka, 591, 202, 7, 7);
        }

        //Odabir korisnika buttoni
        private void button1_Click(object sender, EventArgs e)
        {
            jmbgDugmePritisnuto = true;
            button2Clicked = false;
            button3Clicked = false;
            button5Clicked = false;
            SlideB.Show();
            SlideA.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            jmbgDugmePritisnuto = false;
            button2Clicked = true;
            button3Clicked = false;
            button5Clicked = false;
            SlideB.Hide();
            SlideA.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            jmbgDugmePritisnuto = false;
            button2Clicked = false;
            button3Clicked = true;
            button5Clicked = false;
            SlideB.Hide();
            SlideA.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            jmbgDugmePritisnuto = false;
            button2Clicked = false;
            button3Clicked = false;
            button5Clicked = true;
            SlideB.Hide();
            SlideA.Show();
        }
        
        //pretpostavljam da ovo radi kako treba // Prijavi se buttun
        private void button4_Click(object sender, EventArgs e)
        {
            statusStripLogin.Visible = false;
            errorProvider1.SetError(richTextBox1, "");
            errorProvider2.SetError(richTextBox1, "");
            errorProvider3.SetError(richTextBox1, "");

            if (jmbgDugmePritisnuto)
            {
                if(!ValidirajUlazPacijenta()) return;
                if (k.KoristioKlinikuPrije(richTextBox3.Text))
                {
                    this.Hide();
                    prijavljeniPacijent = k.DajPacijenta(richTextBox3.Text);
                    PacijentForma pf = new PacijentForma();
                    pf.ShowDialog();
                }
                else if (!k.KoristioKlinikuPrije(richTextBox3.Text))
                {
                    errorProvider1.Clear();
                    statusStripLogin.Visible = true;
                    statusStripLogin.Text = "Ne postoji korisnik sa navedenim JMBG!";
                }
            }
            else if (button2Clicked)
            {
                if(!ValidirajUlazUposlenika()) return;
                if (k.PostojiLiTehnicar(richTextBox1.Text, textBox1.Text))
                {
                    this.Hide();
                    prijavljeniTehnicar = k.DajTehnicara(richTextBox1.Text);
                    TehnicarForma tf = new TehnicarForma();
                    tf.ShowDialog();
                }
                else if (k.PostojiLiTeh(richTextBox1.Text))
                {
                    statusStripLogin.Text = "Pogresan password!";
                    statusStripLogin.Visible = true;
                }
                else if (!k.PostojiLiTeh(richTextBox1.Text))
                {
                    statusStripLogin.Text = "Ne postoji medicinski tehnicar sa navedenim korisnickim imenom!";
                    statusStripLogin.Visible = true;
                }
            }
            else if (button3Clicked)
            {
                if (!ValidirajUlazUposlenika()) return;
                if (k.PostojiLiDoktor(richTextBox1.Text, textBox1.Text))
                {
                    this.Hide();
                    prijavljeniDoktor = k.DajDoktora(richTextBox1.Text);
                    DoktorForma df = new DoktorForma();
                    df.ShowDialog();
                }
                else if (k.PostojiLiDok(richTextBox1.Text))
                {
                    statusStripLogin.Visible = true;
                    statusStripLogin.Text = "Pogresan password!";
                }
                else if (!k.PostojiLiDok(richTextBox1.Text))
                {
                    statusStripLogin.Visible = true;
                    statusStripLogin.Text = "Ne postoji doktor sa navedenim korisnickim imenom!";
                }
            }
            else if (button5Clicked)
            {
                //ovdje treba napraviti da se otvara uprava forma A DOTAD CE SE OTVARATI DOKTOR, jebat mu mater
                if(!ValidirajUlazUposlenika()) return;
                if (k.PostojiLiUprava(richTextBox1.Text, textBox1.Text))
                {
                    this.Hide();
                    UpravaForma uf = new UpravaForma();
                    uf.ShowDialog();
                }
                else if (k.PostojiLiUpr(richTextBox1.Text))
                {
                    statusStripLogin.Visible = true;
                    statusStripLogin.Text = "Pogresan password!";
                }
                else if (!k.PostojiLiUpr(richTextBox1.Text))
                {
                    statusStripLogin.Visible = true;
                    statusStripLogin.Text = "Ne postoji uprava sa navedenim korisnickim imenom!";
                }
            }
        }

        //Ove vrste validacije pokrivaju slucajeve kada korisnik klikne na, recimo, textbox i unese u njega pogresne informacije
        //U slucaju da ne unese nikakve informacije one nece uciniti nista cak i ako u njima ima nesto tipa provjere da li je prazno polje
        //jer one rade SAMO kada se KLIKNE NE NJIH !
        

        private bool ValidirajUlazPacijenta()
        {
            if (richTextBox3.Text == "")
            {
                errorProvider1.SetError(richTextBox3, "JMBG pacijenta mora biti unesen");
                return false;
            }
            else if (!richTextBox3.Text.All(c => char.IsDigit(c)))
            {
                errorProvider1.SetError(richTextBox3, "JMBG mora sadrzavati samo cjelobrojne vrijednosti!");
                return false;
            }
            else if (richTextBox3.Text.Length != 13)
            {
                errorProvider1.SetError(richTextBox3, "JMBG mora sadrzavati 13 cifara");
                return false;
            }
            else errorProvider1.SetError(richTextBox3, "");
            return true;
        }
        private bool ValidirajUlazUposlenika()
        {
            if (richTextBox1.Text == "" && textBox1.Text == "")
            {
                errorProvider2.SetError(richTextBox1, "Username mora biti unesen");
                errorProvider3.SetError(textBox1, "Password mora biti unesen");
                return false;
            }
            else if (textBox1.Text == "")
            {
                errorProvider3.SetError(textBox1, "Password mora biti unesen");
                return false;
            }
            else if (richTextBox1.Text == "")
            {
                errorProvider2.SetError(richTextBox1, "Username mora biti unesen");
                return false;
            }
            return true;
        }
    }
        
}
