using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _TransactionService;
        public TransactionController(ITransactionService _TransactionService)
        {
            this._TransactionService = _TransactionService;
        }

        [Authorize]
        [HttpPost("Submit")]
        public async Task<IActionResult> Submit([FromBody] TransactionModel model)
        {
            if(!await _TransactionService.ValidateTransaction(model))
            {
                bool success = await _TransactionService.InsertTrBpkb(model);
                if (success) return Ok(200);
                else return StatusCode(500);
            }
            else return StatusCode(500);
        }
    }
}
