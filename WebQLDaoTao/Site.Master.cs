﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLDaoTao
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ✅ Hiển thị tên người dùng nếu đã đăng nhập
            if (Session["Username"] != null)
            {
                lblUser.Text = "Xin chào, " + Session["Username"].ToString();
            }
            else
            {
                lblUser.Text = "<a href='Login.aspx' style='color: red; text-decoration: none;'> Đăng Nhập</a>";
                btnLogout.Visible = false;
            }
           
        }



        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // ✅ Xóa dữ liệu Session khi đăng xuất
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx"); // Chuyển về trang đăng nhập
            
        }


        protected void SwitchAccount_Click(object sender, EventArgs e)
        {
        //    LinkButton btn = (LinkButton)sender;
        //    string selectedUser = btn.CommandArgument;

        //    // Cập nhật lại tài khoản hiện tại
        //    Session["CurrentUser"] = selectedUser;

        //    // Chuyển hướng về trang chính
        //    Response.Redirect("Default.aspx");
        }

       
    }
}