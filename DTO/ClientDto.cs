using ClientNote_API_EF.Models;
using System.Security.Policy;

namespace ClientNote_API_EF.DTO
{
    public class ClientDto {
        public required string Name { get; set; }
        public string? LastName { get; set; } = null!;
        public required string Phone { get; set; }
        public string? Email { get; set; } = null!;
        public bool? Archived { get; set; } = false;
        public DateTime?  Created { get; set; } = DateTime.Now;
        public string? Updated { get; set; } = DateTime.Now.ToString();
        public string? Deleted { get; set; } = DateTime.Now.ToString();
        public ICollection<CommentDto>? Comments { get; set; }

    }
}
