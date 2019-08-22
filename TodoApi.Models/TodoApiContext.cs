using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoApiContext : DbContext
    {
        public TodoApiContext(DbContextOptions<TodoApiContext> options) : base(options)
        {

        }
        

        public DbSet<TodoItem> TodoItems { get; set; }

    }
}