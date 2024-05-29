using System;
using System.Collections.Generic;

namespace PruebadevADRES_api.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            RequerimientosMeds = new HashSet<RequerimientosMed>();
        }

        public long IdProveedor { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<RequerimientosMed> RequerimientosMeds { get; set; }
    }
}
