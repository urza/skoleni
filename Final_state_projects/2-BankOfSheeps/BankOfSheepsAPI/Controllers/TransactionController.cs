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
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        [Route("Add/{email}/")]
        public IActionResult AddTransaction(string email, [FromBody]Transaction tx)
        {
            //api/Transaction/add/email
            //Jakub.Novotny.1972@example.com

            var client = Data.MemoryDataset.GetClients()[email];
            client.Transactions.Add(tx);

            Data.MemoryDataset.GetClients()[email] = client;

            return Ok();
        }
    }
}
