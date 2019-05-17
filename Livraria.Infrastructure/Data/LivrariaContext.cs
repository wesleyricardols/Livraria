using Microsoft.EntityFrameworkCore;

namespace Livraria.ApplicationCore.Entity
{
    public partial class LivrariaContext : DbContext
    {
        #region Constructors

        public LivrariaContext()
        {
        }

        public LivrariaContext(DbContextOptions<LivrariaContext> options)
            : base(options)
        {
        }
        
        #endregion

        public virtual DbSet<Exemplares> Exemplares { get; set; }
        public virtual DbSet<Livros> Livros { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-EQS1K3F;Database=livraria;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Exemplares>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PkExemplares");

                entity.HasOne(d => d.Livro)
                    .WithMany(p => p.Exemplares)
                    .HasForeignKey(d => d.LivroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkExemplaresLivrosLivroId");
            });

            modelBuilder.Entity<Livros>(entity =>
            {
                entity.HasKey(e => e.LivroId)
                    .HasName("PkLivros");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Editora)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
