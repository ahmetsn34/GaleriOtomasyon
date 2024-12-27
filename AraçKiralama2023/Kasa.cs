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
using AraçKiralama2023.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AraçKiralama2023
{

    public partial class Kasa : Form
    {
        AracKiralama2023Entities3 db = new AracKiralama2023Entities3();
        public Kasa()
        {
            InitializeComponent();
        }
        public void gidergel()
        {
            var gdr = from x in db.TBLGIDER
                      where x.DURUM == true
                      select new
                      {
                          x.GıderID,
                          x.GiderTuru,
                          x.GıderTutarı,
                          x.GelirTarih
                      };
            guna2TextBox4.Text = gdr.Sum(x => x.GıderTutarı).ToString();
            dataGridView2.DataSource= gdr.ToList();

        }
        public void gelirgel()
        {
            var glr = from x in db.TBLGELIR
                      where x.DURUM == true
                      select new
                      {
                          x.GelırID,
                          x.GelirTuru,
                          x.GelirTarıh,
                          x.GelirTutarı,
                          x.DURUM,
                          x.Acıklama
                      };
            guna2TextBox5.Text = glr.Sum(x => x.GelirTutarı).ToString();
            dataGridView1.DataSource = glr.ToList();

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Kasa_Load(object sender, EventArgs e)
        {
            gelirgel();
            gidergel();
            var depler = from c in db.TBLODEMEBICIM
                         select c;
            comboBox2.DataSource = depler.ToList();
            comboBox2.ValueMember = "BıcımID";
            comboBox2.DisplayMember = "OdemeTıpı";
            var depler2 = from c in db.TBLODEMEBICIM
                         select c;
            comboBox1.DataSource = depler.ToList();
            comboBox1.ValueMember = "BıcımID";
            comboBox1.DisplayMember = "OdemeTıpı";
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            TBLGELIR gid = new TBLGELIR();
            gid.GelirTutarı = int.Parse(guna2TextBox7.Text);
            gid.GelirTuru =comboBox2.Text;
            gid.GelirTarıh = guna2DateTimePicker1.Value;
            db.TBLGELIR.Add(gid);
            db.SaveChanges();
            ((Kasa)Application.OpenForms["Kasa"]).gelirgel();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (guna2TextBox1.TextLength != 0)
            {
                string ara = guna2TextBox1.Text;
                var de = db.TBLGIDER.Where(x => x.GiderTuru.Contains(ara) && x.DURUM == true);
                var den = (from x in de
                           select new
                           {

                               x.GiderTuru,
                               x.GıderTutarı,
                               x.GelirTarih


                           });

                dataGridView1.DataSource = den.ToList();
            }
        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (guna2TextBox1.TextLength != 0)
            {
                string ara = guna2TextBox1.Text;
                var de = db.TBLGELIR.Where(x => x.GelirTuru.Contains(ara) && x.DURUM == true);
                var den = (from x in de
                           select new
                           {

                               x.GelirTutarı,
                               x.GelirTuru,
                               x.GelirTarıh
                               

                           });

                dataGridView1.DataSource = den.ToList();
            }
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblıd_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
            TBLGELIR yeni = new TBLGELIR();
            yeni.GelirTuru = comboBox2.Text;
            yeni.GelirTarıh = guna2DateTimePicker1.Value;
            yeni.GelirTutarı = Convert.ToInt32(guna2TextBox7.Text);          
            yeni.DURUM = true;
            db.TBLGELIR.Add(yeni);
            db.SaveChanges();
            MessageBox.Show("Eklendi");
            ((Kasa)Application.OpenForms["Kasa"]).gelirgel();
        }
        int gelenıd;
        private void guna2Button7_Click_1(object sender, EventArgs e)
        {
            if (guna2TextBox3.Text != "__")
            {
              
                gelenıd = Convert.ToInt32(guna2TextBox3.Text);

                var guncpers = db.TBLGELIR.Find(gelenıd);
                guncpers.GelirTuru = comboBox2.Text;
                guncpers.GelirTarıh = guna2DateTimePicker1.Value;
                guncpers.GelirTutarı = Convert.ToInt32(guna2TextBox7.Text);


                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            else
            {
                gelenıd = Convert.ToInt32(guna2TextBox3.Text);
                var guncpers = db.TBLGELIR.Find(gelenıd);
                guncpers.GelirTuru = comboBox2.Text;
                guncpers.GelirTarıh = guna2DateTimePicker1.Value;
                guncpers.GelirTutarı = Convert.ToInt32(guna2TextBox7.Text);

                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            gelirgel();
        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Aktif kaydı silmek istediğinize emin misiniz?", "GELİR SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                var silinecekpersonel = db.TBLGELIR.Find(Convert.ToInt32(guna2TextBox3.Text));
                silinecekpersonel.DURUM = false;
                db.SaveChanges();
                MessageBox.Show("Silindi");
                gelirgel();

            }
        }

        private void guna2Button11_Click_1(object sender, EventArgs e)
        {
            TBLGIDER yeni = new TBLGIDER();
            yeni.GiderTuru = comboBox1.Text;
            yeni.GelirTarih = guna2DateTimePicker1.Value;
            yeni.GıderTutarı = Convert.ToInt32(guna2TextBox2.Text.ToString());
            yeni.Açıklama = guna2TextBox1.Text;
            yeni.DURUM = true;
            db.TBLGIDER.Add(yeni);
            db.SaveChanges();
            MessageBox.Show("Eklendi");
            ((Kasa)Application.OpenForms["Kasa"]).gidergel();
        }

        private void guna2Button12_Click_1(object sender, EventArgs e)
        {
            if (guna2TextBox3.Text != "__")
            {

                gelenıd = Convert.ToInt32(guna2TextBox6.Text);

                var guncpers = db.TBLGIDER.Find(gelenıd);
                guncpers.GiderTuru = comboBox1.Text;
                guncpers.GelirTarih = guna2DateTimePicker1.Value;
                guncpers.GıderTutarı = Convert.ToInt32(guna2TextBox2.Text);
                guncpers.Açıklama = guna2TextBox1.Text;


                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            else
            {
                gelenıd = Convert.ToInt32(guna2TextBox6.Text);
                var guncpers = db.TBLGIDER.Find(gelenıd);
                guncpers.GiderTuru = comboBox1.Text;
                guncpers.GelirTarih = guna2DateTimePicker1.Value;
                guncpers.GıderTutarı = Convert.ToInt32(guna2TextBox2.Text);
                guncpers.Açıklama = guna2TextBox1.Text;

                db.SaveChanges();
                MessageBox.Show("Güncellendi");
            }
            gidergel();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatır = dataGridView1.SelectedCells[0].RowIndex;
            int seçilenpers = int.Parse(dataGridView1.Rows[secilensatır].Cells[0].Value.ToString());
            var kimbu = db.TBLGELIR.Find(seçilenpers);
            comboBox2.Text = kimbu.GelirTuru.ToString();
            guna2TextBox7.Text = kimbu.GelirTutarı.ToString();
            guna2DateTimePicker5.Text = kimbu.GelirTarıh.ToString();
            //guna2TextBox11.Text = kimbu.Acıklama.ToString();
            guna2TextBox3.Text = kimbu.GelırID.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatır = dataGridView2.SelectedCells[0].RowIndex;
            int seçilenpers = int.Parse(dataGridView2.Rows[secilensatır].Cells[0].Value.ToString());
            var kimbu = db.TBLGIDER.Find(seçilenpers);
            comboBox1.Text = kimbu.GiderTuru.ToString();
            guna2TextBox2.Text = kimbu.GıderTutarı.ToString();
            guna2DateTimePicker1.Text = kimbu.GelirTarih.ToString();
            // guna2TextBox1.Text= kimbu.Açıklama.ToString();
            guna2TextBox6.Text = kimbu.GıderID.ToString();
        }

        private void lblıd_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button10_Click_1(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Aktif kaydı silmek istediğinize emin misiniz?", "GELİR SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                var silinecekpersonel = db.TBLGIDER.Find(Convert.ToInt32(guna2TextBox6.Text.ToString()));
                silinecekpersonel.DURUM = false;
                db.SaveChanges();
                MessageBox.Show("Silindi");
                gidergel();

            }
        }
    }
}
