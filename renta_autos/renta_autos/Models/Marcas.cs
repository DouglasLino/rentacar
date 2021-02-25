using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace renta_autos.Models
{
    public class Marcas
    {
        [Key]
        public int Id_marca { get; set; }

        [Required(ErrorMessage = "La marca es requerida")]
        public string Marca { get; set; }

        //Llave foranea para la tabla de Vehiculos
        [ForeignKey("Id_marca")]
        public ICollection<Vehiculos> Vehiculos { get; set; }
    }
}