using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace UserProjectMVC.Models
{
    public class BalUser
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-AHF1BI0E;Initial Catalog=USERManagementMVC;Integrated Security=True");

        public void Register(string Name, string Address, string Email, string Gender, string Number,int cityid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UsermanagementMVC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "RegisterUser");
            cmd.Parameters.AddWithValue("@name",Name);
            cmd.Parameters.AddWithValue("@address",Address);
            cmd.Parameters.AddWithValue("@Email",Email);
            cmd.Parameters.AddWithValue("@gender",Gender);
            cmd.Parameters.AddWithValue("@number",Number);
            cmd.Parameters.AddWithValue("@cityid",cityid);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public DataSet ShowCountry()
        {
            con.Open();
            SqlCommand cmb = new SqlCommand("UsermanagementMVC", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@flag", "GetCountry");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public DataSet ShowState(int CountryId)
        {
            con.Open();
            SqlCommand cmb = new SqlCommand("UsermanagementMVC", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@flag", "GetState");
            cmb.Parameters.AddWithValue("@countryid", CountryId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }

        public DataSet ShowCity(int StateId)
        {
            con.Open();
            SqlCommand cmb = new SqlCommand("UsermanagementMVC", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@flag", "GetCity");
            cmb.Parameters.AddWithValue("@stateid", StateId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }

        public DataSet GetTable()
        {
            con.Open();
            SqlCommand cmb = new SqlCommand("UsermanagementMVC", con);
            cmb.CommandType = CommandType.StoredProcedure;
            cmb.Parameters.AddWithValue("@flag", "ShowRecord");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmb;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }

        public SqlDataReader GetDataUpdate(int Id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UsermanagementMVC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "grdataupdateEdit");
            cmd.Parameters.AddWithValue("@UserId", Id);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }


        public void Updatuser(string Name, string Address, string Email, string Gender, string Number, int cityid,int Userid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UsermanagementMVC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "UpdateUser");
            cmd.Parameters.AddWithValue("@name", Name);
            cmd.Parameters.AddWithValue("@address", Address);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@gender", Gender);
            cmd.Parameters.AddWithValue("@number", Number);
            cmd.Parameters.AddWithValue("@cityid", cityid);
            cmd.Parameters.AddWithValue("@UserId", Userid);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void Deleterecord(int Userid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UsermanagementMVC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DeleteRecord");
            cmd.Parameters.AddWithValue("@UserId", Userid);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public SqlDataReader PopDetails(int userid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UsermanagementMVC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "grdataupdateEdit");
            cmd.Parameters.AddWithValue("@UserId", userid);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();

        }

    }
}
