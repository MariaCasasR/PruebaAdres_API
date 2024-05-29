using System;
using System.Collections.Generic;

namespace PruebadevADRES_api.Models
{
    public partial class Unidad
    {
        public Unidad()
        {
            RequerimientosMeds = new HashSet<RequerimientosMed>();
        }

        public long IdUnidad { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<RequerimientosMed> RequerimientosMeds { get; set; }
    }
}
