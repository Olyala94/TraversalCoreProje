using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-9E5P6SH;database=TraversalDB;integrated security=true;");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //IP Adresi Olaca//Host- Ana Bilgisayar bilğisi//databaseName:traversaldb//integrated security=true : KAldırılacak, Çünkü bizim artık kullanıcı adı ve şifremiz olacak o bilğiler ile bağlanacağız --> //user = admin. ; password = 6H0&2w2fk;"
        //    optionsBuilder.UseSqlServer("server=77.245.159.10\\MSSQLSERVER2019;database=traversaldb;");
        //}

        public DbSet<About> Abouts { get; set; }

        public DbSet<About2> About2s { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactUs> ContactUses { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<Feature1> Feature1s { get; set; }

        public DbSet<Feature2> Feature2s { get; set; }

        public DbSet<Guide> Guides { get; set; }

        public DbSet<Newsletter> Newsletters { get; set; }

        public DbSet<SubAbout> SubAbouts { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
