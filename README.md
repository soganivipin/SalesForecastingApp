# Sales Forecasting Application

## Overview
This application provides a simple sales forecasting tool using ASP.NET Web Forms and SQL Server.

## Technologies Used
- ASP.NET Web Forms (.NET Framework)
- C#
- SQL Server

## How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/SalesForecastingApp.git
   ```
2. Open the solution file `SalesForecasting.sln` in Visual Studio.
3. Ensure the database connection string in `Web.config` is correct.
4. Execute the SQL scripts in the `DB` folder to create and seed the database.
5. Run the application from Visual Studio.

## Database Setup
Run the following scripts in order:
1. `CreateTables.sql` - Creates necessary tables.
2. `SeedData.sql` - Seeds the tables with initial data.

## Features
- Query sales data by year.
- Apply a percentage increase to the sales data.
- Export forecasted sales data to CSV.

## Caveats
- Ensure the SQL Server instance is running and accessible.
- Modify the database connection string in `Web.config` if necessary.
