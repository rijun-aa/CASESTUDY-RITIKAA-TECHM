using Microsoft.EntityFrameworkCore;
using COMPLAINTREGISTERATION.Models;

namespace COMPLAINTREGISTERATION.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Admin> Admin { get; set; }


    }
}

