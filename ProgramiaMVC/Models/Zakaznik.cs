namespace ProgramiaMVC.Models
{

        public class Zakaznik
        {
            public int Id { get; set; }
            public string Jmeno { get; set; }
            public string Prijmeni { get; set; }
            public string Email { get; set; }
            public string Telefon { get; set; }
            public virtual ICollection<Objednavka> Objednavky { get; set; }  // Objednávky zákazníka
        }
    }
