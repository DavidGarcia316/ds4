<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio20_2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Matriz Diagonal Inversa</title>
    <style>
        .tabla-matriz { border-collapse: collapse; margin-top: 20px; }
        .tabla-matriz td { 
            border: 1px solid #333; 
            padding: 10px; 
            text-align: center; 
            width: 40px; height: 40px; 
        }
        .uno { background-color: #d1e7dd; font-weight: bold; }
        .container { padding: 20px; font-family: Arial, sans-serif; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Matriz Diagonal Inversa</h2>
            
            <asp:Label Text="Dimensión N:" runat="server" />
            <asp:TextBox ID="txtDimension" runat="server" TextMode="Number"></asp:TextBox>
            <asp:Button ID="btnGenerar" runat="server" Text="Generar Matriz" OnClick="btnGenerar_Click" />
            
            <hr />

            <asp:Literal ID="litMatriz" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
