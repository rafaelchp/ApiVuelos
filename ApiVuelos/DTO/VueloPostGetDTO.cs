using System.Collections.Generic;

namespace ApiVuelos.DTO
{
    public class VueloPostGetDTO
    {
        public List<AerolineaDTO> Aerolineas { get; set; }
        public List<CiudadDTO> Ciudades { get; set; }
    }
}
