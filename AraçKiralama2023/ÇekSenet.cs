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
    public partial class ÇekSenet : Form
    {
        AracKiralama2023Entities3 db = new AracKiralama2023Entities3();
        public ÇekSenet()
        {
            InitializeComponent();
        }
        private void persgetir2()
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
            guna2DataGridView2.DataSource = degerler1.ToList();

        }
        private void persgetir()
        {
            var degerler1 = (from x in db.TBLÇEKSENET
                             where x.DURUM1 == true
                             select new
                             {
                                 x.CekID,
                                 x.ÇekTür,
                                 x.Tutar,
                                 x.Tarih,
                                 x.FIRMA,
                                 x.OdemeTarih,
                                 x.Durum,
                                 x.Açıklama
                                 

                             });
            guna2DataGridView1.DataSource = degerler1.ToList();

        }

        private void ÇekSenet_Load(object sender, EventArgs e)
        {
            persgetir();
            persgetir2();
            var depler = from c in db.TBLODEMEBICIM
                         select c;
            comboBox2.DataSource = depler.ToList();
            comboBox2.ValueMember = "BıcımID";
            comboBox2.DisplayMember = "OdemeTıpı";
            
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            int seçilensatır = guna2DataGridView1.SelectedCells[0].RowIndex;
            int secıddige = int.Parse(guna2DataGridView1.Rows[seçilensatır].Cells[0].Value.ToString());
            var çsö = db.TBLÇEKSENET.Find(secıddige);
            if (label7.Text == "ÖDENMEDİ")
            {
                çsö.Durum = "ÖDENDİ";
                db.SaveChanges();
                MessageBox.Show("Ödendi");

            }
            else
            {
                çsö.Durum = "ÖDENDİ";
                db.SaveChanges();
                MessageBox.Show("Ödeme Değiştirildi");

            }
            persgetir();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatır = guna2DataGridView1.SelectedCells[0].RowIndex;
            int seçilenpers = int.Parse(guna2DataGridView1.Rows[secilensatır].Cells[0].Value.ToString());
            var kimbu = db.TBLÇEKSENET.Find(seçilenpers);
            comboBox2.SelectedValue=kimbu.ÇekTür.ToString();
            guna2TextBox4.Text=kimbu.Açıklama.ToString();
            guna2DateTimePicker1.Text=kimbu.Tarih.ToString();
            guna2DateTimePicker2.Text=kimbu.OdemeTarih.ToString();

            guna2TextBox2.Text=kimbu.Tutar.ToString();

            lblıd.Text = kimbu.CekID.ToString();
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.TextLength != 0)
            {
                string ara = guna2TextBox1.Text;
                var de = db.TBLÇEKSENET.Where(x => x.Tutar.Contains(ara) && x.DURUM1 == true);
                var den = (from x in de
                           select new
                           {

                               x.ÇekTür,
                               //x.FIRMA,
                               //x.OdemeTarih,
                               //x.Tutar
                               

                           });

                guna2DataGridView1.DataSource = den.ToList();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TBLÇEKSENET yeni = new TBLÇEKSENET();
           

            yeni.ÇekTür = Convert.ToInt32(comboBox2.SelectedValue);
            yeni.Açıklama = guna2TextBox4.Text;
            yeni.Tarih = guna2DateTimePicker1.Value;
            yeni.OdemeTarih = guna2DateTimePicker2.Value;
            yeni.FIRMA = Convert.ToInt32(label1.Text);
           // yeni.Firma = Convert.ToInt32(comboBox3 .SelectedValue);
            yeni.Tutar = guna2TextBox2.Text;
            
            yeni.DURUM1 = true;
            db.TBLÇEKSENET.Add(yeni);
            db.SaveChanges();
            MessageBox.Show("Eklendi");
            ((ÇekSenet)Application.OpenForms["ÇekSenet"]).persgetir();
        }
        int gelenıd;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (lblıd.Text != "__")
            {
                
                gelenıd = Convert.ToInt32(lblıd.Text);

                var guncpers = db.TBLÇEKSENET.Find(gelenıd);
                guncpers.ÇekTür = Convert.ToInt32(comboBox2.SelectedValue);
                guncpers.Açıklama = guna2TextBox4.Text;
                guncpers.Tarih = guna2DateTimePicker1.Value;
                guncpers.OdemeTarih = guna2DateTimePicker2.Value;
                guncpers.FIRMA = Convert.ToInt32(label1.Text);
                guncpers.Tutar = guna2TextBox2.Text;
                //guncpers.DURUM1 = true;
                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            else
            {
                gelenıd = Convert.ToInt32(lblıd.Text);
                var guncpers = db.TBLÇEKSENET.Find(gelenıd);
                guncpers.ÇekTür = Convert.ToInt32(comboBox2.SelectedValue);
                guncpers.Açıklama = guna2TextBox4.Text;
                guncpers.Tarih = guna2DateTimePicker1.Value;
                guncpers.OdemeTarih = guna2DateTimePicker2.Value;
                // yeni.Firma = Convert.ToInt32(comboBox3 .SelectedValue);
                guncpers.Tutar = guna2TextBox2.Text;

                guncpers.DURUM1 = true;

                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            persgetir();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Aktif kaydı silmek istediğinize emin misiniz?", "çek SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                var silinecekpersonel = db.TBLÇEKSENET.Find(Convert.ToInt32(lblıd.Text));
                silinecekpersonel.DURUM1 = false;
                db.SaveChanges();
                MessageBox.Show("Silindi");
                persgetir();

            }
        }

        private void guna2DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //// sadece tıklanan satırdaki firma verileri gelsin
            //int secilen = guna2DataGridView1.SelectedCells[0].RowIndex;
            //int secilenid = int.Parse(guna2DataGridView1.Rows[secilen].Cells[0].Value.ToString());

            //var kayitbul = db.TBLFIRMAHAREKETLERI.Find(secilenid);
            //int hangifirmaid = Convert.ToInt32(kayitbul.FIRMA);

            ////1- firma hareketlerini çağıralım
            //var hareketler = from x in db.TBLFIRMAHAREKETLERI
            //                 where x.FIRMA == hangifirmaid
            //                 select new
            //                 {
            //                     x.ID,
            //                     x.TBLURUNLER.URUNADI,
            //                     x.TBLFIRMA.FIRMAADI,
            //                     x.TARIH,
            //                     x.ADET,
            //                     x.TUTAR
            //                 };
            //guna2DataGridView1.DataSource = hareketler.ToList();
            ////2- Tutar alanının toplamını yaz
            //var toplamhareket = hareketler.Sum(x => x.TUTAR);
            //textBox2.Text = toplamhareket.ToString() + " ₺";

            //// 3- Firma ödemelerimi çağıralım
            //var odemelerim = from c in db.TBLFIRMAODEME
            //                 where c.FIRMA == hangifirmaid
            //                 select new
            //                 {
            //                     c.ID,
            //                     c.TBLFIRMA.FIRMAADI,
            //                     c.TARIH,
            //                     c.ACIKLAMA,
            //                     c.TUTAR
            //                 };
            //dataGridView2.DataSource = odemelerim.ToList();
            //// 4- Ödemelerimin toplamını yaz
            //var toplamodeme = odemelerim.Sum(x => x.TUTAR);
            //textBox3.Text = toplamodeme.ToString() + " ₺";

            //var kalanborc = Convert.ToDecimal(toplamhareket) - Convert.ToDecimal(toplamodeme);
            //textBox1.Text = kalanborc.ToString() + " ₺";
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = Convert.ToInt32(lblıd.Text);


            var kayitbul = db.TBLÇEKSENET.Find(secilen);
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
            guna2DataGridView2.DataSource = hareketler.ToList();
        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatır = guna2DataGridView2.SelectedCells[0].RowIndex;
            int seçilenpers = int.Parse(guna2DataGridView2.Rows[secilensatır].Cells[0].Value.ToString());
            var kimbu = db.TBLSIRKET.Find(seçilenpers);
            label1.Text = kimbu.SırkID.ToString();
        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLÇEKSENET
                           where x.Tarih > guna2DateTimePicker2.Value 
                           select new
                           {
                               x.CekID,
                               x.FIRMA,
                               x.Tutar,
                               x.Durum,
                               x.Tarih
                           };
            guna2DataGridView1.DataSource = degerler.ToList();
        }
    }
}
