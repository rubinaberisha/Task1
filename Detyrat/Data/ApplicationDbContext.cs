using System.Collections.Generic;
using System.Data;
using System;
using Microsoft.EntityFrameworkCore;
using Detyrat.Models;

namespace Detyrat.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
       public DbSet<Qyteti> Qyteti {  get; set; }

    }
}

