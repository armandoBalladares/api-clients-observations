using Microsoft.EntityFrameworkCore;

namespace ClientNote_API_EF.Models { 

    public class ObservationContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Comment> Comments { get; set; }

        ObservationContext(DbContextOptions<ObservationContext> options ): base(options) {

        }
    }
}
