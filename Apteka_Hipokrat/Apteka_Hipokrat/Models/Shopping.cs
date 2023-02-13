namespace Apteka_Hipokrat.Models
{
    public class Shopping
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public User Users { get; set; }
        public int MedicineId { get; set; }
        public int quantity { get; set; }
        public decimal TotalSum { get; set; }
        public DateTime RegisterON { get; set; }
        public Medicine Medicines { get; set; }

    }
}
