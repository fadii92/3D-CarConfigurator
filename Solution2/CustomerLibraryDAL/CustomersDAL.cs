using CustomerLibraryModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLibraryDAL
{
    public class CustomersDAL
    {
            public static int SaveCategories(CustomersModell HM)
            {
                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SaveCateInfo", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rims", HM.Rims);
                cmd.Parameters.AddWithValue("@Paints", HM.Paints);
                cmd.Parameters.AddWithValue("@Stickers", HM.Stickers);
                cmd.Parameters.AddWithValue("@Models", HM.Models);
                cmd.Parameters.AddWithValue("@Vendors", HM.Vendors);
                cmd.Parameters.AddWithValue("@Price", HM.Price);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            public static List<CustomersModell> GetCustomerModels()
            {
                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("Sp_GetCateInfo", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                List<CustomersModell> customerlist = new List<CustomersModell>();
                while (reader.Read())
                {
                CustomersModell customermodel = new CustomersModell();
                    customermodel.Rims = reader["Rims"].ToString();
                    customermodel.Paints = reader["Paints"].ToString();
                    customermodel.Stickers = reader["Stickers"].ToString();
                    customermodel.Models = reader["Models"].ToString();
                    customermodel.Vendors = reader["Vendors"].ToString();
                    customermodel.Price = reader["Price"].ToString();

                    customerlist.Add(customermodel);
                }
                con.Close();
                return customerlist;
            }
    }
}
