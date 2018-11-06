using System.Data.Entity;
using CoreAssoc.Invoice.Data.Entities;

namespace CoreAssoc.Invoice.Data.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DbSet<Entities.Invoice> Invoices { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Invoice>()
                .HasMany(invoice => invoice.Notes)
                .WithRequired(note => note.Invoice)
                .HasForeignKey(note => note.InvoiceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entities.Invoice>()
                .HasRequired(invoice => invoice.User)
                .WithMany()
                .HasForeignKey(invoice => invoice.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Note>()
                .HasRequired(note => note.User)
                .WithMany()
                .HasForeignKey(note => note.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}