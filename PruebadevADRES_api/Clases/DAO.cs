using PruebadevADRES_api.Models;

namespace PruebadevADRES_api.Clases
{
    public class DAO
    {
        public List<Unidad> GetUnidades()
        {
            try
            {
                using (GestionAdresContext cn = new GestionAdresContext())
                {
                    List<Unidad> data = cn.Unidads
                        .Select(p => new Unidad
                        {
                            IdUnidad = p.IdUnidad,
                            Nombre = p.Nombre
                        })
                        .ToList();

                    return data;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Proveedor> GetProveedors()
        {
            try
            {
                using (GestionAdresContext cn = new GestionAdresContext())
                {
                    List<Proveedor> data = cn.Proveedors
                        .Select(p => new Proveedor
                        {
                            IdProveedor = p.IdProveedor,
                            Nombre = p.Nombre
                        })
                        .ToList();

                    return data;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<RequerimientosMed> GetRequerimientosMed()
        {
            try
            {
                using (GestionAdresContext cn = new GestionAdresContext())
                {
                    List<RequerimientosMed> data = cn.RequerimientosMeds
                        .Select(p => new RequerimientosMed
                        {
                            Id = p.Id,
                            Presupuesto = p.Presupuesto,
                            IdUnidad = p.IdUnidad,
                            Tipo = p.Tipo,
                            Cantidad = p.Cantidad,
                            ValorUnitario = p.ValorUnitario,
                            ValorTotal = p.ValorTotal,
                            FechaAd = p.FechaAd,
                            IdProveedor = p.ValorUnitario,
                            Documentacion = p.Documentacion
                        })
                        .ToList();

                    return data;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //Post
        public int PostUnidades(Unidad data)
        {
            try
            {
                using (GestionAdresContext cn = new GestionAdresContext())
                {

                    var algo = new Unidad
                    {
                        IdUnidad = data.IdUnidad,
                        Nombre = data.Nombre,
                 
                    };

                    cn.Unidads.Add(algo);
                    cn.SaveChanges();
                }
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int PostProvedores(Proveedor data)
        {
            try
            {
                using (GestionAdresContext cn = new GestionAdresContext())
                {

                    var algo = new Proveedor
                    {
                        IdProveedor = data.IdProveedor,
                        Nombre = data.Nombre,

                    };

                    cn.Proveedors.Add(algo);
                    cn.SaveChanges();
                }
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int PostRequerimientosMed(RequerimientosMed data)
        {
            try
            {
                using (GestionAdresContext cn = new GestionAdresContext())
                {
                    DateTime now = DateTime.Now;
                    byte[] fechaBytes = BitConverter.GetBytes(now.Ticks);
                    var algo = new RequerimientosMed
                    {
                        Id = data.Id,
                        Presupuesto = data.Presupuesto,
                        IdUnidad = data.IdUnidad,
                        Tipo = data.Tipo,
                        Cantidad = data.Cantidad,
                        ValorUnitario = data.ValorUnitario,
                        ValorTotal = data.ValorTotal,
                        FechaAd = fechaBytes,
                        IdProveedor = data.IdProveedor,
                        Documentacion = data.Documentacion
                    };

                    cn.RequerimientosMeds.Add(algo);
                    cn.SaveChanges();
                }
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //edit
        public int EditUnidades(Unidad data)
        {
            try
            {
                using (GestionAdresContext cn = new GestionAdresContext())
                {
    
                    var unidad = cn.Unidads.Find(data.IdUnidad);

                    if (unidad != null)
                    {
                
                        unidad.Nombre = data.Nombre;

                    
                        cn.SaveChanges();

                        return 1; 
                    }
                    else
                    {
                        return 0; 
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int EditProveedor(Proveedor data)
        {
            try
            {
                using (GestionAdresContext cn = new GestionAdresContext())
                {

                    var Un = cn.Proveedors.Find(data.IdProveedor);

                    if (Un != null)
                    {

                        Un.Nombre = data.Nombre;


                        cn.SaveChanges();

                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int EditRequerimientosMed(RequerimientosMed data)
        {
            try
            {
                using (GestionAdresContext cn = new GestionAdresContext())
                {

                    var Un = cn.RequerimientosMeds.Find(data.Id);

                    if (Un != null)
                    {

                        Un.Presupuesto = data.Presupuesto;
                        Un.Cantidad = data.Cantidad;
                        Un.ValorUnitario = data.ValorUnitario;
                        Un.ValorTotal = data.ValorTotal;
                        Un.Documentacion = data.Documentacion;


                        cn.SaveChanges();

                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //delete 
        public int DltUnidad(Unidad data)
        {
            try
            {
                using (GestionAdresContext cn = new GestionAdresContext())
                {
                
                    var unidad = cn.Unidads.Find(data.IdUnidad);

                    if (unidad != null)
                    {
                   
                        cn.Unidads.Remove(unidad);

                     
                        cn.SaveChanges();

                        return 1; 
                    }
                    else
                    {
                        return 0; 
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int DltProveedor(Proveedor data)
        {
            try
            {
                using (GestionAdresContext cn = new GestionAdresContext())
                {

                    var ss = cn.Proveedors.Find(data.IdProveedor);

                    if (ss != null)
                    {

                        cn.Proveedors.Remove(ss);


                        cn.SaveChanges();

                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int DltRequerimiento(RequerimientosMed data)
        {
            try
            {
                using (GestionAdresContext cn = new GestionAdresContext())
                {

                    var ss = cn.RequerimientosMeds.Find(data.Id);

                    if (ss != null)
                    {

                        cn.RequerimientosMeds.Remove(ss);


                        cn.SaveChanges();

                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
