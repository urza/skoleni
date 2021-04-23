using BankOfSheeps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfSheepsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private Dictionary<string, Client> _dataset = new Dictionary<string, Client>();

        public ClientController()
        {
            _dataset = Data.MemoryDataset.GetClients();
        }

        [HttpGet]
        [Route("All")]
        public IEnumerable<Client> GetAll()
        {
            return _dataset.Values;
        }

        [HttpGet]
        [Route("Get/{email}")] // localhost:124/api/get/Jakub.Novotny.1972@example.com
        public IActionResult GetClient(string email)
        {
            Task.Delay(2000).Wait();
            return Ok(_dataset[email]);
        }

        [HttpGet]
        [Route("Get/{email}/Balance/")]
        public double GetBalance(string email)
        {
            //Jakub.Novotny.1972@example.com
            return _dataset[email].AccountBalance;
        }


    }
}
