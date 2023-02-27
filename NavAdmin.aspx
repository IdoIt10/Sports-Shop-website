<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="NavAdmin.aspx.cs" Inherits="Project_Web_Final.NavAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .ahref{
            text-align: center;
            text-decoration:none;
            margin-left:45%;
        }

        
        #UserProfMain{
            text-align:center;
        }
        #ProfImg{
            width: 300px;
            height: 300px;
        }
        h1{
             border-bottom-style: solid;
             border-width: 1px;
             text-align:center;
        }
        #UserProfTable{
            position:absolute;
            border-collapse: collapse;
            width: 60%;
            margin-left: 10%;
            margin-top: 1%;
        }
        #UserProfTable td{
            width: 300px;
            font-size:30px;
            
        }
        #UserProfTable th, td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid;
        }
        #ProfImg1{
            position:absolute;
            right:0px;
            width:20%;
            height:400px;
            margin-right: 10%;
            margin-top: 1%;
        }
        .auto-style1 {
            height: 39px;
        }
        #SpaceRow{
            position:absolute;
        }
        
        input[type=submit]{
            margin-top:10%;
            margin-left:15%;
        }
        
        .Btns_Admin_Options{
            padding-left:30%;
        }

        #ContentPlaceHolder1_toAddProduct{
            margin-left:22%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <h1>Your Admin Management Options Are:</h1>
    <br />
    <div id="Btns_Admin_Options">
        <asp:Button ID="toAddProduct" runat="server" Text="Add Product" OnClick="toAddProduct_Click" />
        <asp:Button ID="toDeleteProduct" runat="server" Text="Delete Product" OnClick="delPro_Click" />
        <asp:Button ID="toManageUsers" runat="server" Text="Manage Users" OnClick="ManUS_Click" />
    </div>

</asp:Content>
