using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace BuzDolabiVI.Models
{
    public class Yorum
    { 
        [Key]
        public int yorumID { get; set; }
        public string yorumOnay { get; set; }
        public string yorumTarih { get; set; }
        public string yorumIcerik { get; set; }
        public string yorumAdSoyad { get; set; }
        public string yorumOzluSoz { get; set; }
        public string yorumCinsiyet { get; set; }
        public string yorumSosyal { get; set; }
        public int tarifID { get; set; }
        public Tarif Tarif { get; set; }
        
    }
}
