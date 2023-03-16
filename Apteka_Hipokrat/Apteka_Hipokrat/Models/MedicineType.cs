namespace Apteka_Hipokrat.Models
{
    public class MedicineType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisterON { get; set; }

        public ICollection<Medicine> Medicines { get; set; } 
    }
}
