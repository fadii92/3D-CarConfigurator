using CustomerLibraryModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLibraryDAL
{
    public class CustDAL
    {
        public static int SaveCustomer(CustModel HM,string role)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UserRegInfo", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", HM.FirstName);
            cmd.Parameters.AddWithValue("@LastName", HM.LastName);
            cmd.Parameters.AddWithValue("@Phone", HM.Phone);
            cmd.Parameters.AddWithValue("@Email", HM.Email);
            cmd.Parameters.AddWithValue("@City", HM.City);
            cmd.Parameters.AddWithValue("@Username", HM.Username);
            cmd.Parameters.AddWithValue("@Pass", HM.Pass);
            cmd.Parameters.AddWithValue("@ConfirmPassword", HM.ConfirmPassword);
            cmd.Parameters.AddWithValue("@role", HM.role);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public static List<CustModel> GetCustomerModels()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetUsers", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<CustModel> customerlist = new List<CustModel>();
            while (reader.Read())
            {
                CustModel customermodel = new CustModel();
                customermodel.FirstName = reader["FirstName"].ToString();
                customermodel.LastName = reader["LastName"].ToString();
                customermodel.Phone = reader["Phone"].ToString();
                customermodel.Email = reader["Email"].ToString();
                customermodel.City = reader["City"].ToString();
                customermodel.Username = reader["Username"].ToString();
                customermodel.Pass = reader["Pass"].ToString();
                customermodel.ConfirmPassword = reader["ConfirmPassword"].ToString();

                customerlist.Add(customermodel);
            }
            con.Close();
            return customerlist;
        }
    }
}
