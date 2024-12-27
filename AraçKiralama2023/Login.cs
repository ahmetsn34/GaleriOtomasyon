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

namespace AraçKiralama2023
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "a" && textBox2.Text == "a") 
            {
                AnaSayfa Menu = new AnaSayfa();
                Menu.Show(); 
                this.Hide(); 
            }
            else
            {
                label1.Visible = true;
            }
        }
    }
}
