namespace Apteka_Hipokrat.Models
{
    public class Shopping
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public User Users { get; set; }

        public int MedicineId { get; set; }
        public Medicine Medicines { get; set; } 

        public int Quantity { get; set; } 
        public decimal TotalSum { get; set; }
        public DateTime RegisterON { get; set; }  
        
    }
}
