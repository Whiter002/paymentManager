#if DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paymentManger.Forms
{
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ColumnCount = 3;
            this.dataGridView1.Columns[0].Name = "日本語";
            this.dataGridView1.Columns[1].Name = "ローマ数字";
            this.dataGridView1.Columns[2].Name = "スペイン語";

            this.dataGridView1.Rows.Add("いち","1","uno");
            this.dataGridView1.Rows.Add("に", "2", "dos");
            this.dataGridView1.Rows.Add("さん", "3", "tress");
            this.dataGridView1.AutoResizeRow(0);
            this.dataGridView1.AutoResizeRow(1);
            this.dataGridView1.AutoResizeRow(2);
        }
    }
}

#endif
