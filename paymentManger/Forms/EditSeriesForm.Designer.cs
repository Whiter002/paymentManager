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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSeriesForm));
            this.add_series_button = new System.Windows.Forms.Button();
            this.Series_list = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.優先度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.表示順番ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Classification_list = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.add_classsification_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
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
            // Series_list
            // 
            this.Series_list.AllowColumnReorder = true;
            this.Series_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.Series_list.ContextMenuStrip = this.contextMenuStrip1;
            this.Series_list.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Series_list.FullRowSelect = true;
            this.Series_list.GridLines = true;
            this.Series_list.HideSelection = false;
            this.Series_list.LabelEdit = true;
            this.Series_list.Location = new System.Drawing.Point(12, 33);
            this.Series_list.MultiSelect = false;
            this.Series_list.Name = "Series_list";
            this.Series_list.Size = new System.Drawing.Size(279, 182);
            this.Series_list.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.Series_list.TabIndex = 2;
            this.Series_list.UseCompatibleStateImageBehavior = false;
            this.Series_list.View = System.Windows.Forms.View.Details;
            this.Series_list.Click += new System.EventHandler(this.Series_list_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "分類名";
            this.columnHeader4.Width = 124;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "優先度";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "描画順";
            this.columnHeader6.Width = 85;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.優先度ToolStripMenuItem,
            this.表示順番ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 48);
            // 
            // 優先度ToolStripMenuItem
            // 
            this.優先度ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.優先度ToolStripMenuItem.Name = "優先度ToolStripMenuItem";
            this.優先度ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.優先度ToolStripMenuItem.Text = "優先度";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(30, 23);
            // 
            // 表示順番ToolStripMenuItem
            // 
            this.表示順番ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2});
            this.表示順番ToolStripMenuItem.Name = "表示順番ToolStripMenuItem";
            this.表示順番ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.表示順番ToolStripMenuItem.Text = "表示順番";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(30, 23);
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
            // Classification_list
            // 
            this.Classification_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.Classification_list.HideSelection = false;
            this.Classification_list.Location = new System.Drawing.Point(301, 33);
            this.Classification_list.Name = "Classification_list";
            this.Classification_list.Size = new System.Drawing.Size(279, 182);
            this.Classification_list.TabIndex = 2;
            this.Classification_list.UseCompatibleStateImageBehavior = false;
            this.Classification_list.View = System.Windows.Forms.View.Details;
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
            this.columnHeader3.Width = 173;
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
            this.ClientSize = new System.Drawing.Size(587, 251);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Classification_list);
            this.Controls.Add(this.Series_list);
            this.Controls.Add(this.add_classsification_button);
            this.Controls.Add(this.add_series_button);
            this.Name = "EditSeriesForm";
            this.Text = "EditSeriesForm";
            this.Shown += new System.EventHandler(this.EditSeriesForm_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add_series_button;
        private System.Windows.Forms.ListView Series_list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView Classification_list;
        private System.Windows.Forms.Button add_classsification_button;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 優先度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表示順番ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}