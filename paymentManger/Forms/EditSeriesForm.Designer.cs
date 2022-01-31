namespace paymentManger.Forms
{
    partial class EditSeriesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Test1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Test2");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSeriesForm));
            this.add_series_button = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.item_up_button = new System.Windows.Forms.Button();
            this.item_down_button = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.add_classsification_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // add_series_button
            // 
            this.add_series_button.Location = new System.Drawing.Point(172, 221);
            this.add_series_button.Name = "add_series_button";
            this.add_series_button.Size = new System.Drawing.Size(119, 23);
            this.add_series_button.TabIndex = 0;
            this.add_series_button.Text = "追加";
            this.add_series_button.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(12, 33);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(279, 182);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "グラフの分類一覧";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "分類基準";
            // 
            // item_up_button
            // 
            this.item_up_button.Location = new System.Drawing.Point(12, 221);
            this.item_up_button.Name = "item_up_button";
            this.item_up_button.Size = new System.Drawing.Size(34, 23);
            this.item_up_button.TabIndex = 0;
            this.item_up_button.Text = "↑";
            this.item_up_button.UseVisualStyleBackColor = true;
            // 
            // item_down_button
            // 
            this.item_down_button.Location = new System.Drawing.Point(52, 221);
            this.item_down_button.Name = "item_down_button";
            this.item_down_button.Size = new System.Drawing.Size(34, 23);
            this.item_down_button.TabIndex = 0;
            this.item_down_button.Text = "↓";
            this.item_down_button.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(301, 33);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(279, 182);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "項目名";
            this.columnHeader1.Width = 101;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "op";
            this.columnHeader2.Width = 29;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "値";
            // 
            // add_classsification_button
            // 
            this.add_classsification_button.Location = new System.Drawing.Point(461, 221);
            this.add_classsification_button.Name = "add_classsification_button";
            this.add_classsification_button.Size = new System.Drawing.Size(119, 23);
            this.add_classsification_button.TabIndex = 0;
            this.add_classsification_button.Text = "追加";
            this.add_classsification_button.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(586, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "---------------表の見方-------------------";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(586, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(332, 204);
            this.label4.TabIndex = 4;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // EditSeriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 256);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.item_down_button);
            this.Controls.Add(this.item_up_button);
            this.Controls.Add(this.add_classsification_button);
            this.Controls.Add(this.add_series_button);
            this.Name = "EditSeriesForm";
            this.Text = "EditSeriesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add_series_button;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button item_up_button;
        private System.Windows.Forms.Button item_down_button;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button add_classsification_button;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}