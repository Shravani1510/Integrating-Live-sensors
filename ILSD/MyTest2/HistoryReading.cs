using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Device_Query_Connection.Query_Namespace;

namespace MyTest2
{
    public partial class HistoryReading : System.Windows.Forms.Form
    {
        private UIApplication uiapp;
        private UIDocument uidoc;
        private Document doc;

        //creating instance of DevicePlacing, PreparingConnection.
        private DevicePlacing dp = new DevicePlacing();
        private PreparingConnection pc = new PreparingConnection();
        Autodesk.Revit.DB.Color color = null;

        public HistoryReading(ExternalCommandData commandData)
        {
            InitializeComponent();
            uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            doc = uidoc.Document;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ElementId id1 = new ElementId(540471);
            Element e1 = doc.GetElement(id1);
            Parameter parameter = e1.LookupParameter("H");

            List<double> d = pc.ReadingsHh(dp.Room_WA(201), "history");
            List<double> d2 = pc.ReadingsHt(dp.Room_WA(201), "history");
            using (Transaction t = new Transaction(doc, "parameter"))
            {
                t.Start();
                try
                {
                    parameter.Set(d.Max());
                    t.Commit();
                }


                catch (Exception err)
                {
                    TaskDialog.Show("Error", err.Message);

                }
            }
            Parameter parameter2 = e1.LookupParameter("Temperature");
            using (Transaction t1 = new Transaction(doc, "parameter2"))
            {
                t1.Start();
                try
                {
                    parameter2.Set(273.15 + d2.Min());
                    t1.Commit();
                }


                catch (Exception err)
                {
                    TaskDialog.Show("Error", err.Message);

                }
            }


            ElementId ih1 = new ElementId(626452);
            var get_humidity = d.Max();

            if (get_humidity <= 30 || get_humidity <= 44)
            {
                // Console.WriteLine("Pale Green");
                color = new Autodesk.Revit.DB.Color((byte)152, (byte)251, (byte)152);
            }
            else if (get_humidity >= 45 || get_humidity >= 60)
            {
                //Console.WriteLine("beep sky blue");
                color = new Autodesk.Revit.DB.Color((byte)0, (byte)191, (byte)255);
            }

            OverrideGraphicSettings ogs = new OverrideGraphicSettings();

            ogs.SetProjectionLineColor(color);

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Change Element Color");

                doc.ActiveView.SetElementOverrides(ih1, ogs);
                tx.Commit();
            }

            ElementId it1 = new ElementId(627700);
            double get_temp = d2.Min();
            if (get_temp <= 18.5 || get_temp <= 24.9)
            {
                // Console.WriteLine("Red");
                color = new Autodesk.Revit.DB.Color((byte)255, (byte)0, (byte)0);
            }
            else if (get_temp >= 25 || get_temp >= 35)
            {
                //Console.WriteLine("orange");
                color = new Autodesk.Revit.DB.Color((byte)255, (byte)165, (byte)0);
            }
            OverrideGraphicSettings ogs1 = new OverrideGraphicSettings();
            ogs1.SetProjectionLineColor(color);

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Change Element Color");
                doc.ActiveView.SetElementOverrides(it1, ogs1);
                tx.Commit();
            }
            List<DateTime> dt = pc.Get_Timet("history");

            for (int i = 0; i < dt.Count; i++)
            {
                this.chart1.Series["Temperature"].Points.AddXY(Convert.ToString(dt[i]), d2[i]);
            }
            this.chart1.ChartAreas[0].AxisX.Title = "Timestamp";
            this.chart1.ChartAreas[0].AxisY.Title = "Temperature readings";
           
            for (int i = 0; i < dt.Count; i++)
            {
                this.chart2.Series["Humidity"].Points.AddXY(Convert.ToString(dt[i]), d[i]);
            }
            this.chart2.ChartAreas[0].AxisX.Title = "Timestamp";
            this.chart2.ChartAreas[0].AxisY.Title = "humidity readings";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ElementId id2 = new ElementId(543001);
            Element e1 = doc.GetElement(id2);
            Parameter parameter = e1.LookupParameter("H");

