using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CustomerModel;
using CustomerLibraryDAL;

namespace CustomerDAL
{
    public class NewCustomerDAL
    {
        public static int SaveNewCustomer(NewCustomerModel NM)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_AddCustInfo", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MName", NM.MName);
            cmd.Parameters.AddWithValue("@Phone", NM.Phone);
            cmd.Parameters.AddWithValue("@Email", NM.Email);
            cmd.Parameters.AddWithValue("@Street", NM.Street);
            cmd.Parameters.AddWithValue("@City", NM.City);
            cmd.Parameters.AddWithValue("@State", NM.State);
            cmd.Parameters.AddWithValue("@zip_code", NM.zip_code);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
