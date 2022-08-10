using LojaZoraide.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace LojaZoraide.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ItemVendaModel>()               
           .HasKey(s => new { s.VendaModelId, s.ProdutoModelId });

            modelBuilder.Entity<VendaModel>()
            .HasOne(c => c.ClienteModel)
            .WithMany(i => i.VendasModel).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProdutoModel>()
            .HasOne(c => c.CategoriaModel)
            .WithMany(p => p.Produtos).OnDelete(DeleteBehavior.NoAction);


            base.OnModelCreating(modelBuilder);


        }


        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }

        public DbSet<CategoriaModel> Categorias { get; set; }

        public DbSet<ItemVendaModel> ItemVendas { get; set; }

        public DbSet<VendaModel> Vendas { get; set; }

       

    }
}