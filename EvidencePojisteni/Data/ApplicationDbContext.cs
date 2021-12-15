using EvidencePojisteni.Models;
using EvidencePojisteni.Models.InsuranceEvents;
using EvidencePojisteni.Models.Products;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvidencePojisteni.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<InsuranceEvent> InsuranceEvents { get; set; }

        public virtual DbSet<TestModel> TestModels { get; set; }
    }
}
