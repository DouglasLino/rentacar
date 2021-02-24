using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace renta_autos.Models
{
    public class Vehiculos
    {
        //Atributos / campos de clase y tabla
        [Key]
        public int Id_vehiculo { get; set; }

        [Required(ErrorMessage = "La placa es requerida")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "El año es requerido")]
        [Range(2000, 2022, ErrorMessage = "Ingrese año válido del vehículo")]
        public int Anio { get; set; }

        [Required(ErrorMessage = "El tipo de transmisión es requerido")]
        public string Transmision { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(1, 10, ErrorMessage = "Ingrese precio de la hora válido")]
        public double Precio_hora { get; set; }

        [Required(ErrorMessage ="imagen es requerida")]
        public string Foto { get; set; }

        [Required]
        public bool Estado { get; set; }

        //Llave foranea para la tabla de Alquiler
        [ForeignKey("Id_vehiculo")]
        public ICollection<Alquiler> Alquileres{ get; set; }

        //Llaves foraneas de las tablas catálogos
        public int Id_marca { get; set; }
        public int Id_modelo { get; set; }
        public int Id_tipo_vehiculo { get; set; }

        //Codificación para mostrar los nombres de las tablas catálogos en vez de los Id
        [NotMapped]
        public string Marca
        {
            get
            {
                using (var context = new Contexto())
                {
                    var Marca = context.Marcas.Where(x => x.Id_marca == Id_marca).Select(x => x.Marca).FirstOrDefault();
                    return Marca;
                }
            }
        }
        [NotMapped]
        public string Modelo
        {
            get
            {
                using (var context = new Contexto())
                {
                    var Modelo = context.Modelos.Where(x => x.Id_modelo == Id_modelo).Select(x => x.Modelo).FirstOrDefault();
                    return Modelo;
                }
            }
        }
        [NotMapped]
        public string Tipo_vehiculo
        {
            get
            {
                using (var context = new Contexto())
                {
                    var Tipo_vehiculo = context.TipoVehiculos.Where(x => x.Id_tipo_vehiculo == Id_tipo_vehiculo).Select(x => x.Tipo_vehiculo).FirstOrDefault();
                    return Tipo_vehiculo;
                }
            }
        }
    }
}