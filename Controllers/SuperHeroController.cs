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
            /*
            // initialise a list to store SuperHero
            var heroes = new List<SuperHero>
            {

                // add a Super Hero
                new SuperHero
                {
                    Id = 1,
                    Name = "Spiderman",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                }
            };
            */

            // Access SuperHeroes Table
            // Turn it to a List
            var heroes = await _context.SuperHeroes.ToListAsync();

            // Return Status Code: 200
            return Ok(heroes);
        }
    }
}
