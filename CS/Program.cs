using System;
using System.IO;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.Expressions;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;

namespace Reporting_Date_Range_Report_Parameters {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            CreateAndShowReport();
        }

        private static void CreateAndShowReport() {
            // Create a date range parameter.
            var dateRangeParam = new Parameter();
            dateRangeParam.Name = "dateRange";
            dateRangeParam.Description = "Date Range:";
            dateRangeParam.Type = typeof(System.DateTime);

            // Create a RangeParametersSettings instance and set up its properties.
            var dateRangeSettings = new RangeParametersSettings();

            // Specify the start date and end date parameters.
            dateRangeSettings.StartParameter.Name = "dateRangeStart";
            dateRangeSettings.StartParameter.ExpressionBindings.Add(
                new BasicExpressionBinding("Value", "AddYears(Today(), -1)")
            );

            dateRangeSettings.EndParameter.Name = "dateRangeEnd";
            dateRangeSettings.EndParameter.ExpressionBindings.Add(
                new BasicExpressionBinding("Value", "AddYears(Today(), 0)")
            );

            // Assign the settings to the parameter's ValueSourceSettings property.
            dateRangeParam.ValueSourceSettings = dateRangeSettings;

            // Create a report instance and add the parameter to the report's Parameters collection.
            var report = new XtraReport1();
            report.Parameters.Add(dateRangeParam);

            // Use the parameter to filter the report's data.
            report.FilterString = "GetDate([UpdatedOrderDate]) Between(?dateRangeStart,?dateRangeEnd)";

            ConfigureDataSource(report);
            report.ShowRibbonPreviewDialog();
        }

        private static void ConfigureDataSource(XtraReport report) {
            var projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            var databasePath = Path.Combine(projectDirectory, "nwind.db");
            var connectionParameters = new SQLiteConnectionParameters(databasePath, "");
            var dataSource = new SqlDataSource(connectionParameters);

            var ordersQuery = new CustomSqlQuery();
            ordersQuery.Name = "Orders";
            ordersQuery.Sql = @"SELECT
                OrderID,
                CustomerID,
                OrderDate,
                strftime('%Y', 'now') || substr(OrderDate, 5) AS UpdatedOrderDate
            FROM Orders;";

            dataSource.Queries.Add(ordersQuery);
            dataSource.Fill();

            report.DataSource = dataSource;
            report.DataMember = "Orders";
        }
    }
}
