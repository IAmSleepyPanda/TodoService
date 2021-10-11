using DomainContext.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DomainContext
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<TodoItem> TodoItems { get; set; }

    }
}
