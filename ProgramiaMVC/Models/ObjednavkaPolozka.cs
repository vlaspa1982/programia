namespace ProgramiaMVC.Models
{
        public class ObjednavkaPolozka
        {
            public int Id { get; set; }
            public int ProduktId { get; set; }
            public virtual Produkt Produkt { get; set; }  
            public int ObjednavkaId { get; set; }
            public virtual Objednavka Objednavka { get; set; }  
            public int Mnozstvi { get; set; }
            public decimal CenaZaJednotku { get; set; }

    }
    
}
