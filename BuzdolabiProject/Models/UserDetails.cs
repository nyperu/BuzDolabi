using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace BuzdolabiProject.Models
{
    public class UserDetails:IdentityUser
    {
    
        public string AdSoyad { get; set; }
        public string ozluSoz { get; set; }
        public string sosyalMedya { get; set; }
        public string cinsiyet { get; set; }

      
    }
}
