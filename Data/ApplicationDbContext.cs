using AppointmentApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)    {

        }
    }
}