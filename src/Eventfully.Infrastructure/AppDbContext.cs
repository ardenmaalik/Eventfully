using Eventfully.Application.Common.Models;
using Eventfully.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eventfully.Infrastructure
{
    // IdentityDbContext is a subclass of DbContext to manage user authentication and authorization
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

    }
}
