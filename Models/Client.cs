using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClientNote_API_EF.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? LastName { get; set; }

        public required string Phone { get; set; }
        public string? Email { get; set; }
        public bool? Archived { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public DateTime? Created { get; set; }
        public string? Updated { get; set; }
        public string? Deleted { get; set; }

    }
}
