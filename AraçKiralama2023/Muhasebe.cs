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
using System.Data.SqlClient;

namespace AraçKiralama2023
{
    public partial class Muhasebe : Form
    {
        AracKiralama2023Entities3 db = new AracKiralama2023Entities3();
        public Muhasebe()
        {
            InitializeComponent();
        }
        public void gelirgidergel()
        {
            var değer = (from x in db.TBLGELIR
                         select new
                         {
                             x.GelırID,
                             x.GelirTuru,
                             x.GelirTutarı,
                             x.GelirTarıh
                         });
            dataGridView1.DataSource = değer.ToList();
            dataGridView1.Columns[0].Width = 50;
            var ge = db.TBLGELIR.FirstOrDefault();
            guna2ComboBox1.Text = ge.GelirTuru.ToString();
            guna2TextBox1.Text = ge.GelirTutarı.ToString();
            lblıd.Text = ge.GelırID.ToString();            
            guna2TextBox2.Text = değer.Sum(x => x.GelirTutarı).ToString() + " $ ";

            var deg = from x in db.TBLGIDER
                      select new
                      {
                          x.GıderID,
                          x.GiderTuru,
                          x.GıderTutarı,
                          x.GelirTarih
                      };

            dataGridView2.DataSource = değer.ToList();
            dataGridView1.Columns[0].Width = 50;
            var ga = db.TBLGIDER.FirstOrDefault();
            guna2ComboBox1.Text = ga.GiderTuru.ToString();
            guna2TextBox1.Text = ga.GıderTutarı.ToString();
            lblıd.Text = ga.GıderID.ToString();
            guna2TextBox2.Text = değer.Sum(x => x.GelirTutarı).ToString() + " $ ";

            guna2TextBox2.Text = Convert.ToInt32(değer.Sum(x => x.GelirTutarı) - deg.Sum(x => x.GıderTutarı)).ToString() + " $ ";


        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                                 x.PerTC,
                                 x.DURUM,
                                                              
                             });
            dataGridView1.DataSource = degerler1.ToList();

        }
        private void persgetir2()
        {
            var degerler1 = (from x in db.TBLPERSODEME
                             where x.DURUM == true
                             select new
                             {
                                 x.PersOdemeID,
                                 x.PEDID,
                                 x.TUR,
                                 x.ODENEN,
                                 x.TARIH
                                
                             });
            dataGridView2.DataSource = degerler1.ToList();

        }
        private void Muhasebe_Load(object sender, EventArgs e)
        {
            persgetir();
            persgetir2();
            var depler = from c in db.TBLODEMEBICIM
                         select c;
            guna2ComboBox1.DataSource = depler.ToList();
            guna2ComboBox1.ValueMember = "BıcımID";
            guna2ComboBox1.DisplayMember = "OdemeTıpı";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TBLPERSODEME yeni = new TBLPERSODEME();

           
            yeni.PEDID = Convert.ToInt32(lblıd.Text);
            yeni.TUR = Convert.ToInt32( guna2ComboBox1.SelectedValue);
            yeni.ODENEN =Convert.ToInt32(guna2TextBox1.Text);
            yeni.TARIH = guna2DateTimePicker1.Value;           
            yeni.DURUM = true;
            db.TBLPERSODEME.Add(yeni);
            db.SaveChanges();
            MessageBox.Show("Eklendi");
            ((Muhasebe)Application.OpenForms["Muhasebe"]).persgetir();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
