<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfStudent.aspx.cs" Inherits="BITCollegeSite.wfStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
    <asp:Label ID="lblName" runat="server" Text="Name" BackColor="White" Font-Bold="True"></asp:Label>
</p>
<asp:GridView ID="gvCourse" runat="server" AutoGenerateColumns="False" Height="227px" Width="582px" OnSelectedIndexChanged="SelectedIndexChange">
    <Columns>
        <asp:ButtonField CommandName="Select" Text="Select" />
        <asp:BoundField HeaderText="Course" DataField="Course.CourseNumber" />
        <asp:BoundField HeaderText="Title" DataField="Course.Title" />
        <asp:BoundField HeaderText="Credit Hours" DataField="Course.CreditHours" >
        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:BoundField>
        <asp:BoundField HeaderText="Course Type" DataField="Course.CourseType" />
        <asp:BoundField HeaderText="Tuition" DataField="Course.TuitionAmount" DataFormatString="{0:c}" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
<p>
</p>
<p>
    <asp:LinkButton ID="lbuRegister" runat="server" OnClick="lbuRegister_Click">Click Here to Register for a Course Link</asp:LinkButton>
</p>
<p>
</p>
<p>
    <asp:Label ID="lblStudentError" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
    &nbsp;</p>
<p>
</p>
<p>
    &nbsp;</p>
<p>
</p>
</asp:Content>
