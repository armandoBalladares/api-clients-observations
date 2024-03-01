using ClientNote_API_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientNotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientContext _dbcontext;
        private readonly ILogger<ClientController> _logger;
        public ClientController( ClientContext dbContext, ILogger<ClientController> logger )
        {
           this._dbcontext = dbContext;
           this._logger = logger;
        }
    }
}
