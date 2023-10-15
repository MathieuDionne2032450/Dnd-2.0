using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Api_DnD.Model
{

    public class Key
    {
        public const string KEY_ROLE_ADMIN = "ADMIN_ROLE";
        public const string KEY_ROLE_USER = "USER_ROLE";

        [Key]
        public string ApiKey { get; set; }

        public string Role { get; set; }

        public Key(string apiKey, string role) 
        {
            ApiKey = apiKey;
            Role = role;
        }

        public Key() { }
    }
}
