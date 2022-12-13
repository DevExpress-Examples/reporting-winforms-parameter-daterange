using System;
using System.Windows.Forms;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.Expressions;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.ConnectionParameters;
using System.IO;

namespace Reporting_Date_Range_Report_Parameters {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
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
                new BasicExpressionBinding("Value", "AddYears(Today(), -6)")
            );

            dateRangeSettings.EndParameter.Name = "dateRangeEnd";
            dateRangeSettings.EndParameter.ExpressionBindings.Add(
                new BasicExpressionBinding("Value", "AddYears(Today(), -5)")
            );

            // Assign the settings to the parameter's ValueSourceSettings property.
            dateRangeParam.ValueSourceSettings = dateRangeSettings;

            // Create a report instance and add the parameter to the report's Parameters collection.
            var report = new XtraReport1();
            report.Parameters.Add(dateRangeParam);

            // Use the parameter to filter the report's data.
            report.FilterString = "GetDate([OrderDate]) Between(?dateRangeStart,?dateRangeEnd)";

            configureDataSource(ref report);
            report.ShowPreview();
        }

        private void configureDataSource(ref XtraReport1 report) {
            var projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            var databasePath = Path.Combine(projectDirectory, "nwind.db");
            var connectionParameters = new SQLiteConnectionParameters(databasePath, "");
            var dataSource = new SqlDataSource(connectionParameters);

            var ordersQuery = new CustomSqlQuery();
            ordersQuery.Name = "Orders";
            ordersQuery.Sql = "SELECT * FROM Orders";

            dataSource.Queries.Add(ordersQuery);

            report.DataSource = dataSource;
            report.DataMember = "Orders";
        }
    }
}
