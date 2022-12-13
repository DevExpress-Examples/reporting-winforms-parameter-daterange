Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraReports.Expressions
Imports DevExpress.XtraReports.UI
Imports DevExpress.DataAccess.Sql
Imports DevExpress.DataAccess.ConnectionParameters
Imports System.IO

Namespace Reporting_Date_Range_Report_Parameters
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			' Create a date range parameter.
			Dim dateRangeParam = New Parameter()
			dateRangeParam.Name = "dateRange"
			dateRangeParam.Description = "Date Range:"
			dateRangeParam.Type = GetType(Date)

			' Create a RangeParametersSettings instance and set up its properties.
			Dim dateRangeSettings = New RangeParametersSettings()

			' Specify the start date and end date parameters.
			dateRangeSettings.StartParameter.Name = "dateRangeStart"
			dateRangeSettings.StartParameter.ExpressionBindings.Add(New BasicExpressionBinding("Value", "AddYears(Today(), -6)"))

			dateRangeSettings.EndParameter.Name = "dateRangeEnd"
			dateRangeSettings.EndParameter.ExpressionBindings.Add(New BasicExpressionBinding("Value", "AddYears(Today(), -5)"))

			' Assign the settings to the parameter's ValueSourceSettings property.
			dateRangeParam.ValueSourceSettings = dateRangeSettings

			' Create a report instance and add the parameter to the report's Parameters collection.
			Dim report = New XtraReport1()
			report.Parameters.Add(dateRangeParam)

			' Use the parameter to filter the report's data.
			report.FilterString = "GetDate([OrderDate]) Between(?dateRangeStart,?dateRangeEnd)"

			configureDataSource(report)
			report.ShowPreview()
		End Sub

		Private Sub configureDataSource(ByRef report As XtraReport1)
			Dim projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName
			Dim databasePath = Path.Combine(projectDirectory, "nwind.db")
			Dim connectionParameters = New SQLiteConnectionParameters(databasePath, "")
			Dim dataSource = New SqlDataSource(connectionParameters)

			Dim ordersQuery = New CustomSqlQuery()
			ordersQuery.Name = "Orders"
			ordersQuery.Sql = "SELECT * FROM Orders"

			dataSource.Queries.Add(ordersQuery)

			report.DataSource = dataSource
			report.DataMember = "Orders"
		End Sub
	End Class
End Namespace
