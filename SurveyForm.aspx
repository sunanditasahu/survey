<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurveyForm.aspx.cs" Inherits="DuckSurveyProjectDotNet.SurveyForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Survey collection project</title>
    <style type="text/css">
        .auto-style1 {
            width: 326px;
        }
        .auto-style2 {
            height: 21px;
            width: 326px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <strong><span style="font-size: 14pt; color: #0000ff">Get to know your ducks!</span></strong><br />
                <br />
                <table>
                    <tr>
                        <td class="auto-style1">What time are the ducks fed?</td>
                        <td style="width: 63px">:</td>
                        <td style="width: 193px">                            
                            <asp:DropDownList runat="server" ID="foodTime" Height="20px" Width="183px" AutoPostBack="true" OnSelectedIndexChanged="foodTime_SelectedIndexChanged">
                                <asp:ListItem Text="Morning" Value="Morning"></asp:ListItem>
                                <asp:ListItem Text="Noon" Value="Noon"></asp:ListItem>
                                <asp:ListItem Text="Afternoon" Value="Afternoon"></asp:ListItem> 
                                <asp:ListItem Text="Evening" Value="Evening"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">What food the ducks are fed?</td>
                        <td style="width: 63px">:</td>
                        <td style="width: 193px">
                            <asp:DropDownList runat="server" ID="foodName" Height="20px" Width="183px" autopostback="true" onselectedindexchanged="foodName_SelectedIndexChanged">
                                <asp:ListItem Text="Vegetables" Value="Vegetables"></asp:ListItem>
                                <asp:ListItem Text="Mealworms" Value="Mealworms"></asp:ListItem>
                                <asp:ListItem Text="Grains" Value="Grains"></asp:ListItem>
                                <asp:ListItem Text="Seeds" Value="Seeds"></asp:ListItem>
                                <asp:ListItem Text="Bread/Crackers and other junk" Value="Bread/Crackers and other junk"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Where the ducks are fed?</td>
                        <td style="width: 63px">:</td>
                        <td style="width: 193px">
                            <asp:DropDownList runat="server" ID="foodLoc" Height="20px" Width="183px" AutoPostBack="true" OnSelectedIndexChanged="foodLoc_SelectedIndexChanged">
                                <asp:ListItem Text="Pond shoreline" Value="Pond shoreline"></asp:ListItem>
                                <asp:ListItem Text="Bird feeder area" Value="Bird feeder area"></asp:ListItem>
                                <asp:ListItem Text="Inside the pond" Value="Inside the pond"></asp:ListItem>
                             </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">How many ducks are fed?</td>
                        <td style="width: 63px">:</td>
                        <td style="width: 193px">
                            <asp:DropDownList runat="server" ID="ducksNumber" Height="20px" Width="183px" AutoPostBack="true" OnSelectedIndexChanged="ducksNumber_SelectedIndexChanged">
                                <asp:ListItem Text="<10" Value="<10"></asp:ListItem>
                                <asp:ListItem Text=">10 and <50" Value=">10 and <50"></asp:ListItem>
                                <asp:ListItem Text=">50 and <100" Value=">50 and <100"></asp:ListItem>
                                <asp:ListItem Text=">100" Value=">100"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">What kind of food are ducks fed?</td>
                        <td style="width: 63px">:</td>
                        <td style="width: 193px">                          
                            <asp:DropDownList runat="server" ID="foodType" Height="20px" Width="183px" AutoPostBack="true" OnSelectedIndexChanged="foodType_SelectedIndexChanged">
                                <asp:ListItem Text="Veggies" Value="Veggies"></asp:ListItem>
                                <asp:ListItem Text="Grains" Value="Grains"></asp:ListItem>
                                <asp:ListItem Text="Seeds" Value="Seeds"></asp:ListItem>
                                <asp:ListItem Text="Meat" Value="Meat"></asp:ListItem>                            
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">How much food are ducks fed?
                    <td style="width: 63px">:</td>
                            <td style="width: 193px">
                                <asp:DropDownList runat="server" ID="foodQty" Height="20px" Width="183px" AutoPostBack="true" OnSelectedIndexChanged="foodQty_SelectedIndexChanged">
                                    <asp:ListItem Text="Less than needed" Value="Less than needed"></asp:ListItem>
                                    <asp:ListItem Text="Just enough" Value="Just enough"></asp:ListItem>
                                    <asp:ListItem Text="More than needed" Value="More than needed"></asp:ListItem>
                                </asp:DropDownList>

                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style2"></td>
                        <td style="width: 63px; height: 21px"></td>
                        <td style="width: 193px; height: 21px">
                            <asp:Label ID="confirm" runat="server" Text="Submitted, Thank you !" Visible="False"
                                Width="152px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="width: 63px; text-align: center"></td>
                        <td style="width: 193px">
                            <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" /></td>
                    </tr>
                    <tr>
                        <td class="auto-style2"></td>
                        <td style="width: 63px; height: 21px"></td>
                        <td style="width: 193px; height: 21px">
                            <asp:Label ID="appreciate" runat="server" Text="Appreciate your contribution! Please check in C drive for the report named DuckReport.csv" Visible="False"
                                Width="152px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="width: 63px; text-align: center"></td>
                        <td style="width: 193px">
                            <asp:Button ID="genReport" runat="server" Text="Generate Report" OnClick="generateReport_Click" /></td>
                    </tr>
                </table>
            </div>
            <br />

        </div>
    </form>
</body>
</html>
