using Cental.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Context
{
    public class CentalContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=YAVUZ\\SQLEXPRESS; database=CentalRentACar; integrated security = true; trustServerCertificate = true");
        }
        DbSet<About> Abouts { get; set; }
        DbSet<Banner> Banners { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<Process> Processes { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<Testimonial> Testimonials { get; set; }
    }
}
