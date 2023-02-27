<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="Project_Web_Final.Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #ContentPlaceHolder1_GridView_Products{
            width:50%;
            margin-left:25%;
            border-collapse: collapse;
            border-top:0px;
            border-right:0px;
            border-bottom:0px;
            border-left:0px;
            position:absolute;
        }
        #ContentPlaceHolder1_GridView_Products th, td{
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid;
            border-top:0px;
            border-right: 0px;
            border-left:0px;
        }
        .vl {
            border-left: 2px solid black;
            height: 100%;
            position:absolute;
            margin-left:50%;
        }
        .SelectBtn{
            color:black;
            text-decoration: none;
            background-color: #f4511e;
            border: none;
            color: white;
            padding: 16px 32px;
            text-align: center;
            font-size: 16px;
            margin: 4px 2px;
            opacity: 0.6;
            transition: 0.3s;
            display: inline-block;
            text-decoration: none;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:GridView ID="GridView_Products" runat="server" OnSelectedIndexChanged="GridView_Products_SelectedIndexChanged" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
            <ItemTemplate><%-- תמונה של המוצר--%>
                <asp:Image ID="Image2" runat="server" Height="96px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"imgx") %>' Width="110px" />
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="title" HeaderText="Product's Name" />
            <asp:BoundField DataField="price" HeaderText="Price" />
            <asp:BoundField DataField="color" HeaderText="Color" />
            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="SelectBtn" ButtonType="Button" SelectText="Delete Product" >
<ControlStyle CssClass="SelectBtn"></ControlStyle>
            </asp:CommandField>
        </Columns>
    </asp:GridView>
    <%--<div class="vl"></div> --%>
    
</asp:Content>