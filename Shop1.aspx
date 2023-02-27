<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Shop1.aspx.cs" Inherits="Project_Web_Final.Shop1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #ContentPlaceHolder1_dtlproducts{
            margin-left:3%;
            margin-right:3%;
            position:absolute;
            margin-top:17%;
        }
        #CenterTd{
            text-align:center;
        }
        #ContentPlaceHolder1_SearchBox{
            margin-left:25%;
            position:absolute;
            border-radius: 25px;
            margin-top:2%;
            outline: 0;
        }
        input[type=text]{
          width: 15%;
          padding: 12px 20px;
          margin: 8px 0;
          display: inline-block;
          border: 1px solid #ccc;
          border-radius: 4px;
          box-sizing: border-box;
        }
        #ContentPlaceHolder1_SearchButton{
            margin-left:40%;
            position:absolute;
            margin-top:1.5%;
            outline: 0;
        }

        #ContentPlaceHolder1_GridView_Products{
            width:30%;
            margin-left:5%;
            border-collapse: collapse;
            border-top:0px;
            border-right:0px;
            border-bottom:0px;
            border-left:0px;
            position:absolute;
        }

        #ContentPlaceHolder1_grdorder{
            width:30%;
            margin-left:68%;
            border-collapse: collapse;
            border-top:0px;

            border-bottom:0px;

            position:absolute;
            margin-top:15%;
        }

        #ContentPlaceHolder1_grdorder td{
            border-right:0px;
            border-left:0px;
            text-align:center;
        }

        #ContentPlaceHolder1_grdorder th{
            border-right:0px;
            border-left:0px;
        }
        
        .productsTables{
            margin: 30px;
        }

        #ShopCartTxt{
            margin-left:75%;
            font-size:34px;
            position: absolute;
        }

        #totalRecipt{
            font-size:20px;
            position: absolute;
            margin-left: 78%;
            margin-top: 5%;
        }

        #ReciptTblBtn{
            position:absolute;
            margin-top: 10%;
            margin-left: 79%;
        }

        #ContentPlaceHolder1_dtlSearch{
            position:absolute;
            margin-top:5%;
            margin-left: 5%;
        }

        #ContentPlaceHolder1_Order_btn{
            position: absolute;
            margin-left:80%;
            margin-top:10%;
        }

        #ContentPlaceHolder1_ShopCartIcon{
            width:7%;
            margin-left:90%;
        }

        #shopCart{
            z-index:2;
            background-color:blue;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    
    <h2 id="ShopCartTxt">Your Shopping Cart</h2>
    
    <asp:DataList ID="dtlproducts" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CellPadding="4" OnSelectedIndexChanged="dtlproducts_SelectedIndexChanged" OnCancelCommand="dtlproducts_CancelCommand" OnUpdateCommand="dtlproducts_UpdateCommand">
        <FooterStyle  Font-Bold="True" />
          <HeaderStyle  Font-Bold="True" ForeColor="White" />
          <ItemStyle  ForeColor="#333333" />
          <ItemTemplate>
              <table class="productsTables">
                  <tr>
                      <td rowspan="6">
                        <asp:Image ID="img" runat="server" Height="121px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"imgx") %>' Width="140px"></asp:Image>
                      </td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label6" runat="server" Text="Id:"></asp:Label></td>
                      <td><asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ID") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label7" runat="server" Text="Name:"></asp:Label></td>
                      <td><asp:Label ID="lblpname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"title") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label8" runat="server" Text="Price:"></asp:Label></td>
                      <td><asp:Label ID="lblprice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"price") %>'></asp:Label></td>
                  </tr>
                   <tr>
                      <td><asp:Label ID="Label9" runat="server" Text="Color:"></asp:Label></td>
                      <td><asp:Label ID="lblqua" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"color") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label10" runat="server" Text="Quantity:"></asp:Label></td>
                      <td><asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"quantity") %>'></asp:Label></td>
                  </tr>
                  <tr  id="CenterTd">
                      <td><asp:Button ID="btnorder" runat="server" Text="Order" CommandName="select"></asp:Button></td>
                  </tr>
                  <br />
                  <br />
                  <br />
              </table>

          </ItemTemplate>
          <AlternatingItemStyle />
          <EditItemTemplate>
               <table>
                  <tr>
                      <td rowspan="6">
                        <asp:Image ID="img" runat="server" Height="121px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"imgx") %>' Width="140px"></asp:Image>
                      </td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label6" runat="server" Text="Id:"></asp:Label></td>
                      <td><asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ID") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label7" runat="server" Text="Name:"></asp:Label></td>
                      <td><asp:Label ID="lblpname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"title") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label8" runat="server" Text="Price:"></asp:Label></td>
                      <td><asp:Label ID="lblprice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"price") %>'></asp:Label></td>
                  </tr>
                   <tr>
                      <td><asp:Label ID="colorlbl" runat="server" Text="Color:"></asp:Label></td>
                      <td><asp:Label ID="lblcolor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"color") %>'></asp:Label></td>
                  </tr>
                   <tr>
                      <td><asp:Label ID="Label9" runat="server" Text="Quantity:"></asp:Label></td>
                      <td><asp:Label ID="lblqua" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"quantity") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td colspan="3"><asp:Button ID="btnconfirm" runat="server" CommandName="Update" Text="Confirm" Enabled="True"></asp:Button>
                          <asp:Button ID="btncancel" runat="server" Text="Cancel" CommandName="cancel"></asp:Button>
                           <asp:DropDownList ID="drpqua" runat="server">
                               <asp:ListItem>1</asp:ListItem>
                               <asp:ListItem>2</asp:ListItem>
                               <asp:ListItem>3</asp:ListItem>
                               <asp:ListItem>4</asp:ListItem>
                               <asp:ListItem>5</asp:ListItem>
                          </asp:DropDownList>
                      </td>
                  </tr>
              </table>

          </EditItemTemplate>

          <SelectedItemStyle BackColor="" Font-Bold="True" ForeColor="Navy" />

    </asp:DataList>


















    <asp:DataList ID="dtlSearch" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" CellPadding="4" OnSelectedIndexChanged="dtlSearch_SelectedIndexChanged" OnCancelCommand="dtlSearch_CancelCommand" OnUpdateCommand="dtlSearch_UpdateCommand">
        <FooterStyle  Font-Bold="True" />
          <HeaderStyle  Font-Bold="True" ForeColor="White" />
          <ItemStyle  ForeColor="#333333" />
          <ItemTemplate>
              <table class="SearchTables">
                  <tr>
                      <td rowspan="6">
                        <asp:Image ID="img" runat="server" Height="121px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"imgx") %>' Width="140px"></asp:Image>
                      </td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label6" runat="server" Text="Id:"></asp:Label></td>
                      <td><asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ID") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label7" runat="server" Text="Name:"></asp:Label></td>
                      <td><asp:Label ID="lblpname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"title") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label8" runat="server" Text="Price:"></asp:Label></td>
                      <td><asp:Label ID="lblprice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"price") %>'></asp:Label></td>
                  </tr>
                   <tr>
                      <td><asp:Label ID="Label9" runat="server" Text="Color:"></asp:Label></td>
                      <td><asp:Label ID="lblqua" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"color") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label10" runat="server" Text="Quantity:"></asp:Label></td>
                      <td><asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"quantity") %>'></asp:Label></td>
                  </tr>
                  <tr  id="CenterTd">
                      <td><asp:Button ID="btnorder" runat="server" Text="Order" CommandName="select"></asp:Button></td>
                  </tr>
                  <br />
                  <br />
                  <br />
              </table>

          </ItemTemplate>
          <AlternatingItemStyle />
          <EditItemTemplate>
               <table>
                  <tr>
                      <td rowspan="5">
                        <asp:Image ID="img" runat="server" Height="121px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"imgx") %>' Width="140px"></asp:Image>
                      </td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label6" runat="server" Text="Id:"></asp:Label></td>
                      <td><asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ID") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label7" runat="server" Text="Name:"></asp:Label></td>
                      <td><asp:Label ID="lblpname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"title") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label8" runat="server" Text="Price:"></asp:Label></td>
                      <td><asp:Label ID="lblprice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"price") %>'></asp:Label></td>
                  </tr>
                   <tr>
                      <td><asp:Label ID="colorlbl" runat="server" Text="Color:"></asp:Label></td>
                      <td><asp:Label ID="lblcolor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"color") %>'></asp:Label></td>
                  </tr>
                   <tr>
                      <td><asp:Label ID="Label9" runat="server" Text="Quantity:"></asp:Label></td>
                      <td><asp:Label ID="lblqua" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"quantity") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td colspan="3"><asp:Button ID="btnconfirm" runat="server" CommandName="Update" Text="Confirm" Enabled="True"></asp:Button>
                          <asp:Button ID="btncancel" runat="server" Text="Cancel" CommandName="cancel"></asp:Button>
                           <asp:DropDownList ID="drpqua" runat="server">
                               <asp:ListItem>1</asp:ListItem>
                               <asp:ListItem>2</asp:ListItem>
                               <asp:ListItem>3</asp:ListItem>
                               <asp:ListItem>4</asp:ListItem>
                               <asp:ListItem>5</asp:ListItem>
                          </asp:DropDownList>
                      </td>
                  </tr>
              </table>

          </EditItemTemplate>

          <SelectedItemStyle BackColor="" Font-Bold="True" ForeColor="Navy" />




    </asp:DataList>







































    <div id="shopCart">
        <asp:GridView ID="grdorder" CssClass="OrderTbl" runat="server" OnSelectedIndexChanged="grdorder_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="Cancel Item" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <div id="ReciptTblBtn">
        </div>
    </div>
    

















    <div id="totalRecipt">The Total Price Is: <asp:Label ID="lbltotal" runat="server" Text="0"></asp:Label></div>



















    <div id="search"><asp:TextBox ID="SearchBox" placeholder="Search..." runat="server"></asp:TextBox><asp:ImageButton ID="SearchButton" runat="server" ImageUrl="~/images/searchImg.png" Width="55px" OnClick="SearchButton_Click" /></div>
    <asp:Button ID="Order_btn" runat="server" Text="Order" OnClick="Order_btn_Click1" />


    <asp:ImageButton ID="ShopCartIcon" ImageUrl="~/images/ShoppingCartIcon.png" runat="server" />

</asp:Content>
