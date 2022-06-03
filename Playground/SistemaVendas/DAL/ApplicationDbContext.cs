using Microsoft.EntityFrameworkCore;
using SistemaVendas.Entidades;

namespace SistemaVendas.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaProdutos> VendaProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VendaProdutos>()
                .HasKey(x => new { x.CodigoVenda, x.CodigoProduto });

            modelBuilder.Entity<VendaProdutos>()
                .HasOne(x => x.Venda)
                .WithMany(x=> x.Produtos)
                .HasForeignKey(x => x.CodigoVenda);

            modelBuilder.Entity<VendaProdutos>()
                .HasOne(x => x.Produto)
                .WithMany(x => x.Vendas)
                .HasForeignKey(x => x.CodigoProduto);
        }
    }
}
