using NET_Warehouse.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NET_Warehouse.Models
{
    public class Producto
    {
        [Key]
        public int ProductoID { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Ingrese el nombre del producto")]
        public int NombreProd { get; set; }

        [DisplayName("Precio")]
        [Required(ErrorMessage = "Ingrese un precio")]
        [PrecioValido(ErrorMessage = "Ingrese un precio valido")]
        public decimal PrecioProd { get; set; }

        [DisplayName("Descripcion")]
        [Required(ErrorMessage = "Ingrese una descripción")]
        public string DescripcionProd { get; set; }

        [DisplayName("Bodega")]
        [Required(ErrorMessage = "Seleccione una bodega")]
        public int BodegaID { get; set; }

        public virtual Bodega Bodega { get; set; }
    }
}