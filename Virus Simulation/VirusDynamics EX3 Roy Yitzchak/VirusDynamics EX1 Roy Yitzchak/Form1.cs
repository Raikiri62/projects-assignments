using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace VirusDynamics_EX1_Roy_Yitzchak
{
    public partial class Form1 : Form
    {
        public int NumberOfDays { get; set; }
        //private List<int> Medications;
        private List<Medication> Medications;
        public Form1()
        {
            InitializeComponent();
            Medications = new List<Medication>();
        }

        private void buttonRunSimulation_Click(object sender, EventArgs e)
        {
            NumberOfDays = int.Parse(textBoxDays.Text);
            if(NumberOfDays > 0)
            {
                PatientStatistics patientStatistics = fetchSimulationResult();
                ShowStatisticalResults(patientStatistics);
            }
            else
            {
                MessageBox.Show("Some of the parameters that you have entered are not legal to the simulation!");
                MessageBox.Show("Simulation Canceled.");
            }
        }

        private void ShowStatisticalResults(PatientStatistics patientStatistics)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            chart2.Series["s1"].Points.Clear();
            for (int i = 1; i <= patientStatistics.DaysRecords.Count; i++)
            {
                chart1.Series["Alive Viruses"].Points.AddXY(i, patientStatistics.DaysRecords[i - 1].NumberOfAliveViruses);
                //chart1.Series["Dead Viruses"].Points.AddXY(i, patientStatistics.DaysRecords[i - 1].NumberOfDeadViruses);
                chart1.Series["Cells"].Points.AddXY(i, 1000);
            }
            var size = patientStatistics.DaysRecords.Count;
            var record = patientStatistics.DaysRecords[size - 1];
            chart2.Series["s1"].Points.AddXY("Alive Viruses",record.NumberOfAliveViruses);
            chart2.Series["s1"].Points.AddXY("Healthy cells", 1000 - record.NumberOfAliveViruses);
        }

        private PatientStatistics fetchSimulationResult()
        {
            VirusSimulation virusSimulation = new VirusSimulation();
            if (Medications != null && Medications.Count > 0)
            {
                virusSimulation.InitSimulation(Medications);
            }
            else
            {
                virusSimulation.InitSimulation(null);
            }
            return virusSimulation.RunSimulation(NumberOfDays);
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            chart1.Printing.PrintPreview();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InsertMedication(15,15);
            InsertMedication(30,15);
            chart2.Titles.Add("Pie Chart: Healthy cells to infected cells; Ratio");
        }
        private void InsertMedication(int OnDay,int Period)
        {
            Medications.Add(new Medication(OnDay,Period));
            listBoxMeds.Items.Add("Medication on day: " + OnDay + " effect: " + Period + " days");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Medications.Clear();
            listBoxMeds.Items.Clear();
        }

        private void buttonAddMed_Click(object sender, EventArgs e)
        {
            string dayString = textBoxMedDay.Text;
            int day = int.Parse(dayString);

            string periodString = textBoxMedPeriod.Text;
            int period = int.Parse(periodString);

            if (day > 0 && period > 0)
            {
                InsertMedication(day,period);
            }
            textBoxMedDay.Clear();
            textBoxMedPeriod.Clear();
        }
    }
}
