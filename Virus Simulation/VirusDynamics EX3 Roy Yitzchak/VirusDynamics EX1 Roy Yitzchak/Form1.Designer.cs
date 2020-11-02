namespace VirusDynamics_EX1_Roy_Yitzchak
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMedDay = new System.Windows.Forms.TextBox();
            this.buttonAddMed = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.listBoxMeds = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxDays = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRunSimulation = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMedPeriod = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(752, 12);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.Blue;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Color = System.Drawing.Color.MediumSeaGreen;
            series1.Legend = "Legend1";
            series1.Name = "Cells";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series2.Color = System.Drawing.Color.Crimson;
            series2.Legend = "Legend1";
            series2.Name = "Alive Viruses";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(493, 263);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.textBoxMedPeriod);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxMedDay);
            this.panel1.Controls.Add(this.buttonAddMed);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Controls.Add(this.listBoxMeds);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.textBoxDays);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonRunSimulation);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 226);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Add medication on day:";
            // 
            // textBoxMedDay
            // 
            this.textBoxMedDay.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMedDay.Location = new System.Drawing.Point(153, 143);
            this.textBoxMedDay.Name = "textBoxMedDay";
            this.textBoxMedDay.Size = new System.Drawing.Size(76, 23);
            this.textBoxMedDay.TabIndex = 15;
            // 
            // buttonAddMed
            // 
            this.buttonAddMed.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonAddMed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddMed.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddMed.ForeColor = System.Drawing.Color.Black;
            this.buttonAddMed.Location = new System.Drawing.Point(245, 137);
            this.buttonAddMed.Name = "buttonAddMed";
            this.buttonAddMed.Size = new System.Drawing.Size(130, 32);
            this.buttonAddMed.TabIndex = 14;
            this.buttonAddMed.Text = "Add Medication";
            this.buttonAddMed.UseVisualStyleBackColor = false;
            this.buttonAddMed.Click += new System.EventHandler(this.buttonAddMed_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClear.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.ForeColor = System.Drawing.Color.Black;
            this.buttonClear.Location = new System.Drawing.Point(381, 77);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(99, 32);
            this.buttonClear.TabIndex = 13;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // listBoxMeds
            // 
            this.listBoxMeds.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMeds.FormattingEnabled = true;
            this.listBoxMeds.ItemHeight = 16;
            this.listBoxMeds.Location = new System.Drawing.Point(22, 49);
            this.listBoxMeds.Name = "listBoxMeds";
            this.listBoxMeds.Size = new System.Drawing.Size(353, 68);
            this.listBoxMeds.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VirusDynamics_EX1_Roy_Yitzchak.Properties.Resources.virus;
            this.pictureBox1.Location = new System.Drawing.Point(515, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxDays
            // 
            this.textBoxDays.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxDays.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDays.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.textBoxDays.Location = new System.Drawing.Point(385, 10);
            this.textBoxDays.Name = "textBoxDays";
            this.textBoxDays.Size = new System.Drawing.Size(84, 29);
            this.textBoxDays.TabIndex = 6;
            this.textBoxDays.Text = "40";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkViolet;
            this.label3.Location = new System.Drawing.Point(18, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Num Of Days (iterations):";
            // 
            // buttonRunSimulation
            // 
            this.buttonRunSimulation.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonRunSimulation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRunSimulation.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRunSimulation.ForeColor = System.Drawing.Color.Black;
            this.buttonRunSimulation.Location = new System.Drawing.Point(491, 153);
            this.buttonRunSimulation.Name = "buttonRunSimulation";
            this.buttonRunSimulation.Size = new System.Drawing.Size(177, 59);
            this.buttonRunSimulation.TabIndex = 1;
            this.buttonRunSimulation.Text = "Run Simulation Safely";
            this.buttonRunSimulation.UseVisualStyleBackColor = false;
            this.buttonRunSimulation.Click += new System.EventHandler(this.buttonRunSimulation_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPrint.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.ForeColor = System.Drawing.Color.Black;
            this.buttonPrint.Location = new System.Drawing.Point(1120, 215);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(99, 32);
            this.buttonPrint.TabIndex = 12;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(332, 337);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "s1";
            this.chart2.Series.Add(series3);
            this.chart2.Size = new System.Drawing.Size(536, 300);
            this.chart2.TabIndex = 13;
            this.chart2.Text = "chart2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Effection Period:";
            // 
            // textBoxMedPeriod
            // 
            this.textBoxMedPeriod.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMedPeriod.Location = new System.Drawing.Point(153, 177);
            this.textBoxMedPeriod.Name = "textBoxMedPeriod";
            this.textBoxMedPeriod.Size = new System.Drawing.Size(76, 23);
            this.textBoxMedPeriod.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::VirusDynamics_EX1_Roy_Yitzchak.Properties.Resources.covid_4941846_640;
            this.ClientSize = new System.Drawing.Size(1301, 704);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virus Dynamics Simulation EX2 By Roy Yitzchak";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRunSimulation;
        private System.Windows.Forms.TextBox textBoxDays;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.ListBox listBoxMeds;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonAddMed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMedDay;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TextBox textBoxMedPeriod;
        private System.Windows.Forms.Label label2;
    }
}

