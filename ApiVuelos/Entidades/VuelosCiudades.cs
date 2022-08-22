namespace ApiVuelos.Entidades
{
    public class VuelosCiudades
    {
        public int VueloId { get; set; }
        public int CiudadId { get; set; }
        public Vuelo vuelo { get; set; }
        public Ciudad ciudad { get; set; }

    }
}
