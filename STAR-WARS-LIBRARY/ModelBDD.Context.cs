﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace STAR_WARS_LIBRARY
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDDEntities : DbContext
    {
        public BDDEntities()
            : base("name=BDDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Droide> Droide { get; set; }
        public virtual DbSet<Planete> Planete { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<Wookie> Wookie { get; set; }
    }
}
