using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class KetQuaDAO
    {

        //đọc danh sách các môn học trong CSDL
        public List<KetQua> getByMaMH(string mamh)
        {
            List<KetQua> dsKetQua = new List<KetQua>();
            //1.Mở kết nối CSDL
            SqlConnection conn = new
SqlConnection(ConfigurationManager.ConnectionStrings["QLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            //2.tao truy van
            SqlCommand cmd = new SqlCommand("select id,ketqua.masv,hosv,tensv,mamh,diem  from ketqua inner join sinhvien on ketqua.masv=sinhvien.masv "
                +"where mamh=@mamh", conn);
            cmd.Parameters.AddWithValue("@mamh",mamh);
            //3.thuc thi ket qua;
            SqlDataReader dr = cmd.ExecuteReader();
            //4.xu ly ket qua tra ve
            while (dr.Read())
            {
                //tao doi tuong mon hoc
                
                {
                    KetQua kq = new KetQua();

                    kq.Id = int.Parse(dr["id"].ToString());
                    kq.MaSV = dr["masv"].ToString();
                    kq.HoTenSV = dr["hosv"] + " " + dr["tensv"];
                    kq.MaMH = dr["mamh"].ToString();
                    if (dr["diem"] != DBNull.Value)
                    {
                        kq.Diem = double.Parse(dr["diem"].ToString());
                    }
                    dsKetQua.Add(kq);
                }
                
                
            }
        return dsKetQua;
        }
        public int Update(int id, double diem)
        {
            //1.Mo ket noi CSDL
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["QLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            //2.tao truy van
            SqlCommand cmd = new SqlCommand("update ketqua set diem=@diem where id=@id", conn);
            cmd.Parameters.AddWithValue("@diem", diem);
            cmd.Parameters.AddWithValue("@id", id);
            //3.thuc thi ket qua;
            return cmd.ExecuteNonQuery();
        }
    }
}