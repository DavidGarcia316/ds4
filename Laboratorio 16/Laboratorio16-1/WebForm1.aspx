<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio16_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .cal
        {
            position: absolute;
            top:65px;
            left:60px;
            right:490px;
            height:600px;
            bottom:23px;
            background-color:dodgerblue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cal">
            <asp:Label ID="l1" Text=" CALCULADORA BASICA" runat="server" Style="margin-left: 50px"
                Font-Bold="True" Font-Italic="False" foreColor="White" Font-Size="25px"></asp:Label>
            <br />
            <asp:TextBox ID="t1" runat="server" Style="margin-left: 50px; margin-top: 24px;"
                Width="335px" Height="41px" OnTextChanged="t1_TextChanged"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="b1" Text="1" runat="server" Height="37px" Style="margin-left: 0px"
                Width="57px" OnClick="b1_Click" />
            <asp:Button ID="b2" Text="2" runat="server" Height="37px" Style="margin-left: 0px"
                Width="57px" OnClick="b2_Click" />
            <asp:Button ID="b3" Text="3" runat="server" Height="37px" Style="margin-left: 0px"
                Width="57px" OnClick="b3_Click" />
            <asp:Button ID="add" Text="+" runat="server" Height="37px" Style="margin-left: 0px;
                margin-top: 0px;" Width="57px" OnClick="add_Click" />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="b4" Text="4" runat="server" Height="37px" Style="margin-left: 0px"
                Width="57px" OnClick="b4_Click" />
            <asp:Button ID="b5" Text="5" runat="server" Height="37px" Style="margin-left: 0px"
                Width="57px" OnClick="b5_Click" />
            <asp:Button ID="b6" Text="6" runat="server" Height="37px" Style="margin-left: 0px"
                Width="57px" OnClick="b6_Click" />
            <asp:Button ID="sub" Text="-" runat="server" Height="37px" Style="margin-left: 0px"
                Width="57px" OnClick="sub_Click" />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="b7" Text="7" runat="server" Height="37px" Style="margin-left: 0px"
                Width="57px" OnClick="b7_Click" />
            <asp:Button ID="b8" Text="8" runat="server" Height="37px" Style="margin-left: 0px"
                Width="57px" OnClick="b8_Click" />
            <asp:Button ID="b9" Text="9" runat="server" Height="37px" Style="margin-left: 0px"
                Width="57px" OnClick="b9_Click" />
            <asp:Button ID="mul" Text="*" runat="server" Height="37px" Style="margin-left: 0px"
                Width="57px" OnClick="mul_Click" />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="b0" Text="0" runat="server" Height="37px" Style="margin-left: 0px"
                Width="57px" OnClick="b0_Click" />
            <asp:Button ID="clr" Text="CLR" runat="server" Height="37px" Style="margin-left: 0px"
                Width="57px" OnClick="clr_Click" />
            <asp:Button ID="eql" Text="=" runat="server" Height="37px" Style="margin-left: 0px"
                Width="57px" OnClick="eql_Click" />
            <asp:Button ID="div" Text="/" runat="server" Height="37px" Style="margin-left: 0px"
                Width="57px" OnClick="div_Click" />
        </div>      
    </form>
</body>
</html>