            List<double> d = pc.ReadingsHh(dp.Room_WA(204), "history");
            List<double> d2 = pc.ReadingsHt(dp.Room_WA(204), "history");
            using (Transaction t = new Transaction(doc, "parameter"))
            {
                t.Start();
                try
                {
                    parameter.Set(d.Max());
                    t.Commit();
                }


                catch (Exception err)
                {
                    TaskDialog.Show("Error", err.Message);

                }
            }
            Parameter parameter2 = e1.LookupParameter("Temperature");
            using (Transaction t1 = new Transaction(doc, "parameter2"))
            {
                t1.Start();
                try
                {
                    parameter2.Set(273.15 + d2.Min());
                    t1.Commit();
                }


                catch (Exception err)
                {
                    TaskDialog.Show("Error", err.Message);

                }
            }
            ElementId ih2 = new ElementId(627851);
            ElementId it2 = new ElementId(627968);

            var get_humidity = d.Max();

            if (get_humidity <= 30 || get_humidity <= 44)
            {
                // Console.WriteLine("Pale Green");
                color = new Autodesk.Revit.DB.Color((byte)152, (byte)251, (byte)152);
            }
            else if (get_humidity >= 45 || get_humidity >= 60)
            {
                //Console.WriteLine("beep sky blue");
                color = new Autodesk.Revit.DB.Color((byte)0, (byte)191, (byte)255);
            }

            OverrideGraphicSettings ogs = new OverrideGraphicSettings();

            ogs.SetProjectionLineColor(color);

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Change Element Color");

