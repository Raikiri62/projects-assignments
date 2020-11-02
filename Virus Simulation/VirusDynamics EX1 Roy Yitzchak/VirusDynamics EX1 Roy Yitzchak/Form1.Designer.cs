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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxReproduction = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDisconnection = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDays = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInitialViruses = new System.Windows.Forms.TextBox();
            this.buttonRunSimulation = new System.Windows.Forms.Button();
            this.textBoxCells = new System.Windows.Forms.TextBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(752, 12);
            this.chart1.Name = "chart1";
            series7.BorderColor = System.Drawing.Color.Blue;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series7.Color = System.Drawing.Color.MediumSeaGreen;
            series7.Legend = "Legend1";
            series7.Name = "Cells";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series8.Color = System.Drawing.Color.Crimson;
            series8.Legend = "Legend1";
            series8.Name = "Alive Viruses";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series9.Color = System.Drawing.Color.DimGray;
            series9.Legend = "Legend1";
            series9.Name = "Dead Viruses";
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Series.Add(series9);
            this.chart1.Size = new System.Drawing.Size(493, 263);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.textBoxReproduction);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxDisconnection);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxDays);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxInitialViruses);
            this.panel1.Controls.Add(this.buttonRunSimulation);
            this.panel1.Controls.Add(this.textBoxCells);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 226);
            this.panel1.TabIndex = 2;
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
            // textBoxReproduction
            // 
            this.textBoxReproduction.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxReproduction.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxReproduction.ForeColor = System.Drawing.Color.Black;
            this.textBoxReproduction.Location = new System.Drawing.Point(383, 151);
            this.textBoxReproduction.Name = "textBoxReproduction";
            this.textBoxReproduction.Size = new System.Drawing.Size(84, 29);
            this.textBoxReproduction.TabIndex = 10;
            this.textBoxReproduction.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkViolet;
            this.label5.Location = new System.Drawing.Point(18, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(354, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Virus Reproduction probability (precentage %):";
            // 
            // textBoxDisconnection
            // 
            this.textBoxDisconnection.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxDisconnection.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDisconnection.ForeColor = System.Drawing.Color.Black;
            this.textBoxDisconnection.Location = new System.Drawing.Point(382, 112);
            this.textBoxDisconnection.Name = "textBoxDisconnection";
            this.textBoxDisconnection.Size = new System.Drawing.Size(84, 29);
            this.textBoxDisconnection.TabIndex = 8;
            this.textBoxDisconnection.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkViolet;
            this.label4.Location = new System.Drawing.Point(18, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(358, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Virus Disconnection probability (precentage %):";
            // 
            // textBoxDays
            // 
            this.textBoxDays.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxDays.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDays.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.textBoxDays.Location = new System.Drawing.Point(383, 76);
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
            this.label3.Location = new System.Drawing.Point(18, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Num Of Days (iterations):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkViolet;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Num Of Initial Viruses:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkViolet;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Num Of Cells:";
            // 
            // textBoxInitialViruses
            // 
            this.textBoxInitialViruses.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxInitialViruses.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInitialViruses.ForeColor = System.Drawing.Color.Red;
            this.textBoxInitialViruses.Location = new System.Drawing.Point(383, 41);
            this.textBoxInitialViruses.Name = "textBoxInitialViruses";
            this.textBoxInitialViruses.Size = new System.Drawing.Size(84, 29);
            this.textBoxInitialViruses.TabIndex = 2;
            this.textBoxInitialViruses.Text = "100";
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
            // textBoxCells
            // 
            this.textBoxCells.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxCells.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCells.ForeColor = System.Drawing.Color.Green;
            this.textBoxCells.Location = new System.Drawing.Point(383, 7);
            this.textBoxCells.Name = "textBoxCells";
            this.textBoxCells.Size = new System.Drawing.Size(84, 29);
            this.textBoxCells.TabIndex = 0;
            this.textBoxCells.Text = "1000";
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
            // cartesianChart1
            // 
            this.cartesianChart1.BackColor = System.Drawing.Color.White;
            this.cartesianChart1.Location = new System.Drawing.Point(108, 303);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(1049, 389);
            this.cartesianChart1.TabIndex = 14;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::VirusDynamics_EX1_Roy_Yitzchak.Properties.Resources.covid_4941846_640;
            this.ClientSize = new System.Drawing.Size(1268, 704);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virus Dynamics Simulation EX1 By Roy Yitzchak";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRunSimulation;
        private System.Windows.Forms.TextBox textBoxCells;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInitialViruses;
        private System.Windows.Forms.TextBox textBoxReproduction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDisconnection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDays;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonPrint;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
    }
}

