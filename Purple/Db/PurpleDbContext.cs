using System;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Purple.Entities;

namespace Purple.Db;

public class PurpleDbContext : DbContext
{
    public PurpleDbContext([NotNull] DbContextOptions options) : base(options)
    {
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity);

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
                (entry.Entity as BaseEntity)!.DateAdded = DateTime.Now;

            if (entry.State == EntityState.Modified)
                (entry.Entity as BaseEntity)!.DateModified = DateTime.Now;
        }

        return base.SaveChanges();
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(e =>
        {
            e.ToTable("user");
            e.Property(u => u.Id).ValueGeneratedNever();
        });
    }
}