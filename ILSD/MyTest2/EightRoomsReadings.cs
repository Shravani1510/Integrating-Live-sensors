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
    class EightRoomsReadings : IExternalCommand
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
            ElementId id5 = new ElementId(641346);
            ElementId id6 = new ElementId(641450);
            ElementId id7 = new ElementId(546861);
            ElementId id8 = new ElementId(548106);

            List<ElementId> list_elementid = new List<ElementId>() { id1, id2, id3, id4, id5, id6, id7, id8 };
            //rm-room_Number
            List<int> rm = new List<int>() { 201, 204, 205, 206, 207, 208, 210, 211 };
            //selects List of ElementID objects
            uidoc.Selection.SetElementIds(list_elementid);

            for (int i = 0; i < rm.Count; i++)
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
            }

            //For Current Graph in Revit 
            Application.Run(new CurrentGraph());

            return Result.Succeeded;
        }
    }
}
