namespace paymentManger
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.load_original_data = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OpenSettingForm_Button = new System.Windows.Forms.Button();
          
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea1.AxisX.LabelStyle.Format = "yy/MM";
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea1.AxisX.ScaleView.SmallScrollMinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea1.AxisX.ScaleView.SmallScrollSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea1.AxisX.ScaleView.Zoomable = false;
            chartArea1.AxisX.Title = "年/月";
            chartArea1.AxisY.Title = "円";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 88);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(776, 415);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // load_original_data
            // 
            this.load_original_data.Location = new System.Drawing.Point(550, 465);
            this.load_original_data.Name = "load_original_data";
            this.load_original_data.Size = new System.Drawing.Size(149, 23);
            this.load_original_data.TabIndex = 1;
            this.load_original_data.Text = "支払明細書を読み込む";
            this.load_original_data.UseVisualStyleBackColor = true;
            this.load_original_data.Click += new System.EventHandler(this.load_original_data_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));

            this.label1.Location = new System.Drawing.Point(288, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "支払いの内訳";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(791, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 401);
            this.panel1.TabIndex = 4;
            // 
            // OpenSettingForm_Button
            // 
            this.OpenSettingForm_Button.Location = new System.Drawing.Point(705, 465);
            this.OpenSettingForm_Button.Name = "OpenSettingForm_Button";
            this.OpenSettingForm_Button.Size = new System.Drawing.Size(75, 23);
            this.OpenSettingForm_Button.TabIndex = 5;
            this.OpenSettingForm_Button.Text = "設定";
            this.OpenSettingForm_Button.UseVisualStyleBackColor = true;
            this.OpenSettingForm_Button.Click += new System.EventHandler(this.OpenSettingForm_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 495);
            this.Controls.Add(this.OpenSettingForm_Button);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.load_original_data);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

#endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button load_original_data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button OpenSettingForm_Button;
    }
}

