<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="aspdotnet_webform_template.todolist" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container">
        <h2>Enroll Form</h2>
        <form id="form1" runat="server">
            <div class="form-group">
                <asp:Label ID="firstNameLabel" Text="First Name:" runat="server"></asp:Label>
                <asp:TextBox ID="firstName" CssClass="form-control" runat="server" ></asp:TextBox>
                <br />
            </div>
            <div class="form-group">
                <asp:Label ID="lastNameLabel" Text="Last Name:" runat="server"></asp:Label>
                <asp:TextBox ID="lastName" CssClass="form-control" runat="server" ></asp:TextBox>
                <br />
            </div>
            <div class="form-group">
                <asp:Label ID="emailLabel" Text="Email:" runat="server"></asp:Label>
                <asp:TextBox ID="email" CssClass="form-control" runat="server" ></asp:TextBox>
                <br />
            </div>
            <div class="form-group">
                <asp:Label ID="courseLabel" Text="Course List:" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlCourses" runat="server">
                    <asp:ListItem Enabled="true" Text="Select Course" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Course1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Course2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Course3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Course4" Value="4"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <asp:Button ID="submit" OnClick="submit_Click" CssClass="btn btn-default" Text="Submit" runat="server" />
        
            <table class="table table-striped">           
                <thead>
                  <tr>
                    <th>Student ID</th>
                    <th>Student Name</th>
                    <th>Enrolled Course</th>
                    <th>Course Name</th>
                    <th>Course Details</th>
                    <th>Delete Button</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="plhContainer" runat="server"></asp:PlaceHolder> 
                </tbody>
            </table> 
        </form>
    </div>
   
</body>
</html>
