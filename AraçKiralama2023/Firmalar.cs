using AraçKiralama2023.Models;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AraçKiralama2023
{
    public partial class Firmalar : Form
    {
        AracKiralama2023Entities3 db = new AracKiralama2023Entities3();
        public Firmalar()
        {
            InitializeComponent();
        }
        private void persgetir()
        {
            var degerler1 = (from x in db.TBLSIRKET
                             where x.DURUM == true
                             select new
                             {
                                 x.SırkID,
                                 x.SırkTC,
                                 x.SırkAd,
                                 x.SırkUnvan,
                                 x.SırketTıp,
                                 x.SırkTelefon,
                                 x.SırkAdres,
                                 x.SırkVergı,
                                 x.FOTO

                             });
            dataGridView1.DataSource = degerler1.ToList();

        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TBLSIRKET yeni = new TBLSIRKET();
            yeni.SırkTC = guna2TextBox2.Text;
            yeni.SırkAd = guna2TextBox3.Text;
            yeni.SırkUnvan = guna2TextBox4.Text;
            yeni.SırkTelefon = guna2TextBox5.Text;
            yeni.SırkAdres = guna2TextBox6.Text;
            yeni.SırkVergı = guna2TextBox7.Text;
            yeni.FOTO = label7.Text;
            if (yeni.SırketTıp == true)
            {
                //radioButton1.Checked = true;
                yeni.SırketTıp = true;
            }
            else
            {
                //radioButton2.Checked = false;
                yeni.SırketTıp = false;
            }
            yeni.DURUM = true;
            db.TBLSIRKET.Add(yeni);
            db.SaveChanges();
            MessageBox.Show("Eklendi");
            ((Firmalar)Application.OpenForms["Firmalar"]).persgetir();

            pictureBox1.Image.Save(Application.StartupPath + "\\Resimler\\" + openFileDialog1.SafeFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void Firmalar_Load(object sender, EventArgs e)
        {
            persgetir();
        }
        public int gelenıd;
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (lblıd.Text != "__")
            {
                pictureBox1.Image.Save(Application.StartupPath + "\\Resimler\\" + openFileDialog1.SafeFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                gelenıd = Convert.ToInt32(lblıd.Text);

                var guncpers = db.TBLSIRKET.Find(gelenıd);
                guncpers.SırkTC = guna2TextBox2.Text;
                guncpers.SırkAd = guna2TextBox3.Text;
                guncpers.SırkUnvan = guna2TextBox4.Text;
                guncpers.SırkTelefon = guna2TextBox5.Text;
                guncpers.SırkAdres = guna2TextBox6.Text;
                guncpers.SırkVergı = guna2TextBox7.Text;
                guncpers.FOTO = label7.Text;


                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            else
            {
                gelenıd = Convert.ToInt32(lblıd.Text);
                var guncpers = db.TBLSIRKET.Find(gelenıd);
                guncpers.SırkTC = guna2TextBox2.Text;
                guncpers.SırkAd = guna2TextBox3.Text;
                guncpers.SırkUnvan = guna2TextBox4.Text;
                guncpers.SırkTelefon = guna2TextBox5.Text;
                guncpers.SırkAdres = guna2TextBox6.Text;
                guncpers.SırkVergı = guna2TextBox7.Text;
                guncpers.FOTO = label7.Text;

                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            persgetir();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

                    label7.Text = openFileDialog1.SafeFileName;
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
                var silinecekpersonel = db.TBLSIRKET.Find(Convert.ToInt32(lblıd.Text));
                silinecekpersonel.DURUM = false;
                db.SaveChanges();
                MessageBox.Show("Silindi");
                persgetir();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatır = dataGridView1.SelectedCells[0].RowIndex;
            int seçilenpers = int.Parse(dataGridView1.Rows[secilensatır].Cells[0].Value.ToString());
            var kimbu = db.TBLSIRKET.Find(seçilenpers);
            guna2TextBox2.Text = kimbu.SırkTC.ToString();
            guna2TextBox3.Text = kimbu.SırkAd.ToString();
            guna2TextBox4.Text = kimbu.SırkUnvan.ToString();
            guna2TextBox5.Text = kimbu.SırkTelefon.ToString();
            guna2TextBox6.Text = kimbu.SırkAdres.ToString();
            guna2TextBox7.Text = kimbu.SırkVergı.ToString();
            lblıd.Text = kimbu.SırkID.ToString();
            pictureBox1.ImageLocation = Application.StartupPath + "\\Resimler\\" + kimbu.FOTO;

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.TextLength != 0)
            {
                string ara = guna2TextBox2.Text;
                var de = db.TBLSIRKET.Where(x => x.SırkAd.Contains(ara) && x.DURUM == true);
                var den = (from x in de
                           select new
                           {

                               x.SırkAd,
                               x.SırkAdres,
                               x.SırketTıp,
                               x.SırkTelefon,
                               x.SırkTC

                           });

                dataGridView1.DataSource = den.ToList();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
