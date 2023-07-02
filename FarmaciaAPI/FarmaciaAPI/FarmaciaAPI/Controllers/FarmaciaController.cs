using FarmaciaAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmaciaController : ControllerBase
    {
        private readonly DataContext _context;

        public FarmaciaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Farmacia>>> GetFarmacia()
        {
            return Ok(await _context.Farmacias.ToListAsync());
        }

        [HttpPost]

        public async Task<ActionResult<List<Farmacia>>> CreateFarmacias(Farmacia farmacia)
        {
            _context.Farmacias.Add(farmacia);
            await _context.SaveChangesAsync();

            return Ok(await _context.Farmacias.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Farmacia>>> UpdateFarmacias(Farmacia farmacia)
        {
            var dbfarm = await _context.Farmacias.FindAsync(farmacia.ID);
            if(dbfarm == null)
            {
                return BadRequest("Farmacia não encontrada");           
            }
            dbfarm.Name = farmacia.Name;
            dbfarm.FirstName = farmacia.FirstName;
            dbfarm.LastName = farmacia.LastName;
            dbfarm.Place = farmacia.Place;

            await _context.SaveChangesAsync();
            return Ok(await _context.Farmacias.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Farmacia>>> DeleteFarmacias(int id)
        {
            var dbfarm = await _context.Farmacias.FindAsync(id);
            if (dbfarm == null)
            {
                return BadRequest("Farmacia não encontrada");
            }

            _context.Farmacias.Remove(dbfarm);
            await _context.SaveChangesAsync();

            return Ok(await _context.Farmacias.ToListAsync());

        }




    }
}
