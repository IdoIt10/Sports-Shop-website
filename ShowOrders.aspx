<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="ShowOrders.aspx.cs" Inherits="Project_Web_Final.ShowOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .OrderTbl{
            width:10%;
            margin-right:5%;
            margin-left:65%;
            border-collapse: collapse;
            border-top:0px;
            border-right:0px;
            border-bottom:0px;
            border-left:0px;
            position: absolute;
            margin-top:6.5%;
        }
        .dtlOrders{
            position:absolute;
            margin-left: 18%;
            margin-top:3%;
        }
        #reciptDIV{
            display:block;
            background-color:blue;
            width:50%;
            margin-left:25%;
            height:100%;
            text-align:center;
        }
        h1{
            margin-left:18%;
            position:absolute;
        }
        #titleOrderDitiels{
            margin-left:65%;
            position:absolute;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Your Orders</h1>




    <asp:DataList ID="dtlproducts" runat="server" CssClass="dtlOrders" RepeatColumns="3" RepeatDirection="Horizontal" CellPadding="4" OnSelectedIndexChanged="dtlproducts_SelectedIndexChanged">
        <FooterStyle  Font-Bold="True" />
          <HeaderStyle  Font-Bold="True" ForeColor="White" />
          <ItemStyle  ForeColor="#333333" />
          <ItemTemplate>
              <table class="productsTables">
                  
                  <tr>
                      <td><asp:Label ID="Label6" runat="server" Text="Id:"></asp:Label></td>
                      <td><asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ID_ORDER") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label7" runat="server" Text="Costumer Name:"></asp:Label></td>
                      <td><asp:Label ID="lblpname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"NameCostumer") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label8" runat="server" Text="Total Price:"></asp:Label></td>
                      <td><asp:Label ID="lblprice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"totalPrice") %>'></asp:Label></td>
                  </tr>
                   <tr>
                      <td><asp:Label ID="Label9" runat="server" Text="Date Order:"></asp:Label></td>
                      <td><asp:Label ID="lblProductsList" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DateOrder") %>'></asp:Label></td>
                  </tr>
                  
                  <tr  id="CenterTd">
                      <td><asp:Button ID="btnorder" runat="server" Text="Order" CommandName="select"></asp:Button></td>
                  </tr>
                  <br />
                  <br />
                  <br />
              </table>

         
        </ItemTemplate>

    </asp:DataList>




    <h1 id="titleOrderDitiels">Order Detiels</h1>
    <div id="SelectedOrder">
        <asp:GridView ID="grdorder" CssClass="OrderTbl" runat="server" OnSelectedIndexChanged="grdorder_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField>
                <ItemTemplate><%-- תמונה של המוצר--%>
                    <asp:Image ID="Image2" runat="server" Height="96px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"imgx") %>' Width="110px" />
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div id="ReciptTblBtn">
        </div>
    </div>


</asp:Content>
