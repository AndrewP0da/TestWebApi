using Microsoft.EntityFrameworkCore;
using TestWebApi.DB.Entities;

namespace TestWebApi.DB
{
    public class DataContext: DbContext
    {
        public DbSet<CategoryEntity> Category { get; set; } = null!;
        public DbSet<MenuItemEntity> MenuItems { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        public new IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }
}