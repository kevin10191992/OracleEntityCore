using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VariablesOtorgamiento> VariablesOtorgamientos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=SRFBPMPQA;Password=SRFBPMPQA;Data Source=192.168.31.94:1521/xe;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SRFBPMPQA");

            modelBuilder.Entity<VariablesOtorgamiento>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VARIABLES_OTORGAMIENTO");

                entity.Property(e => e.Fecha)
                    .HasPrecision(6)
                    .HasColumnName("FECHA");

                entity.Property(e => e.Llave)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LLAVE");

                entity.Property(e => e.NroEjecucion)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NRO_EJECUCION");

                entity.Property(e => e.SqParticipante)
                    .HasColumnType("NUMBER(22)")
                    .HasColumnName("SQ_PARTICIPANTE");

                entity.Property(e => e.SqSolicitud)
                    .HasColumnType("NUMBER(22)")
                    .HasColumnName("SQ_SOLICITUD");

                entity.Property(e => e.Valor)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VALOR");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
