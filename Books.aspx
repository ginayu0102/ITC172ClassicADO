<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="Books" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Author List</h1> 
        <hr />
        <p>Select the author you want to search for</p>
        <asp:DropDownList ID="authorDropDownList" runat="server" 
            AutoPostBack="True" 
            OnSelectedIndexChanged="authorDropDownList_SelectedIndexChanged">

        </asp:DropDownList>
        <asp:GridView ID="authorGridView" runat="server"></asp:GridView>
        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
