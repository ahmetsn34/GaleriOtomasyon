using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AraçKiralama2023
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            Musteri prsnl = new Musteri();
            prsnl.TopLevel = false;
            prsnl.Dock = DockStyle.Fill;
            panel4.Controls.Add(prsnl);
            prsnl.BringToFront();
            prsnl.Show();
            guna2Button2.FillColor = Color.Red;
            guna2Button1.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button3.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button4.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button5.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button6.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button7.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button8.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button9.FillColor = Color.FromArgb(78, 184, 206);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            Firmalar prsnl = new Firmalar();
            prsnl.TopLevel = false;
            prsnl.Dock = DockStyle.Fill;
            panel4.Controls.Add(prsnl);
            prsnl.BringToFront();
            prsnl.Show();
            guna2Button3.FillColor = Color.Red;
            guna2Button2.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button1.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button4.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button5.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button6.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button7.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button8.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button9.FillColor = Color.FromArgb(78, 184, 206);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            OdemeTakip prsnl = new OdemeTakip();
            prsnl.TopLevel = false;
            prsnl.Dock = DockStyle.Fill;
            panel4.Controls.Add(prsnl);
            prsnl.BringToFront();
            prsnl.Show();
            guna2Button4.FillColor = Color.Red;
            guna2Button3.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button2.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button1.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button5.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button6.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button7.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button8.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button9.FillColor = Color.FromArgb(78, 184, 206);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            Kasa prsnl = new Kasa();
            prsnl.TopLevel = false;
            prsnl.Dock = DockStyle.Fill;
            panel4.Controls.Add(prsnl);
            prsnl.BringToFront();
            prsnl.Show();
            guna2Button5.FillColor = Color.Red;
            guna2Button4.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button3.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button2.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button1.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button6.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button7.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button8.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button9.FillColor = Color.FromArgb(78, 184, 206);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            Hatırlatma prsnl = new Hatırlatma();
            prsnl.TopLevel = false;
            prsnl.Dock = DockStyle.Fill;
            panel4.Controls.Add(prsnl);
            prsnl.BringToFront();
            prsnl.Show();
            guna2Button6.FillColor = Color.Red;
            guna2Button5.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button4.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button3.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button2.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button1.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button7.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button8.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button9.FillColor = Color.FromArgb(78, 184, 206);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            ÇekSenet prsnl = new ÇekSenet();
            prsnl.TopLevel = false;
            prsnl.Dock = DockStyle.Fill;
            panel4.Controls.Add(prsnl);
            prsnl.BringToFront();
            prsnl.Show();
            guna2Button7.FillColor = Color.Red;
            guna2Button6.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button5.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button4.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button3.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button2.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button1.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button8.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button9.FillColor = Color.FromArgb(78, 184, 206);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            Personel prsnl = new Personel();
            prsnl.TopLevel = false;
            prsnl.Dock = DockStyle.Fill;
            panel4.Controls.Add(prsnl);
            prsnl.BringToFront();
            prsnl.Show();
            guna2Button1.FillColor = Color.Red;
            guna2Button2.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button3.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button4.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button5.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button6.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button7.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button8.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button9.FillColor = Color.FromArgb(78, 184, 206);




        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
           Araclar prsnl = new Araclar();
            prsnl.TopLevel = false;
            prsnl.Dock = DockStyle.Fill;
            panel4.Controls.Add(prsnl);
            prsnl.BringToFront();
            prsnl.Show();
            guna2Button9.FillColor = Color.Red;
            guna2Button8.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button7.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button6.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button5.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button4.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button3.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button2.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button1.FillColor = Color.FromArgb(78, 184, 206);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            Harcamalar prsnl = new Harcamalar();
            prsnl.TopLevel = false;
            prsnl.Dock = DockStyle.Fill;
            panel4.Controls.Add(prsnl);
            prsnl.BringToFront();
            prsnl.Show();
            guna2Button8.FillColor = Color.Red;
            guna2Button7.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button6.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button5.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button4.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button3.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button2.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button1.FillColor = Color.FromArgb(78, 184, 206);
            guna2Button9.FillColor = Color.FromArgb(78, 184, 206);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
