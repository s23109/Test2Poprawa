using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TestTemplate.Models
{
    public class MainDbContext :DbContext
    {

        //db sety np:
        // public DbSet<Model> Model {get;set;}
        public DbSet<Organisation> Organisation { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<File> File { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Membership> Membership { get; set; }

        List<Organisation> organisationList = new List<Organisation>
        {
            new Organisation{
            OrganisationID = 1,
            OrganisationName= "Sus",
            OrganisationDomain = "Mogus"
            }
        };
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


            modelBuilder.Entity<Organisation>(e =>
            {
                e.HasKey(e => e.OrganisationID);
                e.Property(e => e.OrganisationName).HasMaxLength(100).IsRequired();
                e.Property(e => e.OrganisationDomain).HasMaxLength(50).IsRequired();
                e.HasData(organisationList);
                e.ToTable("Organisation");
            });

            modelBuilder.Entity<Team>(e =>
            {
                e.HasKey(e => e.TeamID);
                e.Property(e => e.OrganisationID).IsRequired();
                e.Property(e => e.TeamName).HasMaxLength(50).IsRequired();
                e.Property(e => e.TeamDescription).HasMaxLength(100);

                e.HasOne(e => e.Organisation)
                .WithMany(e => e.Team)
                .HasForeignKey(e => e.OrganisationID)
                .OnDelete(DeleteBehavior.Cascade);

                e.ToTable("Team");
            });

            modelBuilder.Entity<File>(e =>
            {
                e.HasKey(e => e.FileID);
                e.HasKey(e => e.TeamID);

                e.Property(e => e.FileName).HasMaxLength(100).IsRequired();
                e.Property(e => e.FileExtention).HasMaxLength(4).IsRequired();
                e.Property(e => e.FileSize).IsRequired();

                e.HasOne(e => e.Team)
               .WithMany(e => e.File)
               .HasForeignKey(e => e.TeamID)
               .OnDelete(DeleteBehavior.Cascade);

                e.ToTable("File");
            });

            modelBuilder.Entity<Member>(e =>
            {
                e.HasKey(e => e.MemberID);

                e.Property(e => e.OrganisationID).IsRequired();
                e.Property(e => e.MemberName).HasMaxLength(20).IsRequired();
                e.Property(e => e.MemberSurname).HasMaxLength(50).IsRequired();
                e.Property(e => e.MemberNickName).HasMaxLength(20);

                e.HasOne(e => e.Organisation)
               .WithMany(e => e.Member)
               .HasForeignKey(e => e.OrganisationID)
               .OnDelete(DeleteBehavior.ClientSetNull);

                e.ToTable("Member");
            });

            modelBuilder.Entity<Membership>(e =>
            {
                e.HasKey(e => e.MemberID);
                e.HasKey(e => e.TeamID);
                e.Property(e => e.MembershipDate).IsRequired();

                e.HasOne(e => e.Member)
               .WithMany(e => e.Membership)
               .HasForeignKey(e => e.MemberID)
               .OnDelete(DeleteBehavior.NoAction);

                e.HasOne(e => e.Team)
               .WithMany(e => e.Membership)
               .HasForeignKey(e => e.TeamID)
               .OnDelete(DeleteBehavior.NoAction);

                e.ToTable("Membership");
            });
        }
    }
}
