using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace renta_autos.Models
{
    public class TipoVehiculos
    {
        [Key]
        public int Id_tipo_vehiculo { get; set; }

        [Required(ErrorMessage = "El tipo de vehículo es requerido")]
        public string Tipo_vehiculo { get; set; }

        //Llave foranea para la tabla de Vehiculos
        [ForeignKey("Id_tipo_vehiculo")]
        public ICollection<Vehiculos> Vehiculos { get; set; }
    }
}