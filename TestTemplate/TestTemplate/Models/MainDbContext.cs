using Microsoft.EntityFrameworkCore;

namespace TestTemplate.Models
{
    public class MainDbContext :DbContext
    {

        //db sety np:
        // public DbSet<Model> Model {get;set;};

        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* List <Doctor> doctors = new List<Doctor> { dane... }
             * 
             * modelBuilder.Entity<Doctor>(e =>
            {
                e.HasKey(e => e.IdDoctor);  // klucz główny
                e.Property(e => e.FirstName).HasMaxLength(100).IsRequired();  //pole z weryfikacją danych
                e.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                e.Property(e => e.Email).HasMaxLength(100).IsRequired();


                e.HasData(doctors);
                e.ToTable("Doctor");
            });
             * 
             * 
             */
        }
    }
}
