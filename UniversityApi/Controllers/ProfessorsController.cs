using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApi;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly OurDbContext _context;
        private readonly IMapper _mapper;

        public ProfessorsController(OurDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Professors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessors()
        {
          if (_context.Professors == null)
          {
              return NotFound();
          }
            return await _context.Professors.ToListAsync();
        }

        // GET: api/Professors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessor(int id)
        {
          if (_context.Professors == null)
          {
              return NotFound();
          }
            var professor = await _context.Professors.FindAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            return professor;
        }

        // PUT: api/Professors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor(int id, Professor professor)
        {
            if (id != professor.Id)
            {
                return BadRequest();
            }

            _context.Entry(professor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(id))
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

        // POST: api/Professors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessor(BasicProfessorDto professorDto)
        {
          if (_context.Professors == null)
          {
              return Problem("Entity set 'OurDbContext.Professors'  is null.");
          }
          var record = _mapper.Map<Professor>(professorDto);
            _context.Professors.Add(record);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfessor", new { id = record.Id }, record);
        }

        // DELETE: api/Professors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            if (_context.Professors == null)
            {
                return NotFound();
            }
            var professor = await _context.Professors.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }

            _context.Professors.Remove(professor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfessorExists(int id)
        {
            return (_context.Professors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
