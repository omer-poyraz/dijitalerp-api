using System.Reflection;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public DbSet<AssemblyFailureState> AssemblyFailureStates { get; set; }
        public DbSet<AssemblyManuel> AssemblyManuels { get; set; }
        public DbSet<AssemblyNote> AssemblyNotes { get; set; }
        public DbSet<AssemblyVisualNote> AssemblyVisualNotes { get; set; }
        public DbSet<AssemblySuccessState> AssemblySuccessStates { get; set; }
        public DbSet<AssemblyQuality> AssemblyQualities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<TechnicalDrawing> TechnicalDrawings { get; set; }
        public DbSet<TechnicalDrawingFailureState> TechnicalDrawingFailureStates { get; set; }
        public DbSet<TechnicalDrawingSuccessState> TechnicalDrawingSuccessStates { get; set; }
        public DbSet<TechnicalDrawingNote> TechnicalDrawingNotes { get; set; }
        public DbSet<TechnicalDrawingVisualNote> TechnicalDrawingVisualNotes { get; set; }
        public DbSet<TechnicalDrawingQuality> TechnicalDrawingQualities { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
