<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Project_Web_Final.Register" %>
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

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <h1>To Sign Our Web Please Fill In The Diteals Below</h1>
    <br />
    









    <table id="UserProfTable">
        <tr>
            <td class="auto-style1">
                User Name
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                <asp:TextBox ID="passWord" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                First Name
            </td>
            <td>
                <asp:TextBox ID="firstname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Last Name
            </td>
            <td>
                <asp:TextBox ID="lastname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Phone
            </td>
            <td>
                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Age
            </td>
            <td>
                <asp:TextBox ID="Age" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
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


























    <asp:Button ID="regButton" runat="server" Text="Register" OnClick="regButton_Click" />



</asp:Content>
