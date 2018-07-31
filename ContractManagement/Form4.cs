using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Leo;
using System.Net;


namespace ContractManagement
{
    public partial class Form4 : Form
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        // 申明委托，与父窗体方法类型相同
        public delegate void RefreshDelegate();
        // 用来接收父窗体方法的委托变量
        public RefreshDelegate refreshDelegate;

        protected string filenamePr;
        public Form4()
        {
            InitializeComponent();
        }

        public void setdata(string filename)
        {
            filenamePr = filename;
            var sql = string.Format("select * from TB_TALLY_CONTRACT where ATTACHMENT = '{0}'", filename);
            var dt = new Leo.SqlServer.DataAccess(RegistryKey.KeyPathTally).ExecuteTable(sql);

            textBox1.Text = dt.Rows[0][0].ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0][1]);
            dateTimePicker2.Value = Convert.ToDateTime(dt.Rows[0][2]);
            textBox4.Text = dt.Rows[0][3].ToString();
            textBox5.Text = dt.Rows[0][4].ToString();
            textBox6.Text = dt.Rows[0][5].ToString();
            textBox7.Text = dt.Rows[0][6].ToString();
            textBox8.Text = dt.Rows[0][7].ToString();
            textBox9.Text = dt.Rows[0][8].ToString();

            textBox2.Text = dt.Rows[0][10].ToString();
            textBox11.Text = dt.Rows[0][11].ToString();
            textBox3.Text = dt.Rows[0][12].ToString();
            textBox10.Text = dt.Rows[0][13].ToString();
            textBox12.Text = dt.Rows[0][14].ToString();
            textBox13.Text = dt.Rows[0][15].ToString();
            textBox19.Text = dt.Rows[0][16].ToString();
            textBox20.Text = dt.Rows[0][17].ToString();
            dateTimePicker3.Value = Convert.ToDateTime(dt.Rows[0][18]);
            textBox14.Text = dt.Rows[0][19].ToString();
            textBox15.Text = dt.Rows[0][20].ToString();
            textBox16.Text = dt.Rows[0][21].ToString();
            textBox17.Text = dt.Rows[0][22].ToString();
            textBox18.Text = dt.Rows[0][23].ToString();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string aa = textBox7.Text;
            string path = "http://www.lygtally.com/Contract/" + aa;
            System.Diagnostics.Process.Start(path);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {

                string t1 = textBox1.Text;
                string t2 = Convert.ToString(dateTimePicker1.Value);
                string t3 = Convert.ToString(dateTimePicker2.Value);
                string t4 = textBox4.Text;
                string t5 = textBox5.Text;
                string t6 = textBox6.Text;
                string t7 = textBox7.Text;
                string t8 = textBox8.Text;
                string t9 = textBox9.Text;

                string t10 = textBox2.Text;
                string t11 = textBox11.Text;
                string t12 = textBox3.Text;
                string t13 = textBox10.Text;
                string t14 = textBox12.Text;
                string t15 = textBox13.Text;
                string t16 = textBox19.Text;
                string t17 = textBox20.Text;
                string t18 = Convert.ToString(dateTimePicker3.Value);
                string t19 = textBox14.Text;
                string t20 = textBox15.Text;
                string t21 = textBox16.Text;
                string t22 = textBox17.Text;
                string t23 = textBox18.Text;

                var sql = string.Format("delete from TB_TALLY_CONTRACT where ATTACHMENT = '{0}'", filenamePr);
                var dt = new Leo.SqlServer.DataAccess(RegistryKey.KeyPathTally).ExecuteTable(sql);

                sql = string.Format("INSERT INTO TB_TALLY_CONTRACT values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','已审核','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}')", t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23);
                dt = new Leo.SqlServer.DataAccess(RegistryKey.KeyPathTally).ExecuteTable(sql);
                MessageBox.Show("添加成功");
                this.Dispose();
                refreshDelegate();

            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
