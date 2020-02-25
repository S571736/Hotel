<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebFormsIdentity.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
<body style="font-family: Arial, Helvetica, sans-serif; font-size: small">
    <form id="form1" runat="server">
        <div>
            <h4 style="font-size: medium">Register a new user</h4>
            <hr />
            <p>
                <asp:Literal runat="server" ID="StatusMessage" />
            </p>
            <div style="margin-bottom: 10px">
                <asp:Label runat="server" AssociatedControlID="FirstName">First name</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="FirstName" />
                </div>
            </div>
            <div style="margin-bottom: 10px">
                <asp:Label runat="server" AssociatedControlID="LastName">Last name</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="LastName" />
                </div>
            </div>


            <div>
                <div>
                    <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>

