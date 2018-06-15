using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repository.Models
{
    public partial class postgresContext : DbContext
    {
        public virtual DbSet<CarrinhoCompras> CarrinhoCompras { get; set; }
        public virtual DbSet<Comentarios> Comentarios { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"Host=localhost;Database=postgres;Username=postgres;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarrinhoCompras>(entity =>
            {
                entity.HasKey(e => new { e.IdCarrinhoCompras });

                entity.ToTable("carrinho_compras");

                entity.HasIndex(e => e.IdProduto)
                    .HasName("idx_carrinho_compras_id_produto");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("idx_carrinho_compras_id_usuario");

                entity.Property(e => e.IdCarrinhoCompras)
                  .HasColumnName("id_carrinho_compras")
                  .ValueGeneratedOnAdd();

                entity.Property(e => e.IdProduto)
                    .HasColumnName("id_produto")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Finalizado)
                    .HasColumnName("finalizado")
                    .HasDefaultValueSql("false");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.CarrinhoCompras)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_carrinho_produtos");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.CarrinhoCompras)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_carrinho_usuario");
            });

            modelBuilder.Entity<Comentarios>(entity =>
            {
                entity.HasKey(e => e.IdComentario);

                entity.ToTable("comentarios");

                entity.HasIndex(e => e.IdProduto)
                    .HasName("idx_comentarios_id_produto");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("idx_comentarios_id_usuario");

                entity.Property(e => e.IdComentario).HasColumnName("id_comentario");

                entity.Property(e => e.Comentario).HasColumnName("comentario");

                entity.Property(e => e.Titulo).HasColumnName("titulo");

                entity.Property(e => e.IdProduto)
                    .HasColumnName("id_produto")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comentarios_produtos");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comentarios_usuarios");
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.HasKey(e => e.IdProduto);

                entity.ToTable("produtos");

                entity.Property(e => e.IdProduto).HasColumnName("id_produto");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao");

                entity.Property(e => e.Foto).HasColumnName("foto");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("marca");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome");

                entity.Property(e => e.Preco).HasColumnName("preco");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.ToTable("tipo_usuario");

                entity.Property(e => e.IdTipoUsuario)
                    .HasColumnName("id_tipo_usuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.IdTipoUsuario)
                    .HasName("idx_usuarios_id_tipo_usuario");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_tipo_usuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome");
                entity.Property(e => e.Senha)
                   .IsRequired()
                   .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuarios_tipo_usuario");
            });
        }
    }
}
