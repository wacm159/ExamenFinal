﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamenFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CellphoneEntities : DbContext
    {
        public CellphoneEntities()
            : base("name=CellphoneEntities")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Ensamble> Ensamble { get; set; }
        public virtual DbSet<Gama> Gama { get; set; }
        public virtual DbSet<Telefono> Telefono { get; set; }
    }
}
