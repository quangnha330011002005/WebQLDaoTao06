<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QLKhoa.aspx.cs" Inherits="WebQLDaoTao.QLKhoa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="alert alert-info">Nội Dung Quản Lý Trang Khoa </div>
    <asp:GridView ID="gvKhoa" runat="server" AutoGenerateColumns="false" DataSourceID="ods_Khoa" 
        cssClass="table table-bordered table-hover">
        <Columns>
            <asp:BoundField DataField="MaKH" HeaderText="Mã Khoa" SortExpression="MaKH" ReadOnly="true"/>
            <asp:BoundField DataField="TenKH" HeaderText="Tên Khoa" SortExpression="TenKH"/>
            <asp:CommandField  ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True"/>
            </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ods_Khoa" runat="server"
        DataObjectTypeName="WebQLDaoTao.Models.Khoa"
        DeleteMethod="Delete"
        InsertMethod="Insert"
        SelectMethod="getAll"
        TypeName="WebQLDaoTao.Models.KhoaDAO" 
        UpdateMethod="Update">
    </asp:ObjectDataSource>
</asp:Content>