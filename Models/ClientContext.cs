using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ClientNote_API_EF.Models { 

    public class ClientContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ClientContext(DbContextOptions<ClientContext> options ): base(options) {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>()
                .HasMany(cli => cli.Comments)
                .WithOne(com => com.Client );
        }

    }
}
