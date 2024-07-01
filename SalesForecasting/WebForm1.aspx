<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SalesForecasting.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Forecasting</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            color: #333;
        }

        .container {
            width: 60%;
            margin: 50px auto;
            padding: 20px;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            text-align: center;
            color: #4CAF50;
        }

        label {
            display: block;
            margin-top: 20px;
            font-weight: bold;
        }

        .input-field {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .button {
            display: block;
            width: 100%;
            padding: 10px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            margin-top: 20px;
        }

        .button:hover {
            background-color: #45a049;
        }

        .gridview {
            margin-top: 20px;
            width: 100%;
            border-collapse: collapse;
        }

        .gridview th, .gridview td {
            padding: 12px;
            border: 1px solid #ddd;
            text-align: left;
        }

        .gridview th {
            background-color: #f2f2f2;
        }

        .message {
            margin-top: 20px;
            padding: 10px;
            background-color: #f9f9f9;
            border: 1px solid #ddd;
            border-radius: 4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Sales Forecasting Tool</h2>

            <label for="txtYear">Enter Year:</label>
            <asp:TextBox ID="txtYear" runat="server" CssClass="input-field"></asp:TextBox>
            <asp:Button ID="btnQuerySales" runat="server" Text="Query Sales" CssClass="button" OnClick="btnQuerySales_Click" />
            
            <asp:GridView ID="gvSalesData" runat="server" CssClass="gridview"></asp:GridView>

            <label for="txtPercentageIncrease">Percentage Increase:</label>
            <asp:TextBox ID="txtPercentageIncrease" runat="server" CssClass="input-field"></asp:TextBox>
            <asp:Button ID="btnApplyIncrease" runat="server" Text="Apply Increase" CssClass="button" OnClick="btnApplyIncrease_Click" />

            <asp:Label ID="lblIncreasedSales" runat="server" Text="" CssClass="message"></asp:Label>

            <asp:Button ID="btnExportToCSV" runat="server" Text="Export to CSV" CssClass="button" OnClick="btnExportToCSV_Click" />
        </div>
    </form>
</body>
</html>