                doc.ActiveView.SetElementOverrides(ih2, ogs);
                tx.Commit();
            }

            ElementId it1 = new ElementId(627700);
            double get_temp = d2.Min();
            if (get_temp <= 18.5 || get_temp <= 24.9)
            {
                // Console.WriteLine("Red");
                color = new Autodesk.Revit.DB.Color((byte)255, (byte)0, (byte)0);
            }
            else if (get_temp >= 25 || get_temp >= 35)
            {
                //Console.WriteLine("orange");
                color = new Autodesk.Revit.DB.Color((byte)255, (byte)165, (byte)0);
            }
            OverrideGraphicSettings ogs1 = new OverrideGraphicSettings();
            ogs1.SetProjectionLineColor(color);

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Change Element Color");
                doc.ActiveView.SetElementOverrides(it2, ogs1);
                tx.Commit();
            }
            List<DateTime> dt = pc.Get_Timet("history");

            for (int i = 0; i < dt.Count; i++)
            {

                this.chart1.Series["Temperature"].Points.AddXY(Convert.ToString(dt[i]), d2[i]);
            }
            this.chart1.ChartAreas[0].AxisX.Title = "TimeStamp";
            this.chart1.ChartAreas[0].AxisY.Title = "Temperature readings";
            
            for (int i = 0; i < dt.Count; i++)
            {
                this.chart2.Series["Humidity"].Points.AddXY(Convert.ToString(dt[i]), d[i]);
            }
            this.chart2.ChartAreas[0].AxisX.Title = "Timestamp";
            this.chart2.ChartAreas[0].AxisY.Title = " humidity readings";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            ElementId id3 = new ElementId(544350);
            Element e1 = doc.GetElement(id3);
            Parameter parameter = e1.LookupParameter("H");

            List<double> d = pc.ReadingsHh(dp.Room_WA(205), "history");
            List<double> d2 = pc.ReadingsHt(dp.Room_WA(205), "history");
            using (Transaction t = new Transaction(doc, "parameter"))
            {
                t.Start();
                try
                {
                    parameter.Set(d.Max());
                    t.Commit();
                }


                catch (Exception err)
                {
                    TaskDialog.Show("Error", err.Message);

                }
            }
            Parameter parameter2 = e1.LookupParameter("Temperature");
            using (Transaction t1 = new Transaction(doc, "parameter2"))
            {
                t1.Start();
                try
                {
                    parameter2.Set(273.15 + d2.Min());
                    t1.Commit();
                }


                catch (Exception err)
                {
                    TaskDialog.Show("Error", err.Message);

                }
            }
            ElementId ih3 = new ElementId(628617);
            ElementId it3 = new ElementId(628510);
            var get_humidity = d.Max();

            if (get_humidity <= 30 || get_humidity <= 44)
            {
                // Console.WriteLine("Pale Green");
                color = new Autodesk.Revit.DB.Color((byte)152, (byte)251, (byte)152);
            }
            else if (get_humidity >= 45 || get_humidity >= 60)
            {
                //Console.WriteLine("beep sky blue");
                color = new Autodesk.Revit.DB.Color((byte)0, (byte)191, (byte)255);
            }

            OverrideGraphicSettings ogs = new OverrideGraphicSettings();

            ogs.SetProjectionLineColor(color);

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Change Element Color");

                doc.ActiveView.SetElementOverrides(ih3, ogs);
                tx.Commit();
            }
            double get_temp = d2.Min();
            if (get_temp <= 18.5 || get_temp <= 24.9)
            {
                // Console.WriteLine("Red");
                color = new Autodesk.Revit.DB.Color((byte)255, (byte)0, (byte)0);
            }
            else if (get_temp >= 25 || get_temp >= 35)
            {
                //Console.WriteLine("orange");
                color = new Autodesk.Revit.DB.Color((byte)255, (byte)165, (byte)0);
            }
            OverrideGraphicSettings ogs1 = new OverrideGraphicSettings();
            ogs1.SetProjectionLineColor(color);

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Change Element Color");
                doc.ActiveView.SetElementOverrides(it3, ogs1);
                tx.Commit();
            }
            List<DateTime> dt = pc.Get_Timet("history");

            for (int i = 0; i < dt.Count; i++)
            {
                this.chart1.Series["Temperature"].Points.AddXY(Convert.ToString(dt[i]), d2[i]);
            }
            this.chart1.ChartAreas[0].AxisX.Title = "Timestamp";
            this.chart1.ChartAreas[0].AxisY.Title = "Temperature readings";
           
            for (int i = 0; i < dt.Count; i++)
            {
                this.chart2.Series["Humidity"].Points.AddXY(Convert.ToString(dt[i]), d[i]);
            }
            this.chart2.ChartAreas[0].AxisX.Title = "Timestamp";
            this.chart2.ChartAreas[0].AxisY.Title = " humidity readings";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            ElementId id4 = new ElementId(545596);
            Element e1 = doc.GetElement(id4);
            Parameter parameter = e1.LookupParameter("H");

            List<double> d = pc.ReadingsHh(dp.Room_WA(206), "history");
            List<double> d2 = pc.ReadingsHt(dp.Room_WA(206), "history");
            using (Transaction t = new Transaction(doc, "parameter"))
            {
                t.Start();
                try
                {
                    parameter.Set(d.Max());
                    t.Commit();
                }


                catch (Exception err)
                {
                    TaskDialog.Show("Error", err.Message);

                }
            }
            Parameter parameter2 = e1.LookupParameter("Temperature");
            using (Transaction t1 = new Transaction(doc, "parameter2"))
            {
                t1.Start();
                try
                {
                    parameter2.Set(273.15 + d2.Min());
                    t1.Commit();
                }


                catch (Exception err)
                {
                    TaskDialog.Show("Error", err.Message);

                }
            }

            ElementId ih4 = new ElementId(628989);
            ElementId it4 = new ElementId(628770);
            var get_humidity = d.Max();

            if (get_humidity <= 30 || get_humidity <= 44)
            {
                // Console.WriteLine("Pale Green");
                color = new Autodesk.Revit.DB.Color((byte)152, (byte)251, (byte)152);
            }
            else if (get_humidity >= 45 || get_humidity >= 60)
            {
                //Console.WriteLine("beep sky blue");
                color = new Autodesk.Revit.DB.Color((byte)0, (byte)191, (byte)255);
            }

            OverrideGraphicSettings ogs = new OverrideGraphicSettings();

            ogs.SetProjectionLineColor(color);

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Change Element Color");

                doc.ActiveView.SetElementOverrides(ih4, ogs);
                tx.Commit();
            }
            double get_temp = d2.Min();
            if (get_temp <= 18.5 || get_temp <= 24.9)
            {
                // Console.WriteLine("Red");
                color = new Autodesk.Revit.DB.Color((byte)255, (byte)0, (byte)0);
            }
            else if (get_temp >= 25 || get_temp >= 35)
            {
                //Console.WriteLine("orange");
                color = new Autodesk.Revit.DB.Color((byte)255, (byte)165, (byte)0);
            }
            OverrideGraphicSettings ogs1 = new OverrideGraphicSettings();
            ogs1.SetProjectionLineColor(color);

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Change Element Color");
                doc.ActiveView.SetElementOverrides(it4, ogs1);
                tx.Commit();
            }
            List<DateTime> dt = pc.Get_Timet("history");

            for (int i = 0; i < dt.Count; i++)
            {
                this.chart1.Series["Temperature"].Points.AddXY(Convert.ToString(dt[i]), d2[i]);
            }
            this.chart1.ChartAreas[0].AxisX.Title = "Timestamp";
            this.chart1.ChartAreas[0].AxisY.Title = "deviceReadings";
            
            for (int i = 0; i < dt.Count; i++)
            {
                this.chart2.Series["Humidity"].Points.AddXY(Convert.ToString(dt[i]), d[i]);
            }
            this.chart2.ChartAreas[0].AxisX.Title = "Timestamp";
            this.chart2.ChartAreas[0].AxisY.Title = "humidity readings";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ElementId id5 = new ElementId(546861);
            Element e1 = doc.GetElement(id5);
            Parameter parameter = e1.LookupParameter("H");

            List<double> d = pc.ReadingsHh(dp.Room_WA(210), "history");
            List<double> d2 = pc.ReadingsHt(dp.Room_WA(210), "history");
            using (Transaction t = new Transaction(doc, "parameter"))
            {
                t.Start();
                try
                {
                    parameter.Set(d.Max());
                    t.Commit();
                }


                catch (Exception err)
                {
                    TaskDialog.Show("Error", err.Message);

                }
            }
            Parameter parameter2 = e1.LookupParameter("Temperature");
            using (Transaction t1 = new Transaction(doc, "parameter2"))
            {
                t1.Start();
                try
                {
                    parameter2.Set(273.15 + d2.Min());
                    t1.Commit();
                }


                catch (Exception err)
                {
                    TaskDialog.Show("Error", err.Message);

                }
            }
            ElementId ih5 = new ElementId(629399);
            ElementId it5 = new ElementId(629108);
            var get_humidity = d.Max();

            if (get_humidity <= 30 || get_humidity <= 44)
            {
                // Console.WriteLine("Pale Green");
                color = new Autodesk.Revit.DB.Color((byte)152, (byte)251, (byte)152);
            }
            else if (get_humidity >= 45 || get_humidity >= 60)
            {
                //Console.WriteLine("beep sky blue");
                color = new Autodesk.Revit.DB.Color((byte)0, (byte)191, (byte)255);
            }

            OverrideGraphicSettings ogs = new OverrideGraphicSettings();

            ogs.SetProjectionLineColor(color);

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Change Element Color");

                doc.ActiveView.SetElementOverrides(ih5, ogs);
                tx.Commit();
            }

            double get_temp = d2.Min();
            if (get_temp <= 18.5 || get_temp <= 24.9)
            {
                // Console.WriteLine("Red");
                color = new Autodesk.Revit.DB.Color((byte)255, (byte)0, (byte)0);
            }
            else if (get_temp >= 25 || get_temp >= 35)
            {
                //Console.WriteLine("orange");
                color = new Autodesk.Revit.DB.Color((byte)255, (byte)165, (byte)0);
            }
            OverrideGraphicSettings ogs1 = new OverrideGraphicSettings();
            ogs1.SetProjectionLineColor(color);

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Change Element Color");
                doc.ActiveView.SetElementOverrides(it5, ogs1);
                tx.Commit();
            }

            List<DateTime> dt = pc.Get_Timet("history");

            for (int i = 0; i < dt.Count; i++)
            {

                this.chart1.Series["Temperature"].Points.AddXY(Convert.ToString(dt[i]), d2[i]);
            }
            this.chart1.ChartAreas[0].AxisX.Title = "Timestamp";
            this.chart1.ChartAreas[0].AxisY.Title = "Temperature readings";
           
            for (int i = 0; i < dt.Count; i++)
            {
                this.chart2.Series["Humidity"].Points.AddXY(Convert.ToString(dt[i]), d[i]);
            }
            this.chart2.ChartAreas[0].AxisX.Title = "Timestamp";
            this.chart2.ChartAreas[0].AxisY.Title = " humidity readings";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ElementId id6 = new ElementId(548106);
            Element e1 = doc.GetElement(id6);
            Parameter parameter = e1.LookupParameter("H");

            List<double> d = pc.ReadingsHh(dp.Room_WA(211), "history");
            List<double> d2 = pc.ReadingsHt(dp.Room_WA(211), "history");
            using (Transaction t = new Transaction(doc, "parameter"))
            {
                t.Start();
                try
                {
                    parameter.Set(d.Max());
                    t.Commit();
                }


                catch (Exception err)
                {
                    TaskDialog.Show("Error", err.Message);

                }
            }
            Parameter parameter2 = e1.LookupParameter("Temperature");
            using (Transaction t1 = new Transaction(doc, "parameter2"))
            {
                t1.Start();
                try
                {
                    parameter2.Set(273.15 + d2.Min());
                    t1.Commit();
                }


                catch (Exception err)
                {
                    TaskDialog.Show("Error", err.Message);

                }
            }
            ElementId ih6 = new ElementId(629561);
            ElementId it6 = new ElementId(629514);
            var get_humidity = d.Max();

            if (get_humidity <= 30 || get_humidity <= 44)
            {
                // Console.WriteLine("Pale Green");
                color = new Autodesk.Revit.DB.Color((byte)152, (byte)251, (byte)152);
            }
            else if (get_humidity >= 45 || get_humidity >= 60)
            {
                //Console.WriteLine("beep sky blue");
                color = new Autodesk.Revit.DB.Color((byte)0, (byte)191, (byte)255);
            }

            OverrideGraphicSettings ogs = new OverrideGraphicSettings();

            ogs.SetProjectionLineColor(color);

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Change Element Color");

                doc.ActiveView.SetElementOverrides(ih6, ogs);
                tx.Commit();
            }

            double get_temp = d2.Max();
            if (get_temp <= 18.5 || get_temp <= 24.9)
            {
                // Console.WriteLine("Red");
                color = new Autodesk.Revit.DB.Color((byte)255, (byte)0, (byte)0);
            }
            else if (get_temp >= 25 || get_temp >= 35)
            {
                //Console.WriteLine("orange");
                color = new Autodesk.Revit.DB.Color((byte)255, (byte)165, (byte)0);
            }
            OverrideGraphicSettings ogs1 = new OverrideGraphicSettings();
            ogs1.SetProjectionLineColor(color);

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Change Element Color");
                doc.ActiveView.SetElementOverrides(it6, ogs1);
                tx.Commit();
            }
            List<DateTime> dt = pc.Get_Timet("history");

            for (int i = 0; i < dt.Count; i++)
            {

                this.chart1.Series["Temperature"].Points.AddXY(Convert.ToString(dt[i]), d2[i]);
            }
            this.chart1.ChartAreas[0].AxisX.Title = "Timestamp";
            this.chart1.ChartAreas[0].AxisY.Title = "Temperature readings";
            
            for (int i = 0; i < dt.Count; i++)
            {
                this.chart2.Series["Humidity"].Points.AddXY(Convert.ToString(dt[i]), d[i]);
            }
            this.chart2.ChartAreas[0].AxisX.Title = "Timestamp";
            this.chart2.ChartAreas[0].AxisY.Title = "humidity readings";
        }   

        
    }

    
}
