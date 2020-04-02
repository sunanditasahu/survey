<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DuckSurveyProjectDotNet.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 196px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Username</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Password</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter password"
                        ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Password requirements not met: At least 1 upper case, 1 lower case, 1 special character and max length of 8"
                        ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"
                        ControlToValidate="TextBox2"></asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Confirm Password</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Email</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" />
                </td>
                <td>
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

