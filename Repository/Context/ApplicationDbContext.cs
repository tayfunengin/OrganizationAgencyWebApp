using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Authentication;
using Repository.Entities;
using Repository.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppUserRole, int>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options)
        {

        }

     
        public DbSet<Model> Models { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<PhotoGraphy> PhotoGraphies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
            new ModelMap(modelBuilder.Entity<Model>());
            new OrganizationMap(modelBuilder.Entity<Organization>());          
            new ReportByOrganizationMap(modelBuilder.Entity<Report>());
            new OrganizationAndModelMap(modelBuilder.Entity<OrganizationAndModel>());

            base.OnModelCreating(modelBuilder);
        }

    }
}
