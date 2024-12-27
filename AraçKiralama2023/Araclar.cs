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
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AraçKiralama2023
{
    public partial class Araclar : Form
    {
        AracKiralama2023Entities3 db = new AracKiralama2023Entities3();
        public Araclar()
        {
            InitializeComponent();
        }
        private void persgetir()
        {
            var degerler1 = (from x in db.TBLARACLAR
                             where x.DURUM == true
                             select new
                             {
                                 x.AracID,
                                 x.TBLMARKA.Marka,
                                 x.Model,
                                 x.UretımYılı,
                                 x.Plaka,
                                 x.TBLYAKIT.Yakıt
                                

                             });

            guna2DataGridView1.DataSource = degerler1.ToList();

        }
        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TBLARACLAR yeni = new TBLARACLAR();
            
            yeni.Marka= Convert.ToInt32(comboBox1.SelectedValue);
            yeni.Model = guna2TextBox2.Text;
            yeni.UretımYılı = guna2DateTimePicker1.Value;
            yeni.Plaka = guna2TextBox3.Text;
            yeni.YakıtTıpı = Convert.ToInt32(comboBox2.SelectedValue);
            yeni.FOTO= label1.Text;
            yeni.DURUM = true;
            db.TBLARACLAR.Add(yeni);
            db.SaveChanges();
            MessageBox.Show("Eklendi");
            ((Araclar)Application.OpenForms["Araclar"]).persgetir();

            guna2PictureBox1.Image.Save(Application.StartupPath + "\\Resimler\\" + openFileDialog1.SafeFileName, System.Drawing.Imaging.ImageFormat.Jpeg);persgetir();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    guna2PictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

                    label1.Text = openFileDialog1.SafeFileName;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int gelenıd;
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (lblıd.Text != "__")
            {
                guna2PictureBox1.Image.Save(Application.StartupPath + "\\Resimler\\" + openFileDialog1.SafeFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                gelenıd = Convert.ToInt32(lblıd.Text);

                var guncpers = db.TBLARACLAR.Find(gelenıd);
                guncpers.AracID = Convert.ToInt32(lblıd.Text);
                guncpers.Marka = Convert.ToInt32(comboBox1.SelectedValue);
                guncpers.Model = guna2TextBox2.Text;
                guncpers.UretımYılı = guna2DateTimePicker1.Value;
                guncpers.Plaka = guna2TextBox3.Text;
                guncpers.YakıtTıpı = Convert.ToInt32(comboBox2.SelectedValue);
                guncpers.FOTO = label1.Text;


                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            else
            {
                gelenıd = Convert.ToInt32(lblıd.Text);
                var guncpers = db.TBLARACLAR.Find(gelenıd);
                guncpers.Marka = Convert.ToInt32(comboBox1.SelectedValue);
                guncpers.Model = guna2TextBox2.Text;
                guncpers.UretımYılı = guna2DateTimePicker1.Value;
                guncpers.Plaka = guna2TextBox3.Text;
                guncpers.YakıtTıpı = Convert.ToInt32(comboBox2.SelectedValue);
                guncpers.FOTO = label1.Text;

                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            persgetir();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Aktif kaydı silmek istediğinize emin misiniz?", "ARAÇ SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                var silinecekpersonel = db.TBLARACLAR.Find(Convert.ToInt32(lblıd.Text));
                silinecekpersonel.DURUM = false;
                db.SaveChanges();
                MessageBox.Show("Silindi");
                persgetir();

            }
        }

        private void Araclar_Load(object sender, EventArgs e)
        {
            persgetir();
            var depler = from c in db.TBLMARKA                        
                         select c;
            comboBox1.DataSource = depler.ToList();
            comboBox1.ValueMember = "MarkaID";
            comboBox1.DisplayMember = "Marka";
            var depler2 = from c in db.TBLYAKIT
                         select c;
            comboBox2.DataSource = depler2.ToList();
            comboBox2.ValueMember = "YakıtID";
            comboBox2.DisplayMember = "Yakıt";
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatır = guna2DataGridView1.SelectedCells[0].RowIndex;
            int seçilenpers = int.Parse(guna2DataGridView1.Rows[secilensatır].Cells[0].Value.ToString());
            var kimbu = db.TBLARACLAR.Find(seçilenpers);
            comboBox1.Text = kimbu.Marka.ToString();
            guna2TextBox2.Text = kimbu.Model.ToString();
            guna2DateTimePicker1.Text = kimbu.UretımYılı.ToString();
            guna2TextBox3.Text = kimbu.Plaka.ToString();
            comboBox2.Text = kimbu.YakıtTıpı.ToString();
            label1.Text = kimbu.FOTO;
            lblıd.Text = kimbu.AracID.ToString();
            guna2PictureBox1.ImageLocation = Application.StartupPath + "\\Resimler\\" + kimbu.FOTO;

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.TextLength != 0)
            {
                string ara = guna2TextBox1.Text;
                var de = db.TBLARACLAR.Where(x => x.Model.Contains(ara) && x.DURUM == true);
                var den = (from x in de
                           select new
                           {
                              
                               x.Marka,
                               x.Model,
                               x.UretımYılı,
                               x.Plaka,
                               x.YakıtTıpı
                              
                           });

                guna2DataGridView1.DataSource = den.ToList();
                
               



                
            }

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
