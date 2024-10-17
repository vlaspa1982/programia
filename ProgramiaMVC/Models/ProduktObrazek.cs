using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgramiaMVC.Models
{
    public class ProduktObrazek
    {
        [Key]
        public int Id { get; set; }

        public string Adresa { get; set; }

        // Cizí klíč pro produkt
        [ForeignKey("Produkt")]
        public int ProduktId { get; set; }
        public Produkt Produkt { get; set; }
    }

}
