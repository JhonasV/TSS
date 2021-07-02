using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TSS.Models
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RegistroEmpleadoTss> RegistroEmpleadoTsses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<RegistroEmpleadoTss>(entity =>
            {
                entity.ToTable("Registro_Empleado_TSS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActividadComercial)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("actividad_comercial");

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("calle");

                entity.Property(e => e.CedulaEmpleado)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cedula_empleado");

                entity.Property(e => e.EmailEmpresa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email_empresa");

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("municipio");

                entity.Property(e => e.No)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("no");

                entity.Property(e => e.NombreComercial)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre_comercial");

                entity.Property(e => e.NombreEmpleado)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_empleado");

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("provincia");

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("razon_social");

                entity.Property(e => e.ReferenciaDireccion)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("referencia_direccion");

                entity.Property(e => e.Rnc)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("rnc");

                entity.Property(e => e.Sector)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("sector");

                entity.Property(e => e.TelefonoEmpresa)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("telefono_empresa");

                entity.Property(e => e.TipoEmpleador)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tipo_empleador");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
