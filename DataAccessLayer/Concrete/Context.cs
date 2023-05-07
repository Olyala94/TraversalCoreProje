﻿using EntityLayer.Concrete;
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

            base.OnConfiguring(optionsBuilder);
        }

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
    }
}