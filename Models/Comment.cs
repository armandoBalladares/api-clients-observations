using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientNote_API_EF.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public  int Id { get; set; }
        public required string Description { get; set; }

        
        public int ClientId { get; set; } // FK
        public Client? Client { get; set; } // Navegation


        public DateTime? Created { get; set; }
        public string? Updated { get; set; }
        public string? Deleted { get; set; }

    }
}
