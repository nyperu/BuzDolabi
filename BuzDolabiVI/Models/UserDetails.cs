using Microsoft.AspNetCore.Identity;

namespace BuzDolabiVI.Models
{
    public class UserDetails:IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}
