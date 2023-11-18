using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VideojuegosCRUD.Models;

public partial class VideojuegosContext : DbContext
{
    public VideojuegosContext()
    {
    }

    public VideojuegosContext(DbContextOptions<VideojuegosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clasificacion> Clasificacions { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<Desarrollador> Desarrolladors { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Plataforma> Plataformas { get; set; }

    public virtual DbSet<Tienda> Tiendas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    public virtual DbSet<Videojuego> Videojuegos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
/*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-6PGHB34; database=Videojuegos; Encrypt=false; integrated security=true;");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clasificacion>(entity =>
        {
            entity.HasKey(e => e.IdClasificacion).HasName("PK__clasific__257A4E1B63E14B6D");

            entity.ToTable("clasificacion");

            entity.Property(e => e.IdClasificacion).HasColumnName("id_clasificacion");
            entity.Property(e => e.Clasificacion1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clasificacion");
            entity.Property(e => e.TipoClasificacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo_clasificacion");
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.IdContrato).HasName("PK__contrato__FF5F2A56851A660E");

            entity.ToTable("contrato");

            entity.Property(e => e.IdContrato).HasColumnName("id_contrato");
            entity.Property(e => e.DescripcionContrato)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion_contrato");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaLimite)
                .HasColumnType("date")
                .HasColumnName("fecha_limite");
            entity.Property(e => e.IdDesarrollador).HasColumnName("id_desarrollador");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

            entity.HasOne(d => d.IdDesarrolladorNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdDesarrollador)
                .HasConstraintName("FK__contrato__id_des__3B75D760");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK__contrato__id_emp__3C69FB99");
        });

        modelBuilder.Entity<Desarrollador>(entity =>
        {
            entity.HasKey(e => e.IdDesarrollador).HasName("PK__desarrol__A5983F207C77793E");

            entity.ToTable("desarrollador");

            entity.Property(e => e.IdDesarrollador).HasColumnName("id_desarrollador");
            entity.Property(e => e.Fundacion)
                .HasColumnType("date")
                .HasColumnName("fundacion");
            entity.Property(e => e.NombreDesarrollador)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_desarrollador");
            entity.Property(e => e.PaisOrigen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pais_origen");
            entity.Property(e => e.SitioWeb)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sitio_web");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__empresa__4A0B7E2C4AE96E80");

            entity.ToTable("empresa");

            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.Fundacion)
                .HasColumnType("date")
                .HasColumnName("fundacion");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_empresa");
            entity.Property(e => e.PaisOrigen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pais_origen");
            entity.Property(e => e.SitioWeb)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sitio_web");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__genero__99A8E4F9209EC1F3");

            entity.ToTable("genero");

            entity.Property(e => e.IdGenero).HasColumnName("id_genero");
            entity.Property(e => e.IdClasificacion).HasColumnName("id_clasificacion");
            entity.Property(e => e.IdVideojuego).HasColumnName("id_videojuego");
            entity.Property(e => e.NombreGenero)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_genero");

            entity.HasOne(d => d.IdClasificacionNavigation).WithMany(p => p.Generos)
                .HasForeignKey(d => d.IdClasificacion)
                .HasConstraintName("FK__genero__id_clasi__4AB81AF0");

            entity.HasOne(d => d.IdVideojuegoNavigation).WithMany(p => p.Generos)
                .HasForeignKey(d => d.IdVideojuego)
                .HasConstraintName("FK__genero__id_video__49C3F6B7");
        });

        modelBuilder.Entity<Plataforma>(entity =>
        {
            entity.HasKey(e => e.IdPlataforma).HasName("PK__platafor__4312CAA2CC97F944");

            entity.ToTable("plataformas");

            entity.Property(e => e.IdPlataforma).HasColumnName("id_plataforma");
            entity.Property(e => e.Fabricante)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fabricante");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.IdVideojuego).HasColumnName("id_videojuego");
            entity.Property(e => e.NombrePlataforma)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_plataforma");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Plataformas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__plataform__id_us__44FF419A");

            entity.HasOne(d => d.IdVideojuegoNavigation).WithMany(p => p.Plataformas)
                .HasForeignKey(d => d.IdVideojuego)
                .HasConstraintName("FK__plataform__id_vi__440B1D61");
        });

        modelBuilder.Entity<Tienda>(entity =>
        {
            entity.HasKey(e => e.IdTienda).HasName("PK__tiendas__7C49D736BED8A037");

            entity.ToTable("tiendas");

            entity.Property(e => e.IdTienda).HasColumnName("id_tienda");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.IdVideojuego).HasColumnName("id_videojuego");
            entity.Property(e => e.NombreTienda)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_tienda");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.Tienda)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__tiendas__id_vent__5070F446");

            entity.HasOne(d => d.IdVideojuegoNavigation).WithMany(p => p.Tienda)
                .HasForeignKey(d => d.IdVideojuego)
                .HasConstraintName("FK__tiendas__id_vide__4F7CD00D");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__4E3E04AD59701058");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__ventas__459533BF0D87E112");

            entity.ToTable("ventas");

            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.FechaVenta)
                .HasColumnType("date")
                .HasColumnName("fecha_venta");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Videojuego>(entity =>
        {
            entity.HasKey(e => e.IdVideojuego).HasName("PK__videojue__49AD054B15C85B0E");

            entity.ToTable("videojuegos");

            entity.Property(e => e.IdVideojuego).HasColumnName("id_videojuego");
            entity.Property(e => e.IdDesarrollador).HasColumnName("id_desarrollador");
            entity.Property(e => e.Lanzamiento)
                .HasColumnType("date")
                .HasColumnName("lanzamiento");
            entity.Property(e => e.TituloVideojuego)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo_videojuego");

            entity.HasOne(d => d.IdDesarrolladorNavigation).WithMany(p => p.Videojuegos)
                .HasForeignKey(d => d.IdDesarrollador)
                .HasConstraintName("FK__videojueg__id_de__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
