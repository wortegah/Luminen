using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BillsProvidersServices.Models
{
    public partial class BillsProvidersLuminenContext : DbContext
    {
        public BillsProvidersLuminenContext(DbContextOptions<BillsProvidersLuminenContext> options) : base(options)
        { }
        public virtual DbSet<Bills> Bills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"data source=40.121.222.138;initial catalog=BillsProvidersLuminen;persist security info=True;user id=dasuarez;password=Umng1131;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bills>(entity =>
            {
                entity.HasKey(e => e.IdBill);

                entity.Property(e => e.IdBill).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();
            });
        }
    }
}
