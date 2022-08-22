using ApiVuelos.Context;
using ApiVuelos.DTO;
using ApiVuelos.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiVuelos.Controllers
{
    [Route("api/ciudades")]
    [ApiController]
    public class CiudadesController: ControllerBase
    {

        private readonly ILogger<CiudadesController> logger;
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public CiudadesController( ILogger<CiudadesController> logger,
            ApplicationDBContext context,
            IMapper mapper
            )
        {

            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("ver")]
        public async Task<ActionResult<List<CiudadDTO>>> Get()
        {

            var ciudades= await context.ciudades.ToListAsync();

            return mapper.Map<List<CiudadDTO>>(ciudades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CiudadDTO>> Get(int id)
        {

           var ciudad= await context.ciudades.FirstOrDefaultAsync(x=> x.Id == id);

            if (ciudad == null)
            {
                return NotFound();
            }

            return mapper.Map<CiudadDTO>(ciudad);
            
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CiudadDTO ciudadCreateDTO)
        {
            var ciudad= mapper.Map<Ciudad>(ciudadCreateDTO);
            context.Add(ciudad);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] CiudadDTO ciudadEditDTO)
        {
            var ciudad = await context.ciudades.FirstOrDefaultAsync(x => x.Id == id);

            if (ciudad == null)
            {
                return NotFound();
            }

            ciudad= mapper.Map(ciudadEditDTO, ciudad);

            await context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async  Task<ActionResult> Delete(int id)
        {
            var existe = await context.ciudades.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Ciudad() { Id = id });
            await context.SaveChangesAsync();

            return NoContent();

        }


    }
}
