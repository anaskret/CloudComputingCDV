using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MobileAppsLab3.Models.Models;
using MobileAppsLab3.Web.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppsLab3.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PeopleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            var response = await _context.People.ToListAsync();
            return Ok(response);
        }

        [HttpGet("{id}/photo")]
        public async Task<IActionResult> GetPhoto([FromRoute] int id)
        {
            var response = await _context.People.FirstOrDefaultAsync(x => x.Id == id);
            return base.File(Convert.FromBase64String(response.PictureBase64), "image/jpg");
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] Person person)
        {
            await _context.AddAsync(person);
            _context.SaveChanges();
            return Ok();
        }


    }
}
