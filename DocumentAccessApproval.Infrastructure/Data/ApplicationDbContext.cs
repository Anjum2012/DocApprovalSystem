using DocumentAccessApproval.Domain.Entities;
using DocumentAccessApproval.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DocumentAccessApproval.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<AccessRequest> AccessRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccessRequest>()
                .HasOne(ar => ar.RequestorUser)
                .WithMany(u=>u.RequestedAccesses)
                .HasForeignKey(ar => ar.RequestorUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccessRequest>()
                .HasOne(ar => ar.ApproverUser)
                .WithMany(u => u.ApprovedAccesses)
                .HasForeignKey(ar => ar.ApproverUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccessRequest>()
                    .HasOne(e => e.Document)
                    .WithMany(d => d.AccessRequests)
                    .HasForeignKey(e => e.DocumentId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccessRequest>()
                    .HasIndex(ar => new { ar.RequestorUserId, ar.DocumentId })
                    .IsUnique();

            // Seed data
            SeedData(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "John Doe", Email = "john.doe@company.com", Role = UserRole.User },
                new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@company.com", Role = UserRole.Approver },
                new User { Id = 3, Name = "Bob Wilson", Email = "bob.wilson@company.com", Role = UserRole.User },
                new User { Id = 4, Name = "Alice Johnson", Email = "alice.johnson@company.com", Role = UserRole.Admin }
            );

            // Seed Documents
            modelBuilder.Entity<Document>().HasData(
                new Document { Id = 1, Title = "Q4 Financial Report", Description = "Quarterly financial analysis and projections" },
                new Document { Id = 2, Title = "Employee Handbook", Description = "Company policies and procedures" },
                new Document { Id = 3, Title = "Strategic Plan 2024", Description = "5-year strategic business plan" },
                new Document { Id = 4, Title = "Technical Specifications", Description = "Product technical documentation" }
            );
        }
    }
}
