using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetMVC.Models;
namespace NetMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<NetMVC.Models.Movie> Movie { get; set; }

        public DbSet<NetMVC.Models.Student> Student { get; set; }
    }
}

    
