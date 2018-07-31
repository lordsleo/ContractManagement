using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContractManagement
{
    public partial class Form3 : Form
    {
        public string t1;
        public string t2;
        public string t3;
        public string t4;
        public string t5;
        public string t6;
        public string t7;
        public string t8;
        public string t9;
        public string t10;
        public string t11;
        public string t12;
        public string t13;
        public string t14;
        public string t15;
        public string t16;

        public Form3()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            textBox2.Text = t1;
            textBox11.Text = t2;
            textBox3.Text = t3;
            textBox10.Text = t4;
            textBox12.Text = t5;
            textBox13.Text = t6;
            textBox19.Text = t7;
            textBox20.Text = t8;
            textBox5.Text = t9;
            textBox14.Text = t10;
            textBox15.Text = t11;
            textBox16.Text = t12;
            textBox17.Text = t13;
            textBox18.Text = t14;
            textBox1.Text = t15;
            textBox4.Text = t16;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
