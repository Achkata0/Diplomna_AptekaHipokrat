namespace Apteka_Hipokrat.Models
{
    public class SideEffect
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime RegisterON { get; set; }
        public ICollection<Medicine> Medicines { get;set; }
    }
}
