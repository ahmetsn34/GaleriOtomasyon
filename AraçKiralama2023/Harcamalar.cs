using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AraçKiralama2023.Models;
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AraçKiralama2023
{
    public partial class Harcamalar : Form
    {
        AracKiralama2023Entities3 db = new AracKiralama2023Entities3();
        public Harcamalar()
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
                                 x.SırkTelefon,
                                 x.SırkAdres,
                                 x.SırkVergı,
                                 x.FOTO

                             });
            dataGridView1.DataSource = degerler1.ToList();
        }
        private void stokgetir()
        {
            var degerler1 = (from x in db.TBLFIRMAHAREKETLERI
                             where x.DURUM == true
                             select new
                             {
                                 x.HAREKETID,
                                 x.URUN,
                                 x.ADET,
                                 x.TARIH,
                                 x.TUTAR,
                                 x.FIRMA
                                 



                             });
           
            dataGridView2.DataSource = degerler1.ToList();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Harcamalar_Load(object sender, EventArgs e)
        {
            stokgetir();
            persgetir();
            var depler = from c in db.TBLODEMEBICIM
                         select c;
            guna2ComboBox1.DataSource = depler.ToList();
            guna2ComboBox1.ValueMember = "BıcımID";
            guna2ComboBox1.DisplayMember = "OdemeTıpı";
            dataGridView1.Rows[1].Cells[1].Style.BackColor = Color.Red;
        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private int gelenıd;
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (lblıd.Text != "__")
            {
                pictureBox1.Image.Save(Application.StartupPath + "\\Resimler\\" + openFileDialog1.SafeFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                gelenıd = Convert.ToInt32(lblıd.Text);

                var guncpers = db.TBLFIRMAHAREKETLERI.Find(gelenıd);
                guncpers.URUN = guna2TextBox3.Text;
                guncpers.ADET = Convert.ToDecimal(guna2TextBox1.Text);
                guncpers.TARIH = guna2DateTimePicker6.Value;
                guncpers.TUR = Convert.ToInt32(guna2ComboBox1.SelectedValue);
                guncpers.TUTAR =Convert.ToDecimal(guna2TextBox4.Text);



                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            else
            {
                var guncpers = db.TBLFIRMAHAREKETLERI.Find(gelenıd);
                guncpers.URUN = guna2TextBox3.Text;
                guncpers.ADET = Convert.ToDecimal(guna2TextBox1.Text);
                guncpers.TARIH = guna2DateTimePicker6.Value;
                guncpers.TUR = Convert.ToInt32(guna2ComboBox1.SelectedValue);
                guncpers.TUTAR = Convert.ToInt32(guna2TextBox4.Text);



                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            stokgetir();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TBLFIRMAHAREKETLERI yeni = new TBLFIRMAHAREKETLERI();
            yeni.URUN = guna2TextBox3.Text;
            yeni.ADET = Convert.ToDecimal(guna2TextBox1.Text);
            yeni.TARIH = guna2DateTimePicker6.Value;
            yeni.TUR = Convert.ToInt32(guna2ComboBox1.SelectedValue);
            yeni.TUTAR = Convert.ToInt32(guna2TextBox4.Text);
            yeni.FIRMA = Convert.ToInt32(textBox3.Text);
            yeni.DURUM = true;
            db.TBLFIRMAHAREKETLERI.Add(yeni);
            db.SaveChanges();
            MessageBox.Show("Eklendi");
            ((Harcamalar)Application.OpenForms["Harcamalar"]).stokgetir();
            TBLGIDER g = new TBLGIDER();
            g.Açıklama = label5.Text + " " + label6.Text + "'e " + yeni.TUR + " ödemesi yapıldı";
            g.GıderTutarı = yeni.TUTAR;
            g.GelirTarih = yeni.TARIH;
            db.TBLGIDER.Add(g);
            db.SaveChanges();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Aktif kaydı silmek istediğinize emin misiniz?", "PERSONEL SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                var silinecekpersonel = db.TBLFIRMAHAREKETLERI.Find(Convert.ToInt32(lblıd.Text));
                silinecekpersonel.DURUM = false;
                db.SaveChanges();
                MessageBox.Show("Silindi");
                stokgetir();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.TextLength != 0)
            {
                string ara = guna2TextBox1.Text;
                var de = db.TBLFIRMAHAREKETLERI.Where(x => x.URUN.Contains(ara) && x.DURUM == true);
                var den = (from x in de
                           select new
                           {

                               x.URUN,
                               x.TARIH,
                               x.TUTAR,
                               x.ADET


                           });

                dataGridView1.DataSource = den.ToList();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatır = dataGridView2.SelectedCells[0].RowIndex;
            int seçilenpers = int.Parse(dataGridView2.Rows[secilensatır].Cells[0].Value.ToString());
            var kimbu = db.TBLFIRMAHAREKETLERI.Find(seçilenpers);
            guna2TextBox3.Text = kimbu.URUN.ToString();
            guna2TextBox1.Text = kimbu.ADET.ToString();
            guna2DateTimePicker6.Text = kimbu.TARIH.ToString();
            guna2ComboBox1.Text = kimbu.TUR.ToString();
            guna2TextBox4.Text = kimbu.TUTAR.ToString();
            lblıd.Text = kimbu.HAREKETID.ToString();
           

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.TextLength != 0)
            {
                string ara = guna2TextBox1.Text;
                var de = db.TBLFIRMAHAREKETLERI.Where(x => x.URUN.Contains(ara) && x.DURUM == true);
                var den = (from x in de
                           select new
                           {

                               x.URUN

                           });

                dataGridView2.DataSource = den.ToList();stokgetir();
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
            {
                string ara = guna2TextBox1.Text;
                var de = db.TBLSIRKET.Where(x => x.SırkAd.Contains(ara) && x.DURUM == true);
                var den = (from x in de
                           select new
                           {

                               x.SırkAd,
                               x.SırkTC

                           });

                dataGridView1.DataSource = den.ToList();persgetir();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen =Convert.ToInt32(lblıd.Text);
           

            var kayitbul = db.TBLFIRMAHAREKETLERI.Find(secilen);
            int hangifirmaid = Convert.ToInt32(kayitbul.FIRMA);
            //1- firma hareketlerini çağıralım
            var hareketler = from x in db.TBLSIRKET
                             where x.SırkID == hangifirmaid
                             select new
                             {
                                 x.SırkID,
                                 x.SırkTC,
                                 x.SırkAd,
                                 x.SırkAdres,
                                 x.SırketTıp,
                                 x.DURUM
                             };
            dataGridView1.DataSource = hareketler.ToList();
            //2- Tutar alanının toplamını yaz
           
            

        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatır = dataGridView1.SelectedCells[0].RowIndex;
            int seçilenpers = int.Parse(dataGridView1.Rows[secilensatır].Cells[0].Value.ToString());
            var kimbu = db.TBLSIRKET.Find(seçilenpers);
            textBox3.Text = kimbu.SırkID.ToString();
        }
    }
}
