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
        public int AmountOfCells { get; set; }
        public int AmountOfInitialViruses { get; set; }
        public double VirusDisconnectionProbability { get; set; }
        public double VirusGrowthProbability { get; set; }
        public int NumberOfDays { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRunSimulation_Click(object sender, EventArgs e)
        {
            AmountOfCells = int.Parse(textBoxCells.Text);
            AmountOfInitialViruses = int.Parse(textBoxInitialViruses.Text);
            NumberOfDays = int.Parse(textBoxDays.Text);
            int precentageDisconnection = int.Parse(textBoxDisconnection.Text);
            int precentageReproducment = int.Parse(textBoxReproduction.Text);

            //converting to double: 
            VirusDisconnectionProbability = (double)precentageDisconnection / 100;
            VirusGrowthProbability = (double)precentageReproducment / 100;

            if (AmountOfInitialViruses > 0 && AmountOfCells > AmountOfInitialViruses && NumberOfDays > 0 & precentageDisconnection < 100 && precentageReproducment < 100)
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
            for (int i = 1;i<= patientStatistics.DaysRecords.Count;i++)
            {
                chart1.Series["Alive Viruses"].Points.AddXY(i, patientStatistics.DaysRecords[i-1].NumberOfAliveViruses);
                chart1.Series["Dead Viruses"].Points.AddXY(i, patientStatistics.DaysRecords[i-1].NumberOfDeadViruses);
                chart1.Series["Cells"].Points.AddXY(i, AmountOfCells);
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
                chartValues3.Add(new ObservablePoint(i, AmountOfCells));
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
            virusSimulation.InitSimulation(AmountOfCells,AmountOfInitialViruses,VirusDisconnectionProbability,VirusGrowthProbability);
            return virusSimulation.RunSimulation(NumberOfDays);
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            chart1.Printing.PrintPreview();
        }
    }
}
