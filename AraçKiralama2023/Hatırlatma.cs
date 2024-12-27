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

namespace AraçKiralama2023
{
    public partial class Hatırlatma : Form
    {
        AracKiralama2023Entities3 db = new AracKiralama2023Entities3();
        public Hatırlatma()
        {
            InitializeComponent();
        }
        public int hatırlatmaıd;
        public void hatırlatmagetir()
        {
            guna2TextBox1.Clear();
            var değerler = (from x in db.TBLHATIRLATMA
                            where x.DURUM == true
                            select new
                            {
                                x.HatırlatmaID,
                                x.DURUM,
                                x.HatırlatmaSebep,
                                x.HatırlatmaTarıh,
                                x.KayıtTarıh,
                                x.Mesaj
                            });
            guna2DataGridView1.DataSource = değerler.ToList();

        }
        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            TBLHATIRLATMA ha = new TBLHATIRLATMA();
            ha.Mesaj = guna2TextBox1.Text;
            ha.HatırlatmaSebep= guna2TextBox3.Text;
            ha.HatırlatmaTarıh = guna2DateTimePicker1.Value;
            ha.KayıtTarıh = guna2DateTimePicker2.Value;
            ha.DURUM = true;
            db.TBLHATIRLATMA.Add(ha);
            db.SaveChanges();
            MessageBox.Show("YENİ HATIRLATICI EKLENDİ");
            ((Hatırlatma)Application.OpenForms["Hatırlatma"]).
            hatırlatmagetir();
        }

        private void Hatırlatma_Load(object sender, EventArgs e)
        {
            hatırlatmagetir();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            hatırlatmaıd = Convert.ToInt32(label18.Text);

            var ha = db.TBLHATIRLATMA.Find(hatırlatmaıd);
            ha.Mesaj = guna2TextBox1.Text;
            ha.HatırlatmaSebep = guna2TextBox3.Text;
            ha.HatırlatmaTarıh = guna2DateTimePicker1.Value;
            ha.KayıtTarıh = guna2DateTimePicker2.Value;

            db.SaveChanges();
            MessageBox.Show("Güncellendi");
            hatırlatmagetir();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Clear();
            int seçilensatır = guna2DataGridView1.SelectedCells[0].RowIndex;
            int secperıd = int.Parse(guna2DataGridView1.Rows[seçilensatır].Cells[0].Value.ToString());
            var kimbu = db.TBLHATIRLATMA.Find(secperıd);
            label18.Text = kimbu.HatırlatmaID.ToString();
            guna2TextBox3.Text = kimbu.HatırlatmaSebep.ToString();
            guna2DateTimePicker1.Text = kimbu.HatırlatmaTarıh.ToString();
            guna2DateTimePicker2.Text = kimbu.KayıtTarıh.ToString();
            guna2TextBox1.Text = (kimbu.Mesaj).ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Aktif kaydı silmek istediğinize emin misiniz?", "PERSONEL SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                var silinecekhat = db.TBLHATIRLATMA.Find(Convert.ToInt32(label18.Text));
                silinecekhat.DURUM = false;
                db.SaveChanges();
                MessageBox.Show("Silindi");
                hatırlatmagetir();

            }
        }
    }
}
