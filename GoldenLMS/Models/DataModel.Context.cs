﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoldenLMS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GoldenLMSEntities : DbContext
    {
        public GoldenLMSEntities()
            : base("name=GoldenLMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<LeadTbl> LeadTbls { get; set; }
        public DbSet<NoteTbl> NoteTbls { get; set; }
        public DbSet<UserTbl> UserTbls { get; set; }
    }
}
