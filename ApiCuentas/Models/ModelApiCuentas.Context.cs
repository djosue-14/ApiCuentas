﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiCuentas.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ApiCuentasEntities : DbContext
    {
        public ApiCuentasEntities()
            : base("name=ApiCuentasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<DetalleVentas> DetalleVentas { get; set; }
        public virtual DbSet<Financiamiento> Financiamiento { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<TipoVenta> TipoVenta { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
    }
}
