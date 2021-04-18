using BankOfSheeps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfSheepsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
       
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return Data.LoadFromXML(@"C:\PROJECTS\IctPro\CNET2-urza-git\BankOfSheeps\BankOfSheeps\BankOfSheeps\dataset.xml");
        }

        [HttpGet]
        [Route("active")]
        public IEnumerable<Client> GetActive()
        {
            var data = Data.LoadFromXML(@"C:\PROJECTS\IctPro\CNET2-urza-git\BankOfSheeps\BankOfSheeps\BankOfSheeps\dataset.xml");
            return data.Where(x => x.IsActive).ToList();
        }

        [HttpGet]
        [Route("suspended")]
        public IEnumerable<Client> GetSuspended()
        {
            var data = Data.LoadFromXML(@"C:\PROJECTS\IctPro\CNET2-urza-git\BankOfSheeps\BankOfSheeps\BankOfSheeps\dataset.xml");
            return data.Where(x => !x.IsActive).ToList();
        }
    }
}
