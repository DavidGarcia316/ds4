<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio171._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="row">
            <div>
                <asp:GridView id="MyGridView" DataSourceID="MyDataSource1"
                    AllowSorting="True" AllowPaging="True"
                    DataKeyNames="ProductID"
                    AutoGenerateEditButton="True"
                Runat="Server" />

                <asp:SqlDataSource ID="MyDataSource1" runat="server"
                    connectionString="data source=DESKTOP-DVPK5D7\SQLEXPRESS;initial catalog=Northwind;persist security info=True;Integrated Security=SSPI;"
                    ProviderName="System.Data.SqlClient"
                    SelectCommand="SELECT ProductId, ProductName, UnitPrice From Products"
                    UpdateCommand="Update Products Set [ProductName]=@ProductName, [UnitPrice]=@UnitPrice Where [ProductId]=@ProductId">

                </asp:SqlDataSource>
            </div>
        </div>

</asp:Content>
