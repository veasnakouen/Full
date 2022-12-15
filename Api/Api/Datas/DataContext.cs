using Api.Models;
using Microsoft.EntityFrameworkCore;
namespace Api.Datas
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        public DbSet<Post> Posts { get; set; }

    }

   
  
}
