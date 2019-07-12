using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NET_Warehouse.Models
{
    public class Bodega
    {
        [Key]
        public int BodegaID { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre de la bodega")]
        public string NombreBodega { get; set; }

        [Required(ErrorMessage = "Seleccione un pais!")]
        public string PaisBodega { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}