<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfDrop.aspx.cs" Inherits="BITCollegeSite.wfDrop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:DetailsView ID="dvDrop" runat="server" AutoGenerateRows="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="162px" Width="333px" AllowPaging="True" OnPageIndexChanging="dvDrop_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
            <EditRowStyle BackColor="#2461BF" />
            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
            <Fields>
                <asp:BoundField HeaderText="Registration" DataField="RegistrationId" />
                <asp:BoundField HeaderText="Student" DataField="Student.FullName" />
                <asp:BoundField HeaderText="Course" DataField="Course.Title" />
                <asp:BoundField HeaderText="Date" DataField="RegistrationDate" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField HeaderText="Grade" DataField="Grade" DataFormatString="{0:P}" />
            </Fields>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="2" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
        </asp:DetailsView>
    </p>
    <p>
        <asp:LinkButton ID="lbuDropCourse" runat="server" OnClick="lbuDropCourse_Click">Drop Course</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbuRegistration" runat="server" OnClick="lbuRegistration_Click">Return to Registration Listing</asp:LinkButton>
    </p>
    <p>
        <asp:Label ID="lblDropError" runat="server" Font-Bold="True" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
