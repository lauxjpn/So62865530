using System;
using System.Reflection;
using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IApplicationDbContext
    {
        private readonly ICurrentUserService currentUserService;

        public DbSet<Student> Students { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            ICurrentUserService currentUserService) :
            base(options)
        {
            this.currentUserService = currentUserService;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}