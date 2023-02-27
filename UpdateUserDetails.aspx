<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="UpdateUserDetails.aspx.cs" Inherits="Project_Web_Final.UpdateUserDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body{
            text-align:center;
        }
        #UserProfTable{
            border-collapse: collapse;
            width: 100%;

        }
        #UserProfTable td{
            width: 300px;
            font-size:30px;
            
        }
        #UserProfTable th, td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid;
            text-align:center;
        }

        input[type=text]{
          width: 30%;
          height:100%;
          padding: 6px 10px;

          display: inline-block;
          border: 1px solid #ccc;
          border-radius: 4px;
          box-sizing: border-box;
        }
        #ContentPlaceHolder1_Image1{
            position:absolute;
            right:0px;
            width:9%;
            margin-right: 3%;
            margin-top: 1%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Image ID="Image1" runat="server" />
    <br />
    <br />
    <h1><%=Session["userName"] %> To Update Your Account Please Fill The Diteals Below</h1>
    <br />
    









    <table id="UserProfTable">
        
        <tr>
            <td>
                Password
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                First Name
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Last Name
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Phone
            </td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Age
            </td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <h2>Upload Profile Image:</h2>
    <asp:FileUpload ID="FileUpload1" runat="server" EnableViewState="False" Font-Bold="True" Font-Italic="True" Font-Names="Arial" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
    <br />
    <br />
    <br />
    
    <br />
    <br />

    <asp:Button ID="updateButton" runat="server" Text="Update" OnClick="updateButton_Click" />
</asp:Content>
