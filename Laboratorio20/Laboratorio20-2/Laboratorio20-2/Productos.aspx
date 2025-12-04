<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Laboratorio20_2.Productos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Laboratorio 20-2</title>
    <style>
        body { font-family: Arial, sans-serif; padding: 20px; background-color: #f4f4f4; }
        .contenedor { 
            max-width: 700px; 
            margin: 0 auto; 
            background-color: white; 
            padding: 20px; 
            border: 1px solid #ccc; 
            border-radius: 8px; 
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        h2 { text-align: center; color: #333; }
        .botones-top { 
            background-color: #eee; 
            padding: 10px; 
            border-bottom: 2px solid #ddd; 
            margin-bottom: 20px; 
            text-align: center;
        }
        .fila { margin-bottom: 15px; }
        .etiqueta { display: inline-block; width: 120px; font-weight: bold; }
        .input-text { padding: 5px; width: 200px; }
        .mensaje { display: block; margin-top: 20px; font-weight: bold; text-align: center; padding: 10px; }
        .exito { background-color: #d4edda; color: #155724; border: 1px solid #c3e6cb; }
        .error { background-color: #f8d7da; color: #721c24; border: 1px solid #f5c6cb; }
        /* Botones estilo ToolStrip */
        .btn-tool { padding: 5px 10px; margin: 2px; cursor: pointer; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <h2>Gestión de Laptops (Lab 20-2)</h2>

            <div class="botones-top">
                <asp:Button ID="btnNuevo" runat="server" Text="➕ Nuevo" CssClass="btn-tool" OnClick="btnNuevo_Click" />
                <asp:Button ID="btnGuardar" runat="server" Text="💾 Guardar" CssClass="btn-tool" OnClick="btnGuardar_Click" Enabled="false" />
                <asp:Button ID="btnCancelar" runat="server" Text="❌ Cancelar" CssClass="btn-tool" OnClick="btnCancelar_Click" Enabled="false" />
                <asp:Button ID="btnEliminar" runat="server" Text="🗑 Eliminar" CssClass="btn-tool" OnClick="btnEliminar_Click" Enabled="false" />
                
                <span style="margin-left: 15px;">| ID: </span>
                <asp:TextBox ID="txtBuscarId" runat="server" Width="60px"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="🔍" CssClass="btn-tool" OnClick="btnBuscar_Click" />
            </div>

            <div class="fila">
                <span class="etiqueta">ID:</span>
                <asp:TextBox ID="txtId" runat="server" ReadOnly="true" CssClass="input-text" BackColor="#EAEAEA"></asp:TextBox>
            </div>
            
            <div class="fila">
                <span class="etiqueta">Nombre:</span>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="input-text" Enabled="false"></asp:TextBox>
            </div>

            <div class="fila">
                <span class="etiqueta">Precio:</span>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="input-text" Enabled="false"></asp:TextBox>
            </div>

            <div class="fila">
                <span class="etiqueta">Stock:</span>
                <asp:TextBox ID="txtStock" runat="server" CssClass="input-text" Enabled="false"></asp:TextBox>
            </div>

            <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>