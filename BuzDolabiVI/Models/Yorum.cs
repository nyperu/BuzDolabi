using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace BuzDolabiVI.Models
{
    public class Yorum
    {

        [Key]
        public string yorumID { get; set; }

        public string userID { get; set; }
        public string tarifID { get; set; }
      
        public DateTime tarih { get; set; }
        public string icerik { get; set; }


    }
}
