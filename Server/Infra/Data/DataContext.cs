using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Server.Domain.Entities;

namespace Server.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Sexes.Add(new Sex("Masculino"));
            Sexes.Add(new Sex("Feminino"));
            SaveChanges();
        }

        
        public DbSet<Sex> Sexes { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // sex
            modelBuilder.Entity<Sex>().ToTable("Sex");
            // modelBuilder.Entity<Sex>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Sex>().HasKey(x => x.Id);
            modelBuilder.Entity<Sex>().Property(x => x.Description).HasMaxLength(15).HasColumnType("varchar(15)");
            modelBuilder.Entity<Sex>().Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow);
            modelBuilder.Entity<Sex>().Property(x => x.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .Metadata
                .SetAfterSaveBehavior(PropertySaveBehavior.Save);
            // user
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().Property(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(200).HasColumnType("varchar(200)");
            modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(100).HasColumnType("varchar(100)");
            modelBuilder.Entity<User>().Property(x => x.Password).HasMaxLength(30).HasColumnType("varchar(30)");
            modelBuilder.Entity<User>().Property(x => x.Active).HasColumnType("bit");
            modelBuilder.Entity<User>().Property(x => x.Birth).HasColumnType("datetime");
            modelBuilder.Entity<User>().HasOne(x => x.Sex).WithOne().HasForeignKey<User>(x => x.SexId);
            modelBuilder.Entity<User>().Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<User>().Property(x => x.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .Metadata
                .SetAfterSaveBehavior(PropertySaveBehavior.Save);
        }
    }
}