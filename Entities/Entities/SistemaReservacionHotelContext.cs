using System;
using System.Collections.Generic;
using DAL.Authentication;
using Entities.Utilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities
{
    public partial class SistemaReservacionHotelContext : IdentityDbContext<ApplicationUser>
    {
        public SistemaReservacionHotelContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SistemaReservacionHotelContext>();
            optionsBuilder.UseSqlServer(Util.ConnectionString);
        }

        public SistemaReservacionHotelContext(DbContextOptions<SistemaReservacionHotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Habitacion> Habitacions { get; set; } = null!;
        public virtual DbSet<Reservacione> Reservaciones { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;
        public virtual DbSet<TipoHabitacion> TipoHabitacions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Util.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Habitacion>(entity =>
            {
                entity.HasKey(e => e.Idhabitacion)
                    .HasName("PK__HABITACI__6B4757DA9CF2F21A");

                entity.ToTable("HABITACION");

                entity.Property(e => e.Idhabitacion).HasColumnName("IDHabitacion");

                entity.Property(e => e.IdtipoHabitacion).HasColumnName("IDTipoHabitacion");

                entity.Property(e => e.PisoHabitacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdtipoHabitacionNavigation)
                    .WithMany(p => p.Habitacions)
                    .HasForeignKey(d => d.IdtipoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HABITACIO__IDTip__38996AB5");
            });

            modelBuilder.Entity<Reservacione>(entity =>
            {
                entity.HasKey(e => e.Idreservacion)
                    .HasName("PK__RESERVAC__E970411BE0437683");

                entity.ToTable("RESERVACIONES");

                entity.Property(e => e.Idreservacion).HasColumnName("IDReservacion");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.Idhabitacion).HasColumnName("IDHabitacion");

                entity.Property(e => e.Idservicio).HasColumnName("IDServicio");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdhabitacionNavigation)
                    .WithMany(p => p.Reservaciones)
                    .HasForeignKey(d => d.Idhabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RESERVACI__IDHab__403A8C7D");

                entity.HasOne(d => d.IdservicioNavigation)
                    .WithMany(p => p.Reservaciones)
                    .HasForeignKey(d => d.Idservicio)
                    .HasConstraintName("FK__RESERVACI__IDSer__5CD6CB2B");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Reservaciones)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK__RESERVACI__IDUsu__412EB0B6");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Idrol)
                    .HasName("PK__ROL__A681ACB6B6AA7A5F");

                entity.ToTable("ROL");

                entity.Property(e => e.Idrol).HasColumnName("IDRol");

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.Idservicio)
                    .HasName("PK__SERVICIO__3CCE7416CDCCF2AB");

                entity.ToTable("SERVICIO");

                entity.Property(e => e.Idservicio).HasColumnName("IDServicio");

                entity.Property(e => e.NombreServicio)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoHabitacion>(entity =>
            {
                entity.HasKey(e => e.IdtipoHabitacion)
                    .HasName("PK__TIPO_HAB__1229175B93E4319C");

                entity.ToTable("TIPO_HABITACION");

                entity.Property(e => e.IdtipoHabitacion).HasColumnName("IDTipoHabitacion");

                entity.Property(e => e.NombreTipoHabitacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__USUARIO__523111698710A7B1");

                entity.ToTable("USUARIO");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Idrol).HasColumnName("IDRol");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idrol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__IDRol__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
