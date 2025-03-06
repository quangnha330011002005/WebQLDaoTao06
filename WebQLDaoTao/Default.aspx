<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebQLDaoTao.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <style>
        /* Căn giữa toàn bộ nội dung */
        .container {
            background: white;
            padding: 30px;
            border-radius: 15px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            margin: 30px auto; /* Căn giữa theo chiều ngang */
            max-width: 80%; /* Giới hạn chiều rộng để không bị tràn */
        }

        /* Căn giữa các phần thông tin */
        .card {
            text-align: center;
            background: #ffffff;
            border-radius: 15px;
            box-shadow: 0 3px 6px rgba(0, 0, 0, 0.1);
            transition: 0.3s;
            margin: auto; /* Căn giữa các thẻ card */
            max-width: 90%;
        }

        /* Định dạng cho các khối chức năng */
        .feature-container {
            display: flex;
            justify-content: center; /* Căn giữa các nút chức năng */
            flex-wrap: wrap;
            gap: 25px;
            margin-top: 40px;
        }

        /* Căn giữa các thẻ card thống kê */
        .row.text-center .col-md-3 {
            display: flex;
            justify-content: center;
        }

        .row.text-center .card {
            width: 100%;
            max-width: 250px; /* Định kích thước cố định */
        }

        /* Chỉnh lại box chức năng */
        .feature-box {
            width: 200px; /* Định kích thước */
            padding: 20px;
            text-align: center;
            border-radius: 15px;
            background: #ffffff;
            transition: all 0.3s ease-in-out;
            cursor: pointer;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border: none;
        }

        /* Tiêu đề trang chủ */
        h2.text-center {
            font-weight: bold;
            font-size: 28px;
            color: #01579b;
            text-align: center;
            margin-bottom: 20px;
        }
    </style>

    <div class="container">
        <h2 class="text-center">NỘI DUNG TRANG CHỦ</h2>

        <!-- Giới thiệu hệ thống -->
        <div class="card p-4 mb-4">
            <h4>🎓 Giới thiệu hệ thống</h4>
            <p>
                Hệ thống Quản lý Đào tạo giúp cán bộ và sinh viên dễ dàng theo dõi thông tin học tập, 
                đăng ký môn học và quản lý điểm thi một cách hiệu quả.
            </p>
        </div>

        <!-- Thông báo mới -->
        <div class="card p-4 mb-4">
            <h4>📢 Thông báo mới</h4>
            <ul>
                <li>[05/03/2025] Hạn cuối đăng ký môn học học kỳ 2.</li>
                <li>[01/03/2025] Công bố lịch thi học kỳ 1.</li>
                <li>[25/02/2025] Cập nhật điểm thi giữa kỳ.</li>
            </ul>
        </div>

        <!-- Thống kê bổ sung -->
        <div class="row text-center mb-4">
            <div class="col-md-3">
                <div class="card p-3">
                    <h3>1000+</h3>
                    <p>Sinh viên đăng ký</p>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card p-3">
                    <h3>200+</h3>
                    <p>Môn học đang mở</p>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card p-3">
                    <h3>30+</h3>
                    <p>Lớp học trực tuyến</p>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card p-3">
                    <h3>15+</h3>
                    <p>Khoa & Bộ môn</p>
                </div>
            </div>
        </div>

        <!-- Chức năng chính -->
        <div class="feature-container">
            <a href="QLMonHoc.aspx" class="feature-box">
                <i class="fas fa-book feature-icon"></i>
                <p>Quản lý môn học</p>
            </a>
            <a href="QLKhoa.aspx" class="feature-box">
                <i class="fas fa-university feature-icon"></i>
                <p>Quản lý khoa</p>
            </a>
            <a href="QLSinhVien.aspx" class="feature-box">
                <i class="fas fa-users feature-icon"></i>
                <p>Quản lý sinh viên</p>
            </a>
            <a href="QLDiemThi.aspx" class="feature-box">
                <i class="fas fa-edit feature-icon"></i>
                <p>Quản lý điểm</p>
            </a>
        </div>
    </div>
</asp:Content>
