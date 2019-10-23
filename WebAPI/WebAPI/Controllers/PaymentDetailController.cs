using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public PaymentDetailController(PaymentDetailContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paymentdetails>>> GetPaymentdetails()
        {
            return await _context.Paymentdetails.ToListAsync();
        }

        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paymentdetails>> GetPaymentdetails(int id)
        {
            var paymentdetails = await _context.Paymentdetails.FindAsync(id);

            if (paymentdetails == null)
            {
                return NotFound();
            }

            return paymentdetails;
        }

        // PUT: api/PaymentDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentdetails(int id, Paymentdetails paymentdetails)
        {
            if (id != paymentdetails.PMID)
            {
                return BadRequest();
            }

            _context.Entry(paymentdetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentdetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentDetail
        [HttpPost]
        public async Task<ActionResult<Paymentdetails>> PostPaymentdetails(Paymentdetails paymentdetails)
        {
            _context.Paymentdetails.Add(paymentdetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentdetails", new { id = paymentdetails.PMID }, paymentdetails);
        }

        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paymentdetails>> DeletePaymentdetails(int id)
        {
            var paymentdetails = await _context.Paymentdetails.FindAsync(id);
            if (paymentdetails == null)
            {
                return NotFound();
            }

            _context.Paymentdetails.Remove(paymentdetails);
            await _context.SaveChangesAsync();

            return paymentdetails;
        }

        private bool PaymentdetailsExists(int id)
        {
            return _context.Paymentdetails.Any(e => e.PMID == id);
        }
    }
}
