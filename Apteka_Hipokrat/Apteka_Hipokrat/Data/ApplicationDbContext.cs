using Apteka_Hipokrat.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Apteka_Hipokrat.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<SideEffect> SideEffects { get; set; }
        public virtual DbSet<MedicineType> MedicineTypes { get; set; }
        public virtual DbSet<Shopping> shoppings { get; set; }
    }
}