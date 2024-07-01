using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SalesForecasting
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private SalesDataService salesDataService = new SalesDataService();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnQuerySales_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtYear.Text, out int selectedYear))
            {
                DataTable salesData = salesDataService.GetSalesByYear(selectedYear);
                gvSalesData.DataSource = salesData;
                gvSalesData.DataBind();
                // Store the DataTable in ViewState
                ViewState["SalesData"] = salesData;
            }
            else
            {
                // Handle invalid input
                lblIncreasedSales.Text = "Please enter a valid year.";
            }
        }

        protected void btnApplyIncrease_Click(object sender, EventArgs e)
        {
            // Retrieve the sales data from ViewState
            DataTable salesData = ViewState["SalesData"] as DataTable;
            if (salesData != null && salesData.Rows.Count > 0)
            {
                if (decimal.TryParse(txtPercentageIncrease.Text, out decimal percentageIncrease))
                {
                    decimal currentSales = salesDataService.CalculateTotalSales(salesData);
                    decimal increasedSales = salesDataService.ApplyPercentageIncrease(currentSales, (double)percentageIncrease);
                    lblIncreasedSales.Text = $"Increased Sales: {increasedSales:C}";
                }
                else
                {
                    // Handle invalid percentage input
                    lblIncreasedSales.Text = "Please enter a valid percentage.";
                }
            }
            else
            {
                // Handle the case where the GridView has no data
                lblIncreasedSales.Text = "Please query sales data first.";
            }
        }

        protected void btnExportToCSV_Click(object sender, EventArgs e)
        {
            DataTable salesData = ViewState["SalesData"] as DataTable;
            if (salesData != null && salesData.Rows.Count > 0)
            {
                string filePath = Server.MapPath("~/App_Data/sales_forecast.csv");
                salesDataService.ExportToCSV(salesData, filePath);
                Response.ContentType = "application/csv";
                Response.AppendHeader("Content-Disposition", $"attachment; filename=sales_forecast.csv");
                Response.TransmitFile(filePath);
                Response.End();
            }
            else
            {
                // Handle the case where the GridView has no data
                lblIncreasedSales.Text = "Please query sales data first.";
            }
        }
    }
}
