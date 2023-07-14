<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Person.aspx.cs" Inherits="WebAdo.Person" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Person</title>
      <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
            
            <!-- Include the NavBar -->
            <%@ Register Src="NavBar.ascx" TagPrefix="uc" TagName="NavBar" %>
            <uc:NavBar runat="server" />
            
            <!-- Headers -->
            <div class="container d-flex justify-content-center mt-10">
                <h1>Read data from a database </h1>
            </div>
            <div class="container d-flex justify-content-center mt-5">
                <h2>Create a person and add them to the database</h2>
           </div>

            <!-- Inputs for creating a person -->
           <div class="container mt-5">
                <div class="row justify-content-center">
                    <div class="col-6">
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="First Name: "></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-6">
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Last Name: "></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-6">
                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Email: "></asp:Label>
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-6">
                        <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="Phone: "></asp:Label>
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
             
        <!-- btn for adding person -->
            <div class="container d-flex justify-content-center">
                    <asp:Label ID="Label6" runat="server" Text="Add Person to Database"></asp:Label>
                    <asp:Button ID="Button1" runat="server" OnClick="PostPersonButton_Click" CssClass="btn btn-primary" Text="Add" />
            </div>


        <!-- Grid View for displaying info from DB -->
        <div class="container d-flex justify-content-center align-items-center mt-5">
            <div class="table-responsive" style="width: 60%;">
                    <!-- need to register delete event handler -GridView1_RowDeleting -->
                <asp:GridView
                    ID="GridView1"
                    runat="server"
                    CssClass="table table-striped table-bordered"
                    AutoGenerateColumns="False"                    
                    OnRowDeleting="GridView1_RowDeleting">
                    <HeaderStyle BackColor="#337ab7" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <!-- pass id of row to delete -->                                
                                <asp:Button ID="DeleteButton" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
     </form>
</body>
</html>
