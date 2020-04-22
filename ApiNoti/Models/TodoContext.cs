using Microsoft.EntityFrameworkCore;

namespace ApiNoti.Models
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoItems> TodoItems { get; set; }
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }
    }
}
