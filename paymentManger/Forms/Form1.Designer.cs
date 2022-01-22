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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            chartArea3.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea3.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea3.AxisX.LabelStyle.Format = "yy/MM";
            chartArea3.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea3.AxisX.ScaleView.SmallScrollMinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea3.AxisX.ScaleView.SmallScrollSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea3.AxisX.ScaleView.Zoomable = false;
            chartArea3.AxisX.Title = "年/月";
            chartArea3.AxisY.Title = "円";
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(9, 44);
            this.chart1.Name = "chart1";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series13.Legend = "Legend1";
            series13.Name = "娯楽";
            series13.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series13.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series14.Legend = "Legend1";
            series14.Name = "サブスク(娯楽)";
            series14.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series14.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series15.Legend = "Legend1";
            series15.Name = "光熱費等";
            series15.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series15.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series16.Legend = "Legend1";
            series16.Name = "Streamの支払い";
            series16.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series16.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
            series17.ChartArea = "ChartArea1";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series17.Legend = "Legend1";
            series17.Name = "ネットスーパー";
            series17.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series17.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series18.ChartArea = "ChartArea1";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series18.Legend = "Legend1";
            series18.Name = "分割払い";
            series18.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series18.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chart1.Series.Add(series13);
            this.chart1.Series.Add(series14);
            this.chart1.Series.Add(series15);
            this.chart1.Series.Add(series16);
            this.chart1.Series.Add(series17);
            this.chart1.Series.Add(series18);
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

