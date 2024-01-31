Imports System.IO
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports DevExpress.XtraReports.Expressions
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraReports.UI
Namespace Reporting_Date_Range_Report_Parameters
    Friend Module Program
        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            CreateAndShowReport()
        End Sub
        Private Sub CreateAndShowReport()
            ' Create a date range parameter.
            Dim dateRangeParam = New Parameter()
            dateRangeParam.Name = "dateRange"
            dateRangeParam.Description = "Date Range:"
            dateRangeParam.Type = GetType(Date)

            ' Create a RangeParametersSettings instance and set up its properties.
            Dim dateRangeSettings = New RangeParametersSettings()

            ' Specify the start date and end date parameters.
            dateRangeSettings.StartParameter.Name = "dateRangeStart"
            dateRangeSettings.StartParameter.ExpressionBindings.Add(New BasicExpressionBinding("Value", "AddYears(Today(), -1)"))
            dateRangeSettings.EndParameter.Name = "dateRangeEnd"
            dateRangeSettings.EndParameter.ExpressionBindings.Add(New BasicExpressionBinding("Value", "AddYears(Today(), 0)"))

            ' Assign the settings to the parameter's ValueSourceSettings property.
            dateRangeParam.ValueSourceSettings = dateRangeSettings

            ' Create a report instance and add the parameter to the report's Parameters collection.
            Dim report = New XtraReport1()
            report.Parameters.Add(dateRangeParam)

            ' Use the parameter to filter the report's data.
            report.FilterString = "GetDate([UpdatedOrderDate]) Between(?dateRangeStart,?dateRangeEnd)"
            ConfigureDataSource(report)
            report.ShowRibbonPreviewDialog()
        End Sub

        Private Sub ConfigureDataSource(report As XtraReport)
            Dim projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName
            Dim databasePath = Path.Combine(projectDirectory, "nwind.db")
            Dim connectionParameters = New SQLiteConnectionParameters(databasePath, "")
            Dim dataSource = New SqlDataSource(connectionParameters)

            Dim ordersQuery = New CustomSqlQuery()
            ordersQuery.Name = "Orders"
            ordersQuery.Sql = "SELECT
                OrderID,
                CustomerID,
                OrderDate,
                strftime('%Y', 'now') || substr(OrderDate, 5) AS UpdatedOrderDate
            FROM Orders;"

            dataSource.Queries.Add(ordersQuery)

            report.DataSource = dataSource
            report.DataMember = "Orders"
        End Sub
    End Module
End Namespace
