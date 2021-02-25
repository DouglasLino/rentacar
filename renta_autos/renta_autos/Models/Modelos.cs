using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace renta_autos.Models
{
    public class Modelos
    {
        [Key]
        public int Id_modelo { get; set; }

        [Required(ErrorMessage = "El modelo es requerido")]
        public string Modelo { get; set; }

        //Llave foranea para la tabla de Vehiculos
        [ForeignKey("Id_modelo")]
        public ICollection<Vehiculos> Vehiculos { get; set; }

        
    }
}