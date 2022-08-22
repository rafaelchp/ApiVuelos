using ApiVuelos.Context;
using ApiVuelos.DTO;
using ApiVuelos.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiVuelos.Controllers
{
    [ApiController]
    [Route("api/vuelos")]
    public class VuelosController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public VuelosController(ApplicationDBContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VueloCreateDTO vueloCreateDTO)
        {
            var vuelo = mapper.Map<Vuelo>(vueloCreateDTO);

            context.Add(vuelo);
            await context.SaveChangesAsync();

            return NoContent();

        }

        [HttpGet("PostGet")]
        public async Task<ActionResult<VueloPostGetDTO>> PostGet()
        {
            var aerolineas = await context.aerolinea.ToListAsync();
            var ciudades= await context.ciudades.ToListAsync();

            var aerolineasDTO = mapper.Map<List<AerolineaDTO>>(aerolineas);
            var ciudadesDTO= mapper.Map<List<CiudadDTO>>(ciudades);

            return new VueloPostGetDTO() { Aerolineas = aerolineasDTO, Ciudades = ciudadesDTO };

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VueloDTO>> Get(int id)
        {
            var vuelo = await context.vuelos
                .Include(x => x.vuelosCiudades).ThenInclude(x => x.ciudad)
                .Include(x=>x.vuelosAerolinea).ThenInclude(x=>x.aerolinea)
                .FirstOrDefaultAsync(x=>x.Id==id);

            if (vuelo == null) { return NotFound(); }

            var dto= mapper.Map<VueloDTO>(vuelo);

            return dto;



        }

        [HttpGet("view-vuelos")]
        public async Task<ActionResult<List<VueloDTO>>> Get()
        {
            var vuelo = await context.vuelos
                .Include(x => x.vuelosCiudades).ThenInclude(x => x.ciudad)
                .Include(x => x.vuelosAerolinea).ThenInclude(x => x.aerolinea).ToListAsync();
                

        

            var dto = mapper.Map<List<VueloDTO>>(vuelo);

            return dto;



        }

    }
}
