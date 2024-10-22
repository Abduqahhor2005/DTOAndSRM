using Microsoft.EntityFrameworkCore;

namespace DTOAndSRM;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}