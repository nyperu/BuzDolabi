using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace BuzDolabiVI.Models
{
    public class Yorum
    {

        [Key]
        public int yorumID { get; set; }

        public int userID { get; set; }
        public string kullaniciAdi { get; set; }
        public string tarifAdi { get; set; }
        public string kategoriID { get; set; }
        public string onay { get; set; }
        public int tarifID { get; set; }

        public DateTime tarih { get; set; }
        public string icerik { get; set; }
    }
}
