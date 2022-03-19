using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Device_Query_Connection.Query_Namespace;
using System.Windows.Forms;

namespace MyTest2
{
    [Transaction(TransactionMode.Manual)]
    public class ForCurrent : IExternalCommand
    {
        /// <summary>
        ///Creating instance Objects of DevicePlacing , PreparingConnection classes
        /// </summary>
        private DevicePlacing dp = new DevicePlacing();
        private PreparingConnection pc = new PreparingConnection();

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get application and documnet objects
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            //Creating new instance of ElementId objects from Revit
            ElementId id1 = new ElementId(540471);
            ElementId id2 = new ElementId(543001);
            ElementId id3 = new ElementId(544350);
            ElementId id4 = new ElementId(545596);
            ElementId id5 = new ElementId(546861);
            ElementId id6 = new ElementId(548106);

            List<ElementId> list_elementid = new List<ElementId>() { id1, id2, id3, id4, id5, id6 };
            
            //rm-room_Number
            List<int> rm = new List<int>() { 201, 204, 205, 206, 210, 211 };

            //selects List of ElementID objects
            uidoc.Selection.SetElementIds(list_elementid);

            for (int i = 0; i < list_elementid.Count; i++)
            {
                Element e = doc.GetElement(list_elementid[i]);
                Parameter parameter = e.LookupParameter("H");

                List<double> d = pc.ReadingsC(dp.Room_WA(rm[i]), "current");
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
                Parameter parameter2 = e.LookupParameter("Temperature");
                using (Transaction t1 = new Transaction(doc, "parameter2"))
                {
                    t1.Start();
                    try
                    {
                        var get_humidity = d.Max();
                        double get_temp = d.Min();
                        foreach (double j in d)
                        {
                            if (j < get_temp && j < get_humidity)
                            {
                                get_temp = j;

                            }
                        }

                        parameter2.Set(273.15 + get_temp);
                        t1.Commit();
                    }


                    catch (Exception err)
                    {
                        TaskDialog.Show("Error", err.Message);

                    }
                }

               ChangeElementColorT(doc);
               ChangeElementColorH(doc);
            }
            //For Current Graph in Revit 
            Application.Run(new CurrentGraph());


                return Result.Succeeded;
        }

        /// <summary>
        ///Sets Color for Humidity Reading
        /// </summary>
        private void ChangeElementColorH(Document doc)
        {
            Autodesk.Revit.DB.Color color = null;
            //rm- room_Numbers
            List<int> rm = new List<int>() { 201, 204, 205, 206,210, 211 };

            //Creating new instances of  ElementId objects 
            ElementId ih1 = new ElementId(626452);
            ElementId ih2 = new ElementId(627851);
            ElementId ih3 = new ElementId(628617);
            ElementId ih4 = new ElementId(628989);
            ElementId ih5 = new ElementId(629399);
            ElementId ih6 = new ElementId(629561);

            List<ElementId> list_elementih = new List<ElementId>() { ih1, ih2, ih3, ih4, ih5, ih6 };

            for (int j = 0; j < list_elementih.Count; j++)
            {
                List<double> d = pc.ReadingsC(dp.Room_WA(rm[j]), "current");
                double get_humidity = d.Max();

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
                    doc.ActiveView.SetElementOverrides(list_elementih[j], ogs);
                    tx.Commit();
                }
            }
        }

        /// <summary>
        ///Sets Color for Temperature Reading 
        /// </summary>
        private void ChangeElementColorT(Document doc)
        {
            Autodesk.Revit.DB.Color color = null;
            //rm-room_Number
            List<int> rm = new List<int>() { 201, 204, 205, 206, 210, 211 };

            //Creating new instances of  ElementId objects 
            ElementId it1 = new ElementId(627700);
            ElementId it2 = new ElementId(627968);
            ElementId it3 = new ElementId(628510);
            ElementId it4 = new ElementId(628770);
            ElementId it5 = new ElementId(629108);
            ElementId it6 = new ElementId(629514);


            List<ElementId> list_elementit = new List<ElementId>() { it1, it2, it3, it4, it5,it6 };
            for (int j = 0; j < list_elementit.Count; j++)
            {
                List<double> d = pc.ReadingsC(dp.Room_WA(rm[j]), "current");
                double get_humidity = d.Max();
                double get_temp = d.Min();
                foreach (double i in d)
                {
                    if (i > get_temp && i < get_humidity)
                    {
                        get_temp = i;
                    }
                }
                if (get_temp <= 18.5 || get_temp <= 24.9)
                {
                    //Console.WriteLine("orange");
                    color = new Autodesk.Revit.DB.Color((byte)255, (byte)165, (byte)0);

                }
                else if (get_temp >= 25 || get_temp >= 35)
                {
                    // Console.WriteLine("Red");
                    color = new Autodesk.Revit.DB.Color((byte)255, (byte)0, (byte)0);
                }
                OverrideGraphicSettings ogs = new OverrideGraphicSettings();
                ogs.SetProjectionLineColor(color);

                using (Transaction tx = new Transaction(doc))
                {
                    tx.Start("Change Element Color");
                    doc.ActiveView.SetElementOverrides(list_elementit[j], ogs);
                    tx.Commit();
                }
            }
        }
    }
}
