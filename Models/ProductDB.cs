using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace shariqFaizan.Models
{
    public class ProductDB
    {
        private SqlConnection con;

        private void connection()
        {

            string constring = ConfigurationManager.ConnectionStrings["sfDB"].ToString();
            con = new SqlConnection(constring);
        }

        public bool AddProduct(Product p)
        {
            connection();
            SqlCommand cmd = new SqlCommand("Insert into product values('" + p.name + "','" + p.description + "','" + p.price + "','" + p.unit_in_stock + "','" +  p.picture + "','" + p.path + "','" + p.c_id + "')", con);
            cmd.CommandType = CommandType.Text;

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public List<Product> GetProducts()
        {
            connection();
            List<Product> p = new List<Product>();

            SqlCommand cmd = new SqlCommand("select * from product",con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                p.Add(
                    new Product
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = Convert.ToString(dr["name"]),
                        description = Convert.ToString(dr["description"]),
                        unit_in_stock = Convert.ToInt32(dr["unit_in_stock"]),

                        price = Convert.ToDouble(dr["unit_price"]),
                        
                        picture = Convert.ToString(dr["picture"]),
                        path = Convert.ToString(dr["path"]),
                        c_id = Convert.ToInt32(dr["c_id"])

                    });
            }

            return p;
        }

        public bool UpdateProduct(Product p)
        {
            String q = "UPDATE product SET[name] = '" + p.name + "',[description] = '" + p.description + "',[unit_price] = '" + p.price + "',[unit_in_stock] = '" + p.unit_in_stock + "' ,[picture] = '" + p.picture + "',[path]='" + p.path  + "',[c_id]='" + p.c_id + "' WHERE id='" + p.id + "'";
            connection();
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.CommandType = CommandType.Text;


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool DeleteProduct(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("Delete from product where id='" + id + "'", con);
            cmd.CommandType = CommandType.Text;


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