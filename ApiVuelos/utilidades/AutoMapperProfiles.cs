using ApiVuelos.DTO;
using ApiVuelos.Entidades;
using AutoMapper;
using System.Collections.Generic;

namespace ApiVuelos.utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<Ciudad, CiudadDTO>().ReverseMap();
            CreateMap<CiudadCreateDTO, Ciudad>();
            CreateMap<Aerolinea, AerolineaDTO>().ReverseMap();
            CreateMap<AerolineaCreateDTO, Aerolinea>();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioCreateDTO, Usuario>();
            CreateMap<UserLoginDTO, Usuario>();

            CreateMap<VueloCreateDTO, Vuelo>()
                .ForMember(x => x.vuelosCiudades, opciones => opciones.MapFrom(MapearVuelosCiudades))
                .ForMember(x => x.vuelosAerolinea, opciones => opciones.MapFrom(MapearVuelosAerolineas));

            CreateMap<Vuelo, VueloDTO>()
                .ForMember(x => x.aerolineaDTOs, options => options.MapFrom(MappearVuelosAerolinea))
                .ForMember(x => x.ciudadDTOs, options => options.MapFrom(MappearVuelosCity));
        }

        private List<AerolineaDTO> MappearVuelosAerolinea(Vuelo vuelo, VueloDTO vueloDTO)
        {
            var result = new List<AerolineaDTO>();
                if(vuelo.vuelosAerolinea != null)
            {
                foreach(var aerolinea in vuelo.vuelosAerolinea)
                {
                    result.Add(new AerolineaDTO() {Id= aerolinea.AerolineaId, NombreAerolinea= aerolinea.aerolinea.NombreAerolinea });
                }
            }

            return result;

        }

        private List<CiudadDTO> MappearVuelosCity(Vuelo vuelo, VueloDTO vueloDTO)
        {
            var result = new List<CiudadDTO>();
            if (vuelo.vuelosCiudades != null)
            {
                foreach (var ciudad in vuelo.vuelosCiudades)
                {
                    result.Add(new CiudadDTO() { Id = ciudad.CiudadId, Ciudad= ciudad.ciudad.ciudad });
                }
            }

            return result;

        }

        private List<VuelosCiudades> MapearVuelosCiudades(VueloCreateDTO vueloCreateDTO,Vuelo vuelo)
        {
            var resultado = new List<VuelosCiudades>();

            if(vueloCreateDTO.CiudadesId== null)
            {
                return resultado;
            }
            foreach(var id in vueloCreateDTO.CiudadesId)
            {
                resultado.Add(new VuelosCiudades() { CiudadId=id});
            }

            return resultado;
        }


        private List<VuelosAerolinea> MapearVuelosAerolineas(VueloCreateDTO vueloCreateDTO, Vuelo vuelo)
        {
            var resultado = new List<VuelosAerolinea>();

            if (vueloCreateDTO.AerolinieasId == null)
            {
                return resultado;
            }
            foreach (var id in vueloCreateDTO.AerolinieasId)
            {
                resultado.Add(new VuelosAerolinea() { AerolineaId = id });
            }

            return resultado;
        }
    }
}
