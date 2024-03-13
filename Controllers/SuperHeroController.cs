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
        // GET - READ DATA
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
        public async Task<ActionResult<SuperHero>> GetHero(int id)
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

        // POST - CREATE DATA
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            // add the hero to the data context
            _context.SuperHeroes.Add(hero);

            // save changes
            await _context.SaveChangesAsync();

            // Return Status
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        // PUT - UPDATE DATA
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero updatedHero)
        {
            // Find the hero based on the id
            var dbHero = await _context.SuperHeroes.FindAsync(updatedHero.Id);

            // if hero is not found
            if (dbHero is null)
            {
                // Return Status Code: 404
                return NotFound("Hero not found");
            }

            // Update Hero information
            dbHero.Name = updatedHero.Name;
            dbHero.FirstName = updatedHero.FirstName;
            dbHero.LastName = updatedHero.LastName;
            dbHero.Place= updatedHero.Place;

            // save changes
            await _context.SaveChangesAsync();

            // Return Status
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        // DELETE - DELETE DATA
        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            // Find the hero based on the id
            var dbHero = await _context.SuperHeroes.FindAsync(id);

            // if hero is not found
            if (dbHero is null)
            {
                // Return Status Code: 404
                return NotFound("Hero not found");
            }

            // remove dbHero data based on id
            _context.SuperHeroes.Remove(dbHero);

            // save changes
            await _context.SaveChangesAsync();

            // Return Status
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}
