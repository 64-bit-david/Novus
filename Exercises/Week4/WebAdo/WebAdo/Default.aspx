<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAdo.Default" OnLoad="Page_Load"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
      <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<body>
                <!-- Include the NavBar -->
      <%@ Register Src="NavBar.ascx" TagPrefix="uc" TagName="NavBar" %>
        <uc:NavBar runat="server" />

    <form id="form1" runat="server">

        <div>

          

            <h1>Read data from a database </h1>
             <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
             <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <br/>
             <asp:DropDownList 
                    ID="DropDownList1" 
                    runat="server" 
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1"
                    AutoPostBack="true">
             </asp:DropDownList>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
     
    </form>
</body>
</html>
