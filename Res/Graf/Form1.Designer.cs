﻿namespace Graf
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.PotrosnjaChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PotrosnjaChart)).BeginInit();
            this.SuspendLayout();
            // 
            // PotrosnjaChart
            // 
            chartArea1.Name = "ChartArea1";
            this.PotrosnjaChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.PotrosnjaChart.Legends.Add(legend1);
            this.PotrosnjaChart.Location = new System.Drawing.Point(87, 33);
            this.PotrosnjaChart.Name = "PotrosnjaChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.DarkGreen;
            series1.Legend = "Legend1";
            series1.Name = "Potrosaci";
            this.PotrosnjaChart.Series.Add(series1);
            this.PotrosnjaChart.Size = new System.Drawing.Size(300, 300);
            this.PotrosnjaChart.TabIndex = 0;
            this.PotrosnjaChart.Text = "PotrosnjaChart";
            this.PotrosnjaChart.Click += new System.EventHandler(this.PotrosnjaChart_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(214, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PotrosnjaChart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PotrosnjaChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart PotrosnjaChart;
        private System.Windows.Forms.Button button1;
    }
}

