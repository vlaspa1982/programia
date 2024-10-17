namespace ProgramiaMVC.Models
{
   
        public class Objednavka
        {
            public int Id { get; set; }
            public DateTime DatumObjednavky { get; set; }
            public int ZakaznikId { get; set; }
            public virtual Zakaznik Zakaznik { get; set; }
            public virtual ICollection<ObjednavkaPolozka> Polozky { get; set; }  // Položky objednávky
        }
    
}
