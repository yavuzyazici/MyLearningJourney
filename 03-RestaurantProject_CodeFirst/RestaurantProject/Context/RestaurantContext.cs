using RestaurantProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;

namespace RestaurantProject.Context
{
    public class RestaurantContext : DbContext
    {
        public DbSet<RestaurantAbout> RestaurantAbouts {  get; set; }
        public DbSet<RestaurantBooking> RestaurantBookings { get; set; }
        public DbSet<RestaurantCategory> RestaurantCategories { get; set; }
        public DbSet<RestaurantChef> RestaurantChefs { get; set; }
        public DbSet<RestaurantChefSocial> RestaurantChefSocials { get; set; }
        public DbSet<RestaurantContactInfo> RestaurantContactInfo { get; set; }
        public DbSet<RestaurantEvent> RestaurantEvents { get; set; }
        public DbSet<RestaurantHero> RestaurantHeros { get; set; }
        public DbSet<RestaurantMessage> RestaurantMessages { get; set; }
        public DbSet<RestaurantPhotoGallery> RestaurantPhotoGalleries { get; set; }
        public DbSet<RestaurantProduct> RestaurantProducts { get; set; }
        public DbSet<RestaurantService> RestaurantServices { get; set; }
        public DbSet<RestaurantTestimonial> RestaurantTestimonials { get; set; }
        public DbSet<RestaurantMeta> RestaurantMetas { get; set; }
        public DbSet<RestaurantAdmin> RestaurantAdmins { get; set; }
    }
}