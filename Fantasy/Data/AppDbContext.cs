using Microsoft.EntityFrameworkCore;
using Fantasy.Models;
using System.Collections.Generic;

namespace Fantasy.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TokenBlacklist> TokenBlacklists { get; set; }
    }
}
