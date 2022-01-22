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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.load_original_data = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.OpenSettingForm_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea2.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea2.AxisX.LabelStyle.Format = "yy/MM";
            chartArea2.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea2.AxisX.ScaleView.SmallScrollMinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea2.AxisX.ScaleView.SmallScrollSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea2.AxisX.ScaleView.Zoomable = false;
            chartArea2.AxisX.Title = "年/月";
            chartArea2.AxisY.Title = "円";
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(9, 44);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series7.Legend = "Legend1";
            series7.Name = "娯楽";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series7.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series8.Legend = "Legend1";
            series8.Name = "サブスク(娯楽)";
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series8.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series9.Legend = "Legend1";
            series9.Name = "光熱費等";
            series9.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series9.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series10.Legend = "Legend1";
            series10.Name = "Streamの支払い";
            series10.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series10.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series11.Legend = "Legend1";
            series11.Name = "ネットスーパー";
            series11.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series11.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series12.Legend = "Legend1";
            series12.Name = "分割払い";
            series12.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series12.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Series.Add(series9);
            this.chart1.Series.Add(series10);
            this.chart1.Series.Add(series11);
            this.chart1.Series.Add(series12);
            this.chart1.Size = new System.Drawing.Size(776, 415);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // load_original_data
            // 
            this.load_original_data.Location = new System.Drawing.Point(9, 465);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(684, 465);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "新しい支払い";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // OpenSettingForm_Button
            // 
            this.OpenSettingForm_Button.Location = new System.Drawing.Point(164, 465);
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
            this.Controls.Add(this.button2);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button OpenSettingForm_Button;
    }
}

