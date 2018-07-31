using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leo;

namespace ContractManagement
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            refresh();
        }

        public void refresh()
        {
            var sql = "select * from TB_TALLY_CONTRACT t";
            var dt = new Leo.SqlServer.DataAccess(RegistryKey.KeyPathTally).ExecuteTable(sql);
            dt.Columns[0].ColumnName = "委托单位";
            dt.Columns[1].ColumnName = "签约日期";
            dt.Columns[2].ColumnName = "履约日期";
            dt.Columns[3].ColumnName = "委托类别";
            dt.Columns[4].ColumnName = "委托事项";
            dt.Columns[5].ColumnName = "备注";
            dt.Columns[6].ColumnName = "附件";
            dt.Columns[7].ColumnName = "审核人";
            dt.Columns[8].ColumnName = "审核部门";
            dt.Columns[9].ColumnName = "审核状态";
            dataGridView1.DataSource= dt;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.refreshDelegate = refresh;
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.refreshDelegate = refresh;
            f.setdata(dataGridView1.CurrentRow.Cells["附件"].Value.ToString());
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.t1 = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            f.t2 = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            f.t3 = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            f.t4 = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            f.t5 = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            f.t6 = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            f.t7 = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            f.t8 = dataGridView1.CurrentRow.Cells[17].Value.ToString();
            f.t9 = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            f.t10 = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            f.t11 = dataGridView1.CurrentRow.Cells[20].Value.ToString();
            f.t12 = dataGridView1.CurrentRow.Cells[21].Value.ToString();
            f.t13 = dataGridView1.CurrentRow.Cells[22].Value.ToString();
            f.t14 = dataGridView1.CurrentRow.Cells[23].Value.ToString();
            f.t15 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f.t16 = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            f.refresh();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string aa = dataGridView1.CurrentRow.Cells["附件"].Value.ToString();
            string path = "http://www.lygtally.com/Contract/" + aa;
            System.Diagnostics.Process.Start(path); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sql = string.Format("select * from TB_TALLY_CONTRACT where company_delegate like '%{0}%'", textBox1.Text);
            var dt = new Leo.SqlServer.DataAccess(RegistryKey.KeyPathTally).ExecuteTable(sql);
            dt.Columns[0].ColumnName = "委托单位";
            dt.Columns[1].ColumnName = "签约日期";
            dt.Columns[2].ColumnName = "履约日期";
            dt.Columns[3].ColumnName = "委托类别";
            dt.Columns[4].ColumnName = "委托事项";
            dt.Columns[5].ColumnName = "备注";
            dt.Columns[6].ColumnName = "附件";
            dt.Columns[7].ColumnName = "审核人";
            dt.Columns[8].ColumnName = "审核部门";
            dt.Columns[9].ColumnName = "审核状态";
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
