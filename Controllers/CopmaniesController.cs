using Microsoft.AspNetCore.Mvc;
using HRManagementAPI.Models;
using HRManagementAPI.Data;

namespace HRManagementAPI.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompaniesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/companies
        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _context.Companies.ToList();
            return Ok(companies);
        }

        // GET: api/companies/5
        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            var company = _context.Companies.Find(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        // POST: api/companies
        [HttpPost]
        public IActionResult CreateCompany([FromBody] Company company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Companies.Add(company);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCompany), new { id = company.Company_Code }, company);
        }

        // PUT: api/companies/5
        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, [FromBody] Company company)
        {
            if (id != company.Company_Code)
                return BadRequest();

            var existingCompany = _context.Companies.Find(id);
            if (existingCompany == null)
                return NotFound();

            existingCompany.Company_Code = company.Company_Code;
            existingCompany.Company_Name = company.Company_Name;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/companies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var company = _context.Companies.Find(id);
            if (company == null)
                return NotFound();

            _context.Companies.Remove(company);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
