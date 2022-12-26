using Microsoft.AspNetCore.Identity;

namespace BuzDolabiVI.Models
{
    public class UserDetails:IdentityUser
    {
        public string AdSoyad { get; set; }
        public string ozluSoz { get; set; }
        public string cinsiyet { get; set; }
        public string sosyalMedya { get; set; }
    }
}
