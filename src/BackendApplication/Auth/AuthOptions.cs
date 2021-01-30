using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BackendApplication.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "BackendApp"; 
        public const string AUDIENCE = "User"; 
        const string KEY = "secretkey!123veeeeeeerylong";   
        public const int LIFETIME = 2; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
