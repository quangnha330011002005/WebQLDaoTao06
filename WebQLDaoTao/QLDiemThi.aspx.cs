using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class QLDiemThi : System.Web.UI.Page
    {
        KetQuaDAO kqDAO = new KetQuaDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btLuu_Click(object sender, EventArgs e)
        {
            int rows = gvKetQua.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                int id = int.Parse(gvKetQua.DataKeys[i].Value.ToString());
                double diem= double.Parse(((TextBox)gvKetQua.Rows[i].FindControl("txtDiem")).Text);
                kqDAO.Update(id,diem);
            }
            Response.Write("<script> alert'(Thay đổi thành côngg)' </script>");
        }
    }
}