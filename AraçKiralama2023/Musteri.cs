using AraçKiralama2023.Models;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace AraçKiralama2023
{
    public partial class Musteri : Form
    {
        AracKiralama2023Entities3 db = new AracKiralama2023Entities3();
        public Musteri()
        {
            InitializeComponent();
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            TBLMUST yeni = new TBLMUST();
            yeni.MustAdı = textBox1.Text;
            yeni.MustSoyad = textBox2.Text;
            yeni.MustTelefon = textBox3.Text;
            yeni.MustEhliyetNo = textBox4.Text;
            yeni.MustAdres = textBox6.Text;
            yeni.MustTC = textBox5.Text;
            yeni.GirisTarih = guna2DateTimePicker1.Value;
            yeni.FOTO = lblresim.Text;
            yeni.DURUM = true;
            db.TBLMUST.Add(yeni);
            db.SaveChanges();
            MessageBox.Show("Eklendi");
            ((Musteri)Application.OpenForms["Musteri"]).Mustgetir();

            pictureBox1.Image.Save(Application.StartupPath + "\\Resimler\\" + openFileDialog1.SafeFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            textBox1.Text = "Ad";
            textBox2.Text = "Soyad";
            textBox3.Text = "Telefon";
            textBox4.Text = "Ehlyet No";
            textBox5.Text = "TC Kimlik No";
            textBox6.Text = "Adres";
        }

        private void Musteri_Load(object sender, EventArgs e)
        {
            Mustgetir();
        }
        private void Mustgetir()
        {
            var degerler1 = (from x in db.TBLMUST
                             where x.DURUM == true
                             select new
                             {
                                 x.MustID,
                                 x.MustAdı,
                                 x.MustSoyad,
                                 x.MustTelefon,
                                 x.MustTC,
                                 x.MustAdres,
                                 x.FOTO

                             });
            dataGridView1.DataSource = degerler1.ToList();

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);

                    lblresim.Text = openFileDialog1.SafeFileName;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatır = dataGridView1.SelectedCells[0].RowIndex;
            int seçilenpers = int.Parse(dataGridView1.Rows[secilensatır].Cells[0].Value.ToString());
            var kimbu = db.TBLMUST.Find(seçilenpers);
            textBox1.Text = kimbu.MustAdı.ToString();
            textBox2.Text = kimbu.MustSoyad.ToString();
            textBox3.Text = kimbu.MustTelefon.ToString();
            textBox4.Text = kimbu.MustTC.ToString();
            textBox5.Text = kimbu.MustEhliyetNo.ToString();
            textBox6.Text = kimbu.MustAdres.ToString();
            label1.Text = kimbu.MustID.ToString();
            guna2DateTimePicker1.Text = kimbu.GirisTarih.ToString();
        }
        public int gelenıd;
        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            if (label1.Text != "__")
            {
                pictureBox1.Image.Save(Application.StartupPath + "\\Resimler\\" + openFileDialog1.SafeFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                gelenıd = Convert.ToInt32(label1.Text);

                var guncpers = db.TBLMUST.Find(gelenıd);
                guncpers.MustAdı = textBox1.Text;
                guncpers.MustSoyad = textBox2.Text;
                guncpers.MustTelefon = textBox3.Text;
                guncpers.MustEhliyetNo = textBox4.Text;
                guncpers.MustAdres = textBox6.Text;
                guncpers.MustTC = textBox5.Text;
                guncpers.GirisTarih = guna2DateTimePicker1.Value;
                guncpers.FOTO = lblresim.Text;


                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            else
            {
                gelenıd = Convert.ToInt32(label1.Text);
                var guncpers = db.TBLMUST.Find(gelenıd);
                guncpers.MustAdı = textBox1.Text;
                guncpers.MustSoyad = textBox2.Text;
                guncpers.MustTelefon = textBox3.Text;
                guncpers.MustEhliyetNo = textBox4.Text;
                guncpers.MustAdres = textBox6.Text;
                guncpers.MustTC = textBox5.Text;
                guncpers.GirisTarih = guna2DateTimePicker1.Value;
                guncpers.FOTO = lblresim.Text;

                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            Mustgetir();
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Aktif kaydı silmek istediğinize emin misiniz?", "PERSONEL SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                var silinecekpersonel = db.TBLMUST.Find(Convert.ToInt32(label1.Text));
                silinecekpersonel.DURUM = false;
                db.SaveChanges();
                MessageBox.Show("Silindi");
                Mustgetir();

            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.TextLength != 0)
            {
                string ara = guna2TextBox1.Text;
                var de = db.TBLMUST.Where(x => x.MustAdı.Contains(ara) && x.DURUM == true);
                var den = (from x in de
                           select new
                           {

                               x.MustAdı,
                               x.MustSoyad,
                               x.MustAdres,
                               x.MustTC,
                               x.MustEhliyetNo
                           });

                dataGridView1.DataSource = den.ToList();
            }
        }
    }
}
