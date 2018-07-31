using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Leo;

namespace ContractManagement
{
    public partial class Form2 : Form
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        // 申明委托，与父窗体方法类型相同
        public delegate void RefreshDelegate();
        // 用来接收父窗体方法的委托变量
        public RefreshDelegate refreshDelegate;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "PDF文件(*.pdf)|*.pdf";

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string FileName = this.openFileDialog1.FileName;
                // 你的 处理文件路径代码 
                textBox7.Text = FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {http://www.lygtally.com/Contract/
            try
            {
                WebClient webclient = new WebClient();
                if (this.openFileDialog1.FileName == "")
                {
                    MessageBox.Show("请添加附件");
                    return;
                }
                byte[] responseArray = webclient.UploadFile("http://www.lygtally.com/Contract/upload.aspx", "POST", @"" + this.openFileDialog1.FileName + "");

                string getPath =  Encoding.GetEncoding("UTF-8").GetString(responseArray);


                var arr = Leo.Json.JsonConvert.DeserializeObject<string[]>(getPath);

                string t1=textBox1.Text;
                string t2=Convert.ToString(dateTimePicker1.Value);
                string t3=Convert.ToString(dateTimePicker2.Value);
                string t4=textBox4.Text;
                string t5=textBox5.Text;
                string t6=textBox6.Text;
                string t7=arr[1];
                string t8=textBox8.Text;
                string t9=textBox9.Text;

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


                if (arr[0] == "YES")
                {
                    var sql = string.Format("INSERT INTO TB_TALLY_CONTRACT values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','已审核','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}')", t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23);
                    var dt = new Leo.SqlServer.DataAccess(RegistryKey.KeyPathTally).ExecuteTable(sql);
                    MessageBox.Show("添加成功");
                    this.Dispose();
                    refreshDelegate();
                }
                else
                {
                    MessageBox.Show("上传附件失败，请检查网络");
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
