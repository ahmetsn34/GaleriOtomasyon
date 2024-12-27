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
using AraçKiralama2023.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Guna.UI2.WinForms;
using System.Data.Entity.Validation;
using System.Runtime.Remoting.Contexts;

namespace AraçKiralama2023
{

    public partial class Personel : Form
    {



        AracKiralama2023Entities3 db = new AracKiralama2023Entities3();
        private void persgetir()
        {
            var degerler1 = (from x in db.TBLPERSONEL
                             where x.DURUM == true
                             select new
                             {
                                 x.PerID,
                                 x.PerAd,
                                 x.PerSoyad,
                                 x.PerTelefon,
                                 x.PerTC,
                                 x.PerAdres,
                                 x.PerGirisTarih,
                                 x.PerFoto

                             });
            dataGridView1.DataSource = degerler1.ToList();

        }
        public Personel()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Personel_Load(object sender, EventArgs e)
        {
            persgetir();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatır = dataGridView1.SelectedCells[0].RowIndex;
            int seçilenpers = int.Parse(dataGridView1.Rows[secilensatır].Cells[0].Value.ToString());
            var kimbu = db.TBLPERSONEL.Find(seçilenpers);
            textBox1.Text = kimbu.PerAd.ToString();
            textBox2.Text = kimbu.PerSoyad.ToString();
            textBox3.Text = kimbu.PerTelefon.ToString();
            textBox4.Text = kimbu.PerTC.ToString();
            textBox5.Text = kimbu.PerSicil.ToString();
            textBox6.Text = kimbu.PerAdres.ToString();
            label1.Text = kimbu.PerFoto;
            lblıd.Text = kimbu.PerID.ToString();
            guna2DateTimePicker1.Text = kimbu.PerGirisTarih.ToString();
            pictureBox2.ImageLocation = Application.StartupPath + "\\Resimler\\" + kimbu.PerFoto;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);

                    label1.Text = openFileDialog1.SafeFileName;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Aktif kaydı silmek istediğinize emin misiniz?", "PERSONEL SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                var silinecekpersonel = db.TBLPERSONEL.Find(Convert.ToInt32(lblıd.Text));
                silinecekpersonel.DURUM = false;
                db.SaveChanges();
                MessageBox.Show("Silindi");
                persgetir();

            }

        }
        public int gelenıd;
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (lblıd.Text != "__")
            {
                pictureBox1.Image.Save(Application.StartupPath + "\\Resimler\\" + openFileDialog1.SafeFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                gelenıd = Convert.ToInt32(lblıd.Text);

                var guncpers = db.TBLPERSONEL.Find(gelenıd);
                guncpers.PerAd = textBox1.Text;
                guncpers.PerSoyad = textBox2.Text;
                guncpers.PerTelefon = textBox3.Text;
                guncpers.PerSicil = textBox4.Text;
                guncpers.PerAdres = textBox6.Text;
                guncpers.PerTC = textBox5.Text;
                guncpers.PerGirisTarih = guna2DateTimePicker1.Value;
                guncpers.PerFoto = label1.Text;


                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            else
            {
                gelenıd = Convert.ToInt32(lblıd.Text);
                var guncpers = db.TBLPERSONEL.Find(gelenıd);
                guncpers.PerAd = textBox1.Text;
                guncpers.PerSoyad = textBox2.Text;
                guncpers.PerTelefon = textBox3.Text;
                guncpers.PerSicil = textBox4.Text;
                guncpers.PerAdres = textBox6.Text;
                guncpers.PerTC = textBox5.Text;
                guncpers.PerGirisTarih = guna2DateTimePicker1.Value;
                guncpers.PerFoto = label1.Text;

                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            persgetir();
            textBox1.Text = "Ad";
            textBox2.Text = "Soyad";
            textBox3.Text = "Telefon";
            textBox4.Text = "Sicil Numarası";
            textBox5.Text = "TC Kimlik No";
            textBox6.Text = "Adres";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TBLPERSONEL yeni = new TBLPERSONEL();
            yeni.PerAd = textBox1.Text;
            yeni.PerSoyad = textBox2.Text;
            yeni.PerTelefon = textBox3.Text;
            yeni.PerSicil = textBox4.Text;
            yeni.PerAdres = textBox6.Text;
            yeni.PerTC = textBox5.Text;
            yeni.PerGirisTarih = guna2DateTimePicker1.Value;
            yeni.PerFoto = label1.Text;
            yeni.DURUM = true;
            db.TBLPERSONEL.Add(yeni);
            db.SaveChanges();
            MessageBox.Show("Eklendi");
            ((Personel)Application.OpenForms["Personel"]).persgetir();

            pictureBox1.Image.Save(Application.StartupPath + "\\Resimler\\" + openFileDialog1.SafeFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            textBox1.Text = "Ad";
            textBox2.Text = "Soyad";
            textBox3.Text = "Telefon";
            textBox4.Text = "Sicil Numarası";
            textBox5.Text = "TC Kimlik No";
            textBox6.Text = "Adres";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.TextLength != 0)
            {
                string ara = guna2TextBox1.Text;
                var de = db.TBLPERSONEL.Where(x => x.PerAd.Contains(ara) && x.DURUM == true);
                var den = (from x in de
                           select new
                           {

                               x.PerAd,
                               x.PerSoyad,
                               x.PerAdres,
                               x.PerGirisTarih,
                               x.PerSicil,
                               x.PerTC

                           });

                dataGridView1.DataSource = den.ToList();
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            PersonelOdeme f = new PersonelOdeme();
            f.gelenid = Convert.ToInt32(lblıd.Text);
            f.Show();
        }

        private void guna2GroupBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

