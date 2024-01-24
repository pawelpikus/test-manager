using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestManager.Server.Data;
using TestManager.Server.Data.Models;

namespace TestManager.Server.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController(AppDBContext context) : ControllerBase
    {
        private readonly AppDBContext _context = context;

        // GET: api/Test
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Test>>> GetTests()
        {
            return await _context.Tests.ToListAsync();
        }

        // GET: api/Test/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> GetTest(int id)
        {
            var test = await _context.Tests.FindAsync(id);

            if (test == null)
            {
                return NotFound("Sorry, no such test!");
            }

            return test;
        }

        [HttpPost("filters")]
        public async Task<ActionResult<IEnumerable<Test>>> FilteredTests(Filter filters) 
        {
            if (_context.Tests == null)
            {
                return NotFound("No Data Found!");
            }

            List<Test> allData = await _context.Tests.ToListAsync();

            if (filters.All)
            {
                return allData;
            }

            if(filters.Status != null)
            {
                allData = allData.Where(e => e.Status == filters.Status).ToList();
            }

            if (filters.SpecifiedDate != null)
            {
                allData = allData.Where(e => e.KickOffTimeStamp == filters.SpecifiedDate).ToList();
            }

            if (filters.StartDate != null && filters.EndDate != null)
            {
                allData = allData.Where(e => e.LastModifiedTimeStamp >= filters.StartDate && e.LastModifiedTimeStamp <= filters.EndDate).ToList();
            }


            if (filters.FwVersion != null)
            {
                allData = allData.Where(e => e.FwVersion == filters.FwVersion).ToList();
            }

            if (filters.RackName != null)
            {
                allData = allData.Where(e => e.RackName == filters.RackName).ToList();
            }

            return allData;
        }
    

        // PUT: api/Test/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTest(int id, Test test)
        {
            if (id != test.ID)
            {
                return BadRequest("You're trying to modify a wrong test!");
            }

            // _context.Entry(test).State = EntityState.Modified;

            

            try
            {
                Test entry_ = await _context.Tests.FirstAsync(e=> e.ID == test.ID);
                
                if (entry_.Title != test.Title)
                {
                    entry_.Title = test.Title;
                }

                if (entry_.Status != test.Status)
                {
                    entry_.Status = test.Status;
                }

                if (entry_.FwVersion != test.FwVersion)
                {
                    entry_.FwVersion = test.FwVersion;
                }

                if (entry_.RackName != test.RackName)
                {
                    entry_.RackName = test.RackName;
                }

                if (entry_.KickOffTimeStamp != test.KickOffTimeStamp)
                {
                    entry_.KickOffTimeStamp = test.KickOffTimeStamp;
                }

                if (entry_.LastModifiedTimeStamp != test.LastModifiedTimeStamp)
                {
                    entry_.LastModifiedTimeStamp = test.LastModifiedTimeStamp;
                }


                if (entry_.Time != test.Time)
                {
                    entry_.Time = test.Time;
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(id))
                {
                    return NotFound($"No test with the id {id} doesn't exist!  ");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Test updated successfully");
        }

        // POST: api/Test
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Test>> PostTest(Test test)
        {
            try
            {
                _context.Tests.Add(test);
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException e) 
            {
                return BadRequest($"Couldn't create the new Test: {e.Message}");
            }
            

            return CreatedAtAction("GetTest", new { id = test.ID }, test);
        }

        // DELETE: api/Test/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(int id)
        {
            var test = await _context.Tests.FirstAsync(e => e.ID == id);
            if (test == null)
            {
                return NotFound($"No test with id {id} found!");
            }

            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();

            return Ok("Test deleted successfully");
        }

        private bool TestExists(int id)
        {
            return _context.Tests.Any(e => e.ID == id);
        }
    }
}
