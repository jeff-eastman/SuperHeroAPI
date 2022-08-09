using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SuperHeroController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            var superheroes = await _context.SuperHeroes.ToListAsync();
           // List<SuperHero> superheroes = await _context.SuperHeroes.ToListAsync();
            return superheroes;
        }



        [HttpPost]
        public async Task<ActionResult<SuperHero>> CreateSuperHero([FromBody] SuperHero superhero )
        {
            _context.Add(superhero);
            await _context.SaveChangesAsync();
            return Ok();
            //var result = await _context.Add

              //  ret

        }


        [HttpDelete]
        public async Task<ActionResult> DeleteSuperHero(int id)
        {
            var superhero = await _context.SuperHeroes.FirstOrDefaultAsync(s => s.Id == id);

            if(superhero == null)
            {
                return NotFound();
            }

            _context.Remove(superhero);
            await _context.SaveChangesAsync();
            return NoContent();
        }


      
    }
}
