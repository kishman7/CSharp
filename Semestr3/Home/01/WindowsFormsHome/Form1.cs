using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsHome
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = (Convert.ToInt32(label1.Text) + 1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = (Convert.ToInt32(label2.Text) + 1).ToString();
        }

        Random random = new Random();
        private void label3_Click(object sender, EventArgs e)
        {
            label3.Top = random.Next(0, this.ClientSize.Height- label3.ClientSize.Height);
            label3.Left = random.Next(0, this.ClientSize.Width - label3.ClientSize.Width);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
        }
    }
}
