<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project_Web_Final.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        input[type=text]{
          width: 20%;
          padding: 12px 20px;
          margin: 8px 0;
          display: inline-block;
          border: 1px solid #ccc;
          border-radius: 4px;
          box-sizing: border-box;
        }
        a{
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div id ="titlelogin"><h1>Please enter your diteales to login</h1></div>
    <br />
    <br />
    <div id="form111">
            <div>
                <h3>Your UserName:
                </h3>
                <br />
                <asp:TextBox ID="userName" runat="server"></asp:TextBox>
                &nbsp;<h3>Your Password:</h3>
                &nbsp;<asp:TextBox ID="passWord" runat="server"></asp:TextBox>
                <br />
                <br />
                &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
            </div>
        <br />
        <br />
        <h3>If you have no user yet click <a href="Register.aspx">HERE!</a></h3>
        
    </div>




</asp:Content>
