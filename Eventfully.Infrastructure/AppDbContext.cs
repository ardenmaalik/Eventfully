using Eventfully.Application.Common.Interfaces;
using Eventfully.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventfully.Infrastructure
{
    // IdentityDbContext is a subclass of DbContext to manage user authentication and authorization
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

    }
}
