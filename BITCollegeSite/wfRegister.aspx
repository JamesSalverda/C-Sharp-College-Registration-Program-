<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfRegister.aspx.cs" Inherits="BITCollegeSite.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Label ID="lblStudentName" runat="server" Font-Bold="True" Text="Label" OnLoad="Page_Load"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblCourseSelector" runat="server" Text="Course Selector: "></asp:Label>
        <asp:DropDownList ID="ddlCourses" runat="server" Height="18px" Width="219px">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblRegistrationNotes" runat="server" Text="Registration Notes: "></asp:Label>
        <asp:TextBox ID="txtRegistrationNotes" runat="server" Width="199px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Notes are Required for Web Registrations"></asp:Label>
    </p>
    <p>
    </p>
    <p>
        <asp:LinkButton ID="lbuRegister" runat="server" OnClick="lbuRegister_Click">Register</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbuReturn" runat="server" OnClick="lbuReturn_Click">Return to Registration Listing</asp:LinkButton>
    </p>
    <p>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
