namespace Apteka_Hipokrat.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CatalogNumber { get; set; }
        public string Composition { get; set; }
        public string Apply { get; set; }
        public int SideEffectId { get; set; }
        public SideEffect SideEffects { get; set; }
        public decimal Price { get; set; }
        public int MedicineTypeId { get; set; }
        public MedicineType MedicineTypes { get; set; }
        public DateTime RegisterON { get; set; }
        public int ProducerId { get; set; }
        public Producer Producers { get; set; }
        public string Description { get; set; }
        public int ShoppingId { get; set; }
        public ICollection<Shopping> Shoppings { get; set; }
    }
}
