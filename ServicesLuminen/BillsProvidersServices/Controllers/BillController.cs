using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillsProvidersServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillsProvidersServices.Controllers
{
    [Produces("application/json")]
    [Route("api/Bill/[action]")]
    public class BillController : Controller
    {
        private readonly BillsProvidersLuminenContext _context;
        public BillController(BillsProvidersLuminenContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create([FromBody] Bills item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                item.IdBill = Guid.NewGuid();
                item.Date = DateTime.Now;
                item.Description = "Factura generada por el cobro de adicion del producto" + item.IdProduct;
                _context.Bills.Add(item);
                await _context.SaveChangesAsync();
                return Ok("Factura creada al provedor "+ item.IdProvider);
            }
        }
    }
}