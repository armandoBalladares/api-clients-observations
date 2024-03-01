using Microsoft.EntityFrameworkCore;

namespace ClientNote_API_EF.Models { 

    public class ClientContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ClientContext(DbContextOptions<ClientContext> options ): base(options) {

        }

    }
}
