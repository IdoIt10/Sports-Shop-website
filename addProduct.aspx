<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="addProduct.aspx.cs" Inherits="Project_Web_Final.addProduct" %>
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
        #ContentPlaceHolder1_Calendar1{
            width: 50%;
            margin-left:25%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    






    <table id="UserProfTable">
        <tr>
            <td class="auto-style1">
                Title
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="title1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Color
            </td>
            <td>
                <asp:TextBox ID="color1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Price
            </td>
            <td>
                <asp:TextBox ID="price1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                ID
            </td>
            <td>
                <asp:TextBox ID="id1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Quantity
            </td>
            <td>
                <asp:TextBox ID="quntity" runat="server"></asp:TextBox>
            </td>
        </tr>
        
    </table>
    <h2>Date</h2>
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    <h2>Picture</h2>
    <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
    <br />
    <br />
    <br />

    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>
