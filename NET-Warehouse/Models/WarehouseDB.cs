using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NET_Warehouse.Models
{
    public class WarehouseDB :DbContext
    {

        public DbSet<Bodega> Bodegas { get; set; }

        public DbSet<Producto> Productos { get; set; }
    }
}