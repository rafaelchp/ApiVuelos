using ApiVuelos.utilidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiVuelos.DTO
{
    public class VueloCreateDTO
    {

        public DateTime FechaVuelo { get; set; }
        [Required]
        public string HoraSalida { get; set; }
        [Required]
        public string HoraLlegada { get; set; }
        [Required]
        public string NumVuelo { get; set; }
        public string EstadoVuelo { get; set; }

        [ModelBinder(BinderType =typeof(TypeBinder<List<int>>))]
        public List<int> CiudadesId { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> AerolinieasId { get; set; }
    }
}
