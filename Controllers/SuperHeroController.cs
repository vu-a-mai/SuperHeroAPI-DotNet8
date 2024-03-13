using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Data;
using SuperHeroAPI_DotNet8.Entities;

namespace SuperHeroAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        // inject data context
        private readonly DataContext _context;

        // inject data context into the service repository
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            // Access SuperHeroes Table
            // Turn it to a List
            var heroes = await _context.SuperHeroes.ToListAsync();

            // Return Status Code: 200
            return Ok(heroes);
        }

        // Route id
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetHero(int id)
        {
            // Find the hero based on the id
            var hero = await _context.SuperHeroes.FindAsync(id);

            // if hero is not found
            if(hero is null)
            {
                // Return Status Code: 404
                return NotFound("Hero not found");
            }

            // Return Status
            return Ok(hero);
        }
    }
}
