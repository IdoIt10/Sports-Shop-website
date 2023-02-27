<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="AdminMain.aspx.cs" Inherits="Project_Web_Final.AdminMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        

        #ContentPlaceHolder1_grdclients{
            position:absolute;
            width:70%;
            border-collapse: collapse;
        }
        #ContentPlaceHolder1_grdclients th, td{
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid;
            border-top:0px;
            border-right:0px;
            border-left:0px;
        }

        #ContentPlaceHolder1_SearchBox{
            margin-left:78%;
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
            margin-left:93%;
            position:absolute;
            margin-top:1.5%;
            outline: 0;
        }

        #ContentPlaceHolder1_dtlSearch{
            margin-left:75%;
            margin-top:4%;
            width:15%;
            position:absolute;
        }

        .DTLsearched td{
            border-bottom:0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>
        <asp:GridView ID="grdclients" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grdclients_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField>
                <ItemTemplate><%-- תמונה של המוצר--%>
                    <asp:Image ID="Image2" runat="server" Height="96px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"nameImg") %>' Width="110px" />
                </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="userName" HeaderText="User Name" />
                <asp:BoundField DataField="password" HeaderText="Password" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="firstName" HeaderText="First Name" />
                <asp:BoundField DataField="lastName" HeaderText="Last Name" />
                <asp:BoundField DataField="phone" HeaderText="Phone" />
                <asp:BoundField DataField="age" HeaderText="Age" />
                <asp:BoundField DataField="isDirector" HeaderText="isDirector" />
                <asp:CommandField ButtonType="Button" SelectText="Delete User" ShowSelectButton="True" />
            </Columns>
            
        
        </asp:GridView>
    </div>
    
    <div id="search"><asp:TextBox ID="SearchBox" placeholder="Search..." runat="server"></asp:TextBox>
    <asp:ImageButton ID="SearchButton" runat="server" ImageUrl="~/images/searchImg.png" Width="55px" OnClick="SearchButton_Click" /></div>
















    <asp:DataList ID="dtlSearch" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" CellPadding="4" CssClass="DTLsearched">
        <FooterStyle  Font-Bold="True" />
          <HeaderStyle  Font-Bold="True" ForeColor="White" />
          <ItemStyle  ForeColor="#333333" />
          <ItemTemplate>
              <table class="SearchTables">
                  <tr>
                      <td rowspan="6">
                        <asp:Image ID="img" runat="server" Height="121px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"nameImg") %>' Width="140px"></asp:Image>
                      </td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label6" runat="server" Text="User Name:"></asp:Label></td>
                      <td><asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"userName") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label7" runat="server" Text="Password:"></asp:Label></td>
                      <td><asp:Label ID="lblpname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"password") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label8" runat="server" Text="Email:"></asp:Label></td>
                      <td><asp:Label ID="lblprice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"email") %>'></asp:Label></td>
                  </tr>
                   <tr>
                      <td><asp:Label ID="Label9" runat="server" Text="First Name:"></asp:Label></td>
                      <td><asp:Label ID="lblqua" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"firstName") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="Label10" runat="server" Text="Last Name:"></asp:Label></td>
                      <td><asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"lastName") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td>

                      </td>
                      <td><asp:Label ID="Label1" runat="server" Text="Phone:"></asp:Label></td>
                      <td><asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"phone") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td>

                      </td>
                      <td><asp:Label ID="Label4" runat="server" Text="Age:"></asp:Label></td>
                      <td><asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"age") %>'></asp:Label></td>
                  </tr>
                  <tr>
                      <td>

                      </td>
                      <td><asp:Label ID="Label11" runat="server" Text="Director:"></asp:Label></td>
                      <td><asp:Label ID="Label12" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"isDirector") %>'></asp:Label></td>
                  </tr>

                  <br />
                  <br />
                  <br />
              </table>

          </ItemTemplate>
          <AlternatingItemStyle />
          




    </asp:DataList>















</asp:Content>
