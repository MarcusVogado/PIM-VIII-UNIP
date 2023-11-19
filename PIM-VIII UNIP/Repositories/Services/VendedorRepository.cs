using PIM_VIII_UNIP.DbContextConfig;
using PIM_VIII_UNIP.Models;
using PIM_VIII_UNIP.Repositories.Contracts;

namespace PIM_VIII_UNIP.Repositories.Services
{
    public class VendedorRepository : IRepository<Vendedor>
    {
        private readonly MarketPlaceContext _marketPlaceContext;
        public VendedorRepository(MarketPlaceContext marketPlaceContext)
        {
            _marketPlaceContext = marketPlaceContext;
        }

        public Vendedor Adicionar(Vendedor vendedor)
        {
            _marketPlaceContext.Vendedores.Add(vendedor);
            _marketPlaceContext.SaveChanges();

            return vendedor;
        }

        public void Atualizar(Vendedor vendedor)
        {
            _marketPlaceContext.Vendedores.Update(vendedor);
            _marketPlaceContext.SaveChanges();
        }

        public void Excluir(Vendedor vendedor)
        {
            _marketPlaceContext.Vendedores.Remove(vendedor);
            _marketPlaceContext.SaveChanges();
        }

        public List<Vendedor> obterLista(int id)
        {
            throw new NotImplementedException();
        }

        public Vendedor ObterPorId(int id)
        {
            return _marketPlaceContext.Vendedores.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<Vendedor> ObterTodos()
        {
            return _marketPlaceContext.Vendedores.ToList();
        }
    }
}
