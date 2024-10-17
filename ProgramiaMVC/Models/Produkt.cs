namespace ProgramiaMVC.Models
{
    public class Produkt
    {
        public int Id { get; set; }
        public string NazevProduktu { get; set; }
        public string PopisProduktu { get; set; }
        public decimal Cena { get; set; }
        public int SkladovaZasoba { get; set; }

        //public virtual ICollection<ProduktObrazek> Obrazky { get; set; }
    }
}
