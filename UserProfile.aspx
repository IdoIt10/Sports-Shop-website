<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Project_Web_Final.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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
        input[type=submit] {
            position:absolute;
            margin-left: 10%;
            margin-top: 24%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div id="UserProfMain">
        <h1>Your UserName:</h1>
        <h2><%=user_name%></h2>
        <h1>Your Password:</h1>
            <h2><%=password%></h2>
        <h1>Your First Name:</h1>
            <h2><%=firstName%></h2>
        <h1>Your Last Name:</h1>
            <h2><%=lastName%></h2>
        <h1>Your Phone:</h1>
            <h2><%=phone%></h2>
        <h1>Your Age:</h1>
            <h2><%=age%></h2>
        <h1>Your Email:</h1>
            <h2><%=Email%></h2>
        <h1>Your Profile Image:</h1>
        <img src="<%=img_name %>" id="ProfImg"/>
    </div> --%>
    <h1>Your Profile:</h1>
    <table id="UserProfTable">
        <tr>
            <td class="auto-style1">
                User Name
            </td>
            <td class="auto-style1">
                <%=user_name%>
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                <%=password%>
            </td>
        </tr>
        <tr>
            <td>
                First Name
            </td>
            <td>
                <%=firstName%>
            </td>
        </tr>
        <tr>
            <td>
                Last Name
            </td>
            <td>
                <%=lastName%>
            </td>
        </tr>
        <tr>
            <td>
                Phone
            </td>
            <td>
                <%=phone%>
            </td>
        </tr>
        <tr>
            <td>
                Age
            </td>
            <td>
                <%=age%>
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <%=Email%>
            </td>
        </tr>
    </table>

    <img src="<%=img_name %>" id="ProfImg1"/>
    <br />
    <asp:Button ID="toUpdatePage" runat="server" Text="Update Details" OnClick="toUpdatePage_Click" />

    
</asp:Content>
