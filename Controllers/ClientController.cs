using ClientNote_API_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientNote_API_EF.DTO;

namespace ClientNotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientContext _dbcontext;
        private readonly ILogger<ClientController> _logger;
        public ClientController(ClientContext dbContext, ILogger<ClientController> logger)
        {
            this._dbcontext = dbContext;
            this._logger = logger;
        }
        // GET: api/clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients() {
            if (this._dbcontext.Clients == null) {
                return NotFound();
            }
            return await this._dbcontext.Clients.ToListAsync();
        }
        // GET: api/clients/404
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id) {
            if (this._dbcontext.Clients == null) {
                return NotFound();
            }
            var foundClient = await this._dbcontext.Clients.FindAsync(id);
            return foundClient == null ? NotFound() : foundClient;
        }
        // POST: api/clients
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient( ClientDto clientDto ) {

            var client = new Client {
                Name =  clientDto.Name,
                LastName = clientDto.LastName,
                Phone = clientDto.Phone,
                Email = clientDto.Email,
                Archived = false,
                Created = DateTime.Now,
                Updated = null,
                Deleted = null,
                Comments = clientDto.Comments.Select(c => new Comment { Description = c.Description }).ToList()
            };

            this._dbcontext.Add( client );
            await this._dbcontext.SaveChangesAsync();
            return CreatedAtAction( nameof(GetClient), new { id = client.Id }, client );
        }
        
        // PUT: api/clients/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, ClientDto clientDto )
        {

            if( id != clientDto.Id )
            {
                return BadRequest();
            }

            var clientFound = await this._dbcontext.Clients.FindAsync(id);

            if (clientFound == null)
            {
                return NotFound();
            }

            clientFound.Name = clientDto.Name;
            clientFound.LastName = clientDto.LastName;
            clientFound.Phone = clientDto.Phone;
            clientFound.Email = clientDto.Email;
            clientFound.Archived = clientDto.Archived;
            clientFound.Updated = DateTime.Now.ToString();

            _dbcontext.Entry(clientFound).State = EntityState.Modified;

            await _dbcontext.SaveChangesAsync();

            return NoContent();
        }

    }
}
