using AraçKiralama2023.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AraçKiralama2023
{
    public partial class PersonelOdeme : Form
    {
        public PersonelOdeme()
        {
            InitializeComponent();
        }
        AracKiralama2023Entities3 db = new AracKiralama2023Entities3();

        public int gelenid;
     

        public void odemegetir()
        {
            var bukim = db.TBLPERSONEL.Find(gelenid);
            label5.Text = bukim.PerAd;
            label6.Text = bukim.PerSoyad;
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
            dataGridView1.DataSource = odemeler.ToList();
            //tüm ödenenler toplamını yazdıralım

            decimal toplamodenen = Convert.ToDecimal(odemeler.Sum(x => x.ODENEN));

            textBox1.Text = toplamodenen.ToString() + "₺";


        }

        


        

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            TBLPERSODEME po = new TBLPERSODEME();
            po.PEDID = gelenid;
            po.ODENEN = Convert.ToDecimal(textBox1.Text);
            po.TARIH = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            po.TUR = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            db.TBLPERSODEME.Add(po);
            db.SaveChanges();
            MessageBox.Show("Ödeme kaydı tamamlandı");
            odemegetir();

            // bu ödeme kasaya gider olark kaydedilmeli
            TBLGIDER g = new TBLGIDER();
            g.Açıklama = label5.Text + " " + label6.Text + "'e " + po.TUR + " ödemesi yapıldı";
            g.GıderTutarı = po.ODENEN;
            g.GelirTarih = po.TARIH;
            db.TBLGIDER.Add(g);
            db.SaveChanges();
            //////////////////////////
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            //seçilen ödeme id sini aldık
            int secilenid = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value.ToString());

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

        private void PersonelOdeme_Load(object sender, EventArgs e)
        {
            var depler = from c in db.TBLODEMEBICIM
                         select c;
            comboBox1.DataSource = depler.ToList();
            comboBox1.ValueMember = "BıcımID";
            comboBox1.DisplayMember = "OdemeTıpı";
            odemegetir();
        }
    }
}
