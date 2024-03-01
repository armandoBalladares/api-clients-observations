using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientNote_API_EF.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public required int Id { get; set; }
        public required string Description { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime? Created { get; set; }
        public string? Updated { get; set; }
        public string? Deleted { get; set; }

    }
}
