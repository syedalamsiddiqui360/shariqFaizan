using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace shariqFaizan.Models
{
    public class CategoryDB
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["sfDB"].ToString();
            con = new SqlConnection(constring);
        }

        public bool AddCategory(Category smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", smodel.ct_name);
            
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public List<Category> GetCategory()
        {
            connection();
            List<Category> categorylist = new List<Category>();

            SqlCommand cmd = new SqlCommand("GetCategories", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                categorylist.Add(
                    new Category
                    {
                        ct_id = Convert.ToInt32(dr["ct_id"]),
                        ct_name = Convert.ToString(dr["ct_name"])
                        
                    });
            }
            return categorylist;
        }

        public bool UpdateCategory(Category smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateCategories", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StdId", smodel.ct_id);
            cmd.Parameters.AddWithValue("@Name", smodel.ct_name);
          

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public bool DeleteCategory(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StdId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


    }
}