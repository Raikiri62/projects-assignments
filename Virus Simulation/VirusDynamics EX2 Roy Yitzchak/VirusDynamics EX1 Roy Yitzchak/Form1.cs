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
        private List<int> Medications;
        public Form1()
        {
            InitializeComponent();
            Medications = new List<int>();
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
            for (int i = 1; i <= patientStatistics.DaysRecords.Count; i++)
            {
                chart1.Series["Alive Viruses"].Points.AddXY(i, patientStatistics.DaysRecords[i - 1].NumberOfAliveViruses);
                chart1.Series["Dead Viruses"].Points.AddXY(i, patientStatistics.DaysRecords[i - 1].NumberOfDeadViruses);
                chart1.Series["Cells"].Points.AddXY(i, 1000);
            }

            var seriesCollection = new SeriesCollection();

            var lineSeries = new LineSeries();
            //lineSeries.Name = "Alive Viruses";
            lineSeries.Stroke = System.Windows.Media.Brushes.Black;
            lineSeries.Fill = System.Windows.Media.Brushes.Red;
            var chartValues = new ChartValues<ObservablePoint>();

            var lineSeries2 = new LineSeries();
            var chartValues2 = new ChartValues<ObservablePoint>();

            lineSeries2.Stroke = System.Windows.Media.Brushes.Black;
            lineSeries2.Fill = System.Windows.Media.Brushes.Blue;

            var lineSeries3 = new LineSeries();
            var chartValues3 = new ChartValues<ObservablePoint>();

            lineSeries3.Stroke = System.Windows.Media.Brushes.Black;
            //lineSeries3.Fill = System.Windows.Media.Brushes.MediumSeaGreen;

            for (int i = 0; i < patientStatistics.DaysRecords.Count; i++)
            {
                //chart1.Series["Alive Viruses"].Points.AddXY(i, patientStatistics.DaysRecords[i].NumberOfAliveViruses);
                //chart1.Series["Dead Viruses"].Points.AddXY(i, patientStatistics.DaysRecords[i].NumberOfDeadViruses);
                //chart1.Series["Cells"].Points.AddXY(i, AmountOfCells);
                chartValues.Add(new ObservablePoint(i, patientStatistics.DaysRecords[i].NumberOfAliveViruses));
                chartValues2.Add(new ObservablePoint(i, patientStatistics.DaysRecords[i].NumberOfDeadViruses));
                chartValues3.Add(new ObservablePoint(i, 1000));
            }
            lineSeries.Values = chartValues;
            lineSeries2.Values = chartValues2;
            lineSeries3.Values = chartValues3;
            seriesCollection.Add(lineSeries);
            seriesCollection.Add(lineSeries2);
            seriesCollection.Add(lineSeries3);
            cartesianChart1.Series = seriesCollection;


        }

        private PatientStatistics fetchSimulationResult()
        {
            VirusSimulation virusSimulation = new VirusSimulation();
            if (Medications != null && Medications.Count > 0)
            {
                virusSimulation.InitSimulation(Medications.ToArray());
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
            InsertMedication(15);
            InsertMedication(30);
        }
        private void InsertMedication(int OnDay)
        {
            Medications.Add(OnDay);
            listBoxMeds.Items.Add("Medication on day: " + OnDay);
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
            if(day > 0)
            {
                InsertMedication(day);
            }
            textBoxMedDay.Clear();
        }
    }
}
