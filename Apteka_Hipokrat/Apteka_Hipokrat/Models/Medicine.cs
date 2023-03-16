using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apteka_Hipokrat.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CatalogNumber { get; set; }
        public string Composition { get; set; }
        public string Apply { get; set; }
        //M : 1
        public int SideEffectId { get; set; }
        public SideEffect SideEffects { get; set; } 

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        //M : 1
        public int MedicineTypeId { get; set; }
        public MedicineType MedicineTypes { get; set; }

        public DateTime RegisterON { get; set; }
        //M : 1
        public int ProducerId { get; set; }
        public Producer Producers { get; set; } 

        public string Description { get; set; }
        public string ImageURL { get; set; }
        //1 : M
        public ICollection<Shopping> Shoppings { get; set; }  
    }
}
