using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinika17321
{
    public partial class SlikaDatum : UserControl
    {
        public SlikaDatum()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bit = new Bitmap(ofd.FileName);
                pictureBox2.Image = bit;
                pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(dateTimePicker1, "");
            if(dateTimePicker1.Value.AddMonths(+6) < DateTime.Today)
            {
                errorProvider1.SetError(dateTimePicker1, "Slika ne smije biti starija od 6 mjeseci");
                return;
            }
            Login.k.DajPacijenta(Login.prijavljeniPacijent.Jmbg).SlikaPacijenta = pictureBox2.Image;
            Login.k.DajPacijenta(Login.prijavljeniPacijent.Jmbg).ImaSliku = true;
        }

        private void SlikaDatum_Load(object sender, EventArgs e)
        {
            if (Login.k.DajPacijenta(Login.prijavljeniPacijent.Jmbg).ImaSliku)
                pictureBox2.Image = Login.k.DajPacijenta(Login.prijavljeniPacijent.Jmbg).SlikaPacijenta;
        }
    }
}
