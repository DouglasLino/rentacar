﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace renta_autos.Models
{
    public class Alquiler
    {
        //Atributos / campos de clase y tabla
        [Key]
        public int Id_alquiler { get; set; }

        [Required(ErrorMessage = "El cliente es requerido")]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "El telefono del cliente es requerido")]
              
        [MaxLength(9)]
        [MinLength(9)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El DUI es requerido")]
        [MaxLength(10)]
        [MinLength(10)]
        public string Dui { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        public DateTime Fecha_inicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es requerida")]
        public DateTime Fecha_fin { get; set; }

        [Required]
        public double Total { get; set; }

        //Llaves foraneas de la tabla vehiculo
        public int Id_vehiculo { get; set; }

        //Codificación para mostrar atributos por medio de los Id
        //Esto lo haré según decidamos los detalles que mostraremos en las vistas 
    }
}