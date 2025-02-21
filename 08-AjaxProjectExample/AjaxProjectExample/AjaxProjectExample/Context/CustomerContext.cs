using AjaxProjectExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace AjaxProjectExample.Context
{
    public class CustomerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=YAVUZ\\SQLEXPRESS; database=AjaxProjectDb; integrated security = true; trustServerCertificate = true");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}