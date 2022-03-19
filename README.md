# Integrating-Live-sensors
Project Name - ILSD (Integrating Live Sensor Data in BIM authoring tools)

Application: Retrieves sensor Data
Revit Platform: GenericModel
Revit Version: 2021
Programming Language: C# .Net Framework 4.8
Type: ExternalCommand

<<--Summary-->> 
This project demonstrates
        1. How to connect PostgreSQL database.
	2. Retrive Data from PostgreSQL and mapping it with Revit Elements.
	3. Visualizing data readings in bar graph and line graph

<<--Note-->>

1. change the Assembly path of MyTest2-addin-files from source code  and  Copy those add-in files in Revit Addins before Execution.

   Assembly path - The path where the Visual studio project is saved.
   path for Revit addins folder (C:\ProgramData\Autodesk\Revit\Addins\2021) by default.

2. set Visual studio debug start action to external program (startup Project MyTest2 here)
3. Execute the code.

References to be added:
	 From ITD utilities project- Npgsql, ITDPostgreSQLDataConnection, itd.common, itd.sensorVisualization .dll files
	 RevitAPI, RevitAPIUI .dll files
          
Project Files:
	Parameter.cs, Connection.cs - PostgreSQLServer Data & Connection
	
	DevicePlacing.cs, PreparingConnection.cs, Query.cs --

	PreparingConnection - Gets List of Readings from Current table, History table 
	DevicePlacing- gives Sensor device information
	Query- Queries for Reading tables from PostgreSQL Database

 	ForCurrent.cs, ForHistory.cs, CurrentGraph.cs, HistoryReadings.cs--

 	CurrentGraph - Gets Graphs in Revit
 	ForCurrent, ForHistory - Retrieves and loads the Readings into Revit model for 6 rooms
 	HistoryReadings -use Form to load history Reading into Revit model.	

