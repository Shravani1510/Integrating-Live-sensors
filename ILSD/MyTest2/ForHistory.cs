using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;

namespace MyTest2
{
    [Transaction(TransactionMode.Manual)]
    class ForHistory : IExternalCommand
    {
        Result IExternalCommand.Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Application.Run(new HistoryReading(commandData));
            
            return Result.Succeeded;
        }
    }
}
