using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Configuration;

namespace SalesForecasting
{
    public class SalesDataService
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SalesForecastingDB"].ConnectionString;

        public DataTable GetSalesByYear(int year)
        {
            DataTable dataTable = new DataTable();
            string sqlQuery = @"
        SELECT 
            OrdersCSV.State, 
            SUM(Products.Sales) AS Sales,
            COUNT(OrderReturns.OrderId) AS Returns
        FROM 
            OrdersCSV
        INNER JOIN 
            Products ON OrdersCSV.OrderId = Products.OrderId
        LEFT JOIN 
            OrderReturns ON OrdersCSV.OrderId = OrderReturns.OrderId
        WHERE 
            YEAR(OrdersCSV.OrderDate) = @year
        GROUP BY 
            OrdersCSV.State";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@year", year);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public decimal CalculateTotalSales(DataTable salesData)
        {
            decimal totalSales = 0;
            foreach (DataRow row in salesData.Rows)
            {
                decimal sales = Convert.ToDecimal(row["Sales"]);
                decimal returns = Convert.ToDecimal(row["Returns"]);
                totalSales += (sales - returns);
            }
            return totalSales;
        }

        public decimal ApplyPercentageIncrease(decimal currentSales, double percentageIncrease)
        {
            decimal increaseAmount = currentSales * (decimal)(percentageIncrease / 100);
            return currentSales + increaseAmount;
        }

        public void ExportToCSV(DataTable data, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<string> columnNames = data.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in data.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(filePath, sb.ToString());
        }
    }
}
