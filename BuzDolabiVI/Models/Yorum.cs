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
        public DateTime yorumTarih { get; set; }
        public string yorumIcerik { get; set; }
        public string yorumKisi { get; set; }
        public string sosyal { get; set; }
        public int tarifID { get; set; }
        public Tarif Tarif { get; set; }
        
    }
}
