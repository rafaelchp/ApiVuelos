namespace ApiVuelos.Entidades
{
    public class VuelosAerolinea
    {
        public int VueloId { get; set; }
        public int AerolineaId { get; set; }

        public Vuelo vuelo { get; set; }
        public Aerolinea aerolinea { get; set; }
    }
}
