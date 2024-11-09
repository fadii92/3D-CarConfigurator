using CustomerLibraryDAL;
using System.Data.SqlClient;

namespace BlazorServerAuthenticationAndAuthorization.Authentication
{
    public class UserAccountService
    {
        private List<UserAccount> _users;
        
        public UserAccountService()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetUserAndPass", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            _users = new List<UserAccount>();
            while (dr.Read())
            {
                UserAccount _user = new UserAccount();
                _user.UserName = dr["UserName"].ToString();
                _user.Password = dr["Pass"].ToString();
                _user.Role = dr["Role"].ToString();
                _users.Add(_user);
                //new UserAccount { UserName = "admin", Password = "admin", Role = "Administrator" };
            };
        }

        public UserAccount? GetByUserName(string userName)
        {
            return _users.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
