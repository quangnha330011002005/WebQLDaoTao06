using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string vaitro = "Khach"; // ✅ Gán vai trò mặc định là Khách

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                lblMessage.Text = "Vui lòng nhập đầy đủ thông tin.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Kiểm tra mật khẩu xác nhận
            if (password != confirmPassword)
            {
                lblMessage.Text = "Mật khẩu xác nhận không khớp.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            TaiKhoanDAO dao = new TaiKhoanDAO();

            // 🛑 Kiểm tra tài khoản đã tồn tại chưa
            if (dao.KiemTraTonTai(username))
            {
                lblMessage.Text = "Tài khoản đã tồn tại. Vui lòng chọn tên khác!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Nếu chưa tồn tại, thực hiện đăng ký
            TaiKhoan newUser = new TaiKhoan(username, password, vaitro);

            if (dao.DangKyTaiKhoan(newUser))
            {
                lblMessage.Text = "Đăng ký thành công!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                lblMessage.Text = "Có lỗi xảy ra. Vui lòng thử lại!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnRegister_Click1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string vaitro = "Khach"; // ✅ Gán vai trò mặc định là Khách

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                lblMessage.Text = "Vui lòng nhập đầy đủ thông tin.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Kiểm tra mật khẩu xác nhận
            if (password != confirmPassword)
            {
                lblMessage.Text = "Mật khẩu xác nhận không khớp.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            TaiKhoanDAO dao = new TaiKhoanDAO();

            // 🛑 Kiểm tra tài khoản đã tồn tại chưa
            if (dao.KiemTraTonTai(username))
            {
                lblMessage.Text = "Tài khoản đã tồn tại. Vui lòng chọn tên khác!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Nếu chưa tồn tại, thực hiện đăng ký
            TaiKhoan newUser = new TaiKhoan(username, password, vaitro);

            if (dao.DangKyTaiKhoan(newUser))
            {
                lblMessage.Text = "Đăng ký thành công!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                lblMessage.Text = "Có lỗi xảy ra. Vui lòng thử lại!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnRegister_Click2(object sender, EventArgs e)
        {

        }
    }
}
