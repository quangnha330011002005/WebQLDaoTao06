﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class QLMonHoc : System.Web.UI.Page
    {
        MonHocDAO mhDAO = new MonHocDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (Session["VaiTro"] == null)
                {
                    Response.Redirect("Default.aspx"); // Nếu chưa đăng nhập thì về trang Login
                }
                //lien ket du lieu cho gvMonhoc
                LoadData();
                SetPermissions();
            }
        }

        private void SetPermissions()
        {
            string role = Session["VaiTro"] != null ? Session["VaiTro"].ToString() : "Khach";

            if (role == "Khach")
            {
                // Ẩn nút Thêm
                btnThem.Visible = false;

                // Ẩn cột Sửa/Xóa trong GridView nếu có
                if (gvMonHoc.Columns.Count >= 3)
                {
                    gvMonHoc.Columns[gvMonHoc.Columns.Count - 1].Visible = false; // Cột Xóa
                    gvMonHoc.Columns[gvMonHoc.Columns.Count - 2].Visible = false; // Cột Sửa
                }
            }
        }

        private void LoadData()
        {
            gvMonHoc.DataSource = mhDAO.getAll();
            gvMonHoc.DataBind();
        }

        protected void gvMonHoc_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMonHoc.EditIndex = -1;
            gvMonHoc.DataSource = mhDAO.getAll();
            gvMonHoc.DataBind();
        }

        protected void gvMonHoc_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMonHoc.EditIndex = e.NewEditIndex;
            gvMonHoc.DataSource = mhDAO.getAll();
            gvMonHoc.DataBind();
        }

        protected void gvMonHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string mamh = gvMonHoc.DataKeys[e.RowIndex].Value.ToString();
                mhDAO.Delete(mamh);
                LoadData();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Không thể xoá môn học này')</script>");
            }
        }

        protected void gvMonHoc_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string mamh = gvMonHoc.DataKeys[e.RowIndex].Value.ToString();
            string tenmh = ((TextBox)gvMonHoc.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            int sotiet = int.Parse(((TextBox)gvMonHoc.Rows[e.RowIndex].Cells[2].Controls[0]).Text);
            MonHoc mhUpdate = new MonHoc { MaMH = mamh, TenMH = tenmh, SoTiet = sotiet };
            mhDAO.Update(mamh,tenmh,sotiet);
            gvMonHoc.EditIndex = -1;
            LoadData();
        }

        protected void gvMonHoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMonHoc.PageIndex = e.NewPageIndex;
            LoadData();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string mamh = txtMamh.Text;
                string tenmh = txtTenmh.Text;
                int sotiet = int.Parse(txtsotiet.Text);
                if (mhDAO.findById(mamh) != null)
                {
                    Response.Write("<script>alert('Mã môn học đã tồn tại. Chọn mã khác nhé.')</script>");
                    return;
                }
                MonHoc mhInsert = new MonHoc { MaMH = mamh, TenMH = tenmh, SoTiet = sotiet };
                mhDAO.Insert(mamh,tenmh,sotiet);
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Thao tác thêm môn học không thành công.')</script>");
            }
            LoadData();
        }
    }
}