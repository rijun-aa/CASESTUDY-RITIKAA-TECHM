using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMPLAINTREGISTERATION.Models;

namespace COMPLAINTREGISTERATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComplaintsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Complaints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Complaint>>> GetComplaints()
        {
            return await _context.Complaints
                .Include(c => c.Customer)
                .Include(c => c.Application)
                .Include(c => c.Service)
                .Include(c => c.Branch)
                .ToListAsync();
        }


        // GET: api/Complaints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Complaint>> GetComplaint(int id)
        {
            var complaint = await _context.Complaints
                .Include(c => c.Customer)
                .Include(c => c.Application)
                .Include(c => c.Service)
                .Include(c => c.Branch)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (complaint == null)
            {
                return NotFound();
            }

            return complaint;
        }
        // PUT: api/Complaints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComplaint(int id, Complaint complaint)
        {
            if (id != complaint.Id)
            {
                return BadRequest();
            }

            _context.Entry(complaint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplaintExists(id))
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

        // POST: api/Complaints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        //[HttpPost]
        //public async Task<ActionResult<Complaint>> PostComplaint(Complaint complaint)
        //{
        //    if (complaint == null)
        //    {
        //        return BadRequest("Complaint data is missing.");
        //    }

        //    // Retrieve full details of related entities
        //    complaint.Application = await _context.Applications.FindAsync(complaint.ApplicationId);
        //    complaint.Service = await _context.Services.FindAsync(complaint.ServiceId);
        //    complaint.Branch = await _context.Branches.FindAsync(complaint.BranchId);

        //    // Optionally set Customer if the CustomerId is provided
        //    if (complaint.CustomerId != 0)
        //    {
        //        complaint.Customer = await _context.Customer.FindAsync(complaint.CustomerId);
        //    }

        //    _context.Complaints.Add(complaint);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetComplaint", new { id = complaint.Id }, complaint);
        //}
        [HttpPost]
        public async Task<ActionResult<Complaint>> PostComplaint(Complaint complaint)
        {
            if (complaint == null || string.IsNullOrWhiteSpace(complaint.Description))
            {
                return BadRequest("Complaint data is missing or description is empty.");
            }

            // Retrieve full details of related entities
            complaint.Application = await _context.Applications.FindAsync(complaint.ApplicationId);
            complaint.Service = await _context.Services.FindAsync(complaint.ServiceId);
            complaint.Branch = await _context.Branches.FindAsync(complaint.BranchId);

            // Optionally set Customer if the CustomerId is provided
            if (complaint.CustomerId != 0)
            {
                complaint.Customer = await _context.Customer.FindAsync(complaint.CustomerId);
            }

            _context.Complaints.Add(complaint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComplaint", new { id = complaint.Id }, complaint);
        }


        // DELETE: api/Complaints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplaint(int id)
        {
            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint == null)
            {
                return NotFound();
            }

            _context.Complaints.Remove(complaint);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool ComplaintExists(int id)
        {
            return _context.Complaints.Any(e => e.Id == id);
        }
    }
}
