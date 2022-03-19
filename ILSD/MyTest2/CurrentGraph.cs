using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Device_Query_Connection.Query_Namespace;

namespace MyTest2
{    //   Graph for Current Readings 
    public partial class CurrentGraph : Form
    {
        private PreparingConnection pc = new PreparingConnection();
        private DevicePlacing dp = new DevicePlacing();

        public CurrentGraph()
        {
            InitializeComponent();
        }

        private void CurrentGraph_Load(object sender, EventArgs e)
        {
            List<int> rm = new List<int>() { 201, 204, 205, 206, 210, 211 };
            for (int i = 0; i < rm.Count; i++)
            {
                DateTime dt = pc.Connection_Statement(dp.Room_WA(i), "current");
                List<double> rdt = pc.ReadingsCt(dp.Room_WA(rm[i]), "current");
                double rdh = pc.ReadingsCh(dp.Room_WA(rm[i]), "current");

                this.chart1.Series["Temperature"].Points.AddXY(Convert.ToString(dt), rdt[i]);
                this.chart1.Series["Humidity"].Points.AddXY(Convert.ToString(dt), rdh);

            }

            this.chart1.ChartAreas[0].AxisX.Title = "Timestamp";
            this.chart1.ChartAreas[0].AxisY.Title = "Temperature & Humidity readings";
        }
    }
}
