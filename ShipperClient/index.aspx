<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ShipperClient.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NW</title>
    <link href="Style/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br/><br/>
        <asp:Button ID="Button1" runat="server" Text="Get Shipper" OnClick="Button1_Click" />
        <br/><br/>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br/><br/>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br/><br/>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br/><br/>
        <asp:Button ID="Button2" runat="server" Text="Save" OnClick="Button2_Click" />
    </div>
    </form>
</body>
</html>
