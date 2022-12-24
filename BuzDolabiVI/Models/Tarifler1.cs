
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace BuzDolabiVI.Models
{
    public class Tarifler1
    {
        [Key]
        public int tarifID { get; set; }
        public string tarifAd { get; set; }
        public string tarifFoto { get; set; }
        public string tarifMalzemeler { get; set; }
        public string tarifNasilYapilir { get; set; }
        public DateTime tarifTarih { get; set; }
        public int goruntulenme { get; set; }
        public string tarifGirisYazisi { get; set; }
        public string kacKalori { get; set; }
        public string besinDegeriLink { get; set; }
        public int kacKisilik { get; set; }
        public int hazirlanmaSuresi { get; set; }
        public int pisirmeSuresi { get; set; }
        public string onay { get; set; }

        public string yazarAd { get; set; }
        public string yazarOzluSoz { get; set; }
        public string yazarCinsiyet { get; set; }
        public string yazarSosyal { get; set; }

    }
}
