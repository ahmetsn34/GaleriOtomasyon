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
    public partial class OdemeTakip : Form
    {
        AracKiralama2023Entities3 db = new AracKiralama2023Entities3();
        public OdemeTakip()
        {
            InitializeComponent();
        }
        public int gelenid;
        public void odemegetir()
        {
            var bukim = db.TBLPERSONEL.Find(gelenid);          
            var odemeler = (from x in db.TBLPERSODEME
                            /*here x.PEDID == gelenid*/
                            select new
                            {
                                x.PersOdemeID,
                                x.PEDID,
                                x.TUR,
                                x.TARIH,
                                x.ODENEN
                            }).OrderByDescending(x => x.TARIH);
            guna2DataGridView2.DataSource = odemeler.ToList();
            //tüm ödenenler toplamını yazdıralım

            decimal toplamodenen = Convert.ToDecimal(odemeler.Sum(x => x.ODENEN));

            textBox1.Text = toplamodenen.ToString() + "₺";


        }
        public void odemegetir2()
        {
            var bukim = db.TBLPERSONEL.Find(gelenid);
            
            var odemeler = (from x in db.TBLPERSODEME
                            where x.PEDID == gelenid
                            select new
                            {
                                x.PersOdemeID,
                                x.PEDID,
                                x.TUR,
                                x.TARIH,
                                x.ODENEN
                            }).OrderByDescending(x => x.TARIH);
            guna2DataGridView2.DataSource = odemeler.ToList();
            //tüm ödenenler toplamını yazdıralım

            decimal toplamodenen = Convert.ToDecimal(odemeler.Sum(x => x.ODENEN));

            textBox1.Text = toplamodenen.ToString() + "₺";


        }
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
            guna2DataGridView1.DataSource = degerler1.ToList();

        }
        private void OdemeTakip_Load(object sender, EventArgs e)
        {
            odemegetir();
            persgetir();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatır = guna2DataGridView1.SelectedCells[0].RowIndex;
            int seçilenpers = int.Parse(guna2DataGridView1.Rows[secilensatır].Cells[0].Value.ToString());
            var kimbu = db.TBLPERSODEME.Find(seçilenpers);
            guna2ComboBox1.SelectedValue = kimbu.TUR.ToString();
            guna2DateTimePicker1.Text = kimbu.TARIH.ToString();
            guna2TextBox2.Text = kimbu.ODENEN.ToString();
            guna2TextBox4.Text = kimbu.PEDID.ToString();         
            lblıd.Text = kimbu.PersOdemeID.ToString();
        }

        private void guna2DataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = Convert.ToInt32(lblıd.Text);


            var kayitbul = db.TBLPERSONEL.Find(secilen);
            int hangifirmaid = Convert.ToInt32(kayitbul.PerID);
            //1- firma hareketlerini çağıralım
            var hareketler = from x in db.TBLPERSODEME
                             where x.PEDID == hangifirmaid
                             select new
                             {
                                 x.PEDID,
                                 x.TUR,
                                 x.ODENEN,
                                 x.TARIH,                                
                                 x.DURUM
                             };
            guna2DataGridView2.DataSource = hareketler.ToList();
            //2- Tutar alanının toplamını yaz
            var toplamhareket = hareketler.Sum(x => x.ODENEN);
            textBox1.Text = toplamhareket.ToString() + " ₺";
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int gelenıd;
        private void button2_Click(object sender, EventArgs e)
        {
            if (lblıd.Text != "__")
            {

                gelenıd = Convert.ToInt32(lblıd.Text);

                var guncpers = db.TBLPERSODEME.Find(gelenıd);
                guncpers.TUR = Convert.ToInt32(guna2ComboBox1.SelectedValue);               
                guncpers.ODENEN = Convert.ToInt32(guna2TextBox2.Text);
                guncpers.TARIH = guna2DateTimePicker1.Value;              
                guncpers.DURUM = true;
                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            else
            {
                gelenıd = Convert.ToInt32(lblıd.Text);

                var guncpers = db.TBLPERSODEME.Find(gelenıd);
                guncpers.TUR = Convert.ToInt32(guna2ComboBox1.SelectedValue);
                guncpers.ODENEN = Convert.ToInt32(guna2TextBox2.Text);
                guncpers.TARIH = guna2DateTimePicker1.Value;
                guncpers.DURUM = true;
                db.SaveChanges();
                MessageBox.Show("Güncellendi");

                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            odemegetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TBLPERSODEME po = new TBLPERSODEME();
            po.PEDID = gelenid;
            po.ODENEN = Convert.ToDecimal(guna2TextBox2.Text);
            po.TARIH = Convert.ToDateTime(guna2DateTimePicker1.Value.ToShortDateString());
            po.TUR = Convert.ToInt32(guna2ComboBox1.SelectedValue.ToString());
            db.TBLPERSODEME.Add(po);
            db.SaveChanges();
            MessageBox.Show("Ödeme kaydı tamamlandı");
            odemegetir();

            // bu ödeme kasaya gider olark kaydedilmeli
            TBLGIDER g = new TBLGIDER();          
            g.GıderTutarı = po.ODENEN;
            g.GelirTarih = po.TARIH;
            db.TBLGIDER.Add(g);
            db.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int secilen = guna2DataGridView1.SelectedCells[0].RowIndex;
            //seçilen ödeme id sini aldık
            int secilenid = Convert.ToInt32(guna2DataGridView1.Rows[secilen].Cells[0].Value.ToString());

            DialogResult cevap = MessageBox.Show("Aktif kaydı silmek istediğinize emin misiniz?", "ÖDEME SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                var silinecekodeme = db.TBLPERSODEME.Find(Convert.ToInt32(secilenid));
                db.TBLPERSODEME.Remove(silinecekodeme);
                db.SaveChanges();
                MessageBox.Show("Sildim");
                odemegetir();

            }
        }
    }
}
