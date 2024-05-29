using System;
using System.Collections.Generic;

namespace PruebadevADRES_api.Models
{
    public partial class RequerimientosMed
    {
        public long Id { get; set; }
        public long? Presupuesto { get; set; }
        public long? IdUnidad { get; set; }
        public string? Tipo { get; set; }
        public long? Cantidad { get; set; }
        public long? ValorUnitario { get; set; }
        public long? ValorTotal { get; set; }
        public byte[]? FechaAd { get; set; }
        public long? IdProveedor { get; set; }
        public string? Documentacion { get; set; }

        public virtual Proveedor? IdProveedorNavigation { get; set; }
        public virtual Unidad? IdUnidadNavigation { get; set; }
    }
}
