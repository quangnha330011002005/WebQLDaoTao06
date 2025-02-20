<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QLDiemThi.aspx.cs" Inherits="WebQLDaoTao.QLDiemThi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h2>NHẬP ĐIỂM THI</h2>
    <hr />
    <div style="padding:10px">
        Chọn Môn Học <asp:DropDownList ID="ddlMonHoc" runat="server" DataSourceID="odsMonHoc"
            DataTextField="TenMH" DataValueField="MaMH" AutoPostBack="True"></asp:DropDownList>
    </div>
    <asp:GridView ID="gvKetQua" runat="server" AutoGenerateColumns="False" 
        DataSourceID="odsKetQua" CssClass="table table-bordered" Width="70%" DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="MaSV" HeaderText="MaSV" ControlStyle-Width="80px" />
            <asp:BoundField DataField="Hotensv" HeaderText="Họ tên sinh viên" ControlStyle-Width="80px" SortExpression="MaSV" />
            <asp:TemplateField  HeaderText="Điểm Thi">
                <ItemTemplate>
                    <asp:TextBox ID="txtDiem" runat="server" Text='<%# Eval("Diem") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btLuu" runat="server" Text="Lưu" OnClick="btLuu_Click" />
    <asp:ObjectDataSource ID="odsKetQua" runat="server" SelectMethod="getByMaMH" TypeName="WebQLDaoTao.Models.KetQuaDAO">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlMonHoc" Name="mamh" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMonHoc" runat="server" 
        SelectMethod="getAll"
        TypeName="WebQLDaoTao.Models.MonHocDAO"></asp:ObjectDataSource>
</asp:Content>
