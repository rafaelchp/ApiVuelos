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
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public UsuariosController(ApplicationDBContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }



        [HttpGet("ver")]
        public async Task<ActionResult<List<UsuarioDTO>>> Get()
        {

            var usuarios = await context.usuarios.ToListAsync();

            return mapper.Map<List<UsuarioDTO>>(usuarios);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDTO usuarioDTO)
        {
            usuarioDTO.Password= BCrypt.Net.BCrypt.HashPassword(usuarioDTO.Password);
            var usuario = mapper.Map<Usuario>(usuarioDTO);
            context.Add(usuario);
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
