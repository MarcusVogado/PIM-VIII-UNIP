using Microsoft.EntityFrameworkCore;
using PIM_VIII_UNIP.Models;

namespace PIM_VIII_UNIP.DbContextConfig
{
    public class MarketPlaceContext : DbContext
    {
        public MarketPlaceContext(DbContextOptions<MarketPlaceContext> options) : base(options)
        {
        }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente>Clientes { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<ItemCarrinho> ItensCarrinho{ get; set; }
    }
}
