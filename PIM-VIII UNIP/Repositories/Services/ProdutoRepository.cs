using PIM_VIII_UNIP.DbContextConfig;
using PIM_VIII_UNIP.Models;
using PIM_VIII_UNIP.Repositories.Contracts;

namespace PIM_VIII_UNIP.Repositories.Services
{
    public class ProdutoRepository : IRepository<Produto>
    {
        private readonly MarketPlaceContext _marketPlaceContext;
        public ProdutoRepository( MarketPlaceContext marketPlaceContext)
        {
            _marketPlaceContext = marketPlaceContext;
        }
        public Produto Adicionar(Produto produto)
        {
            _marketPlaceContext.Produtos.Add( produto );
            _marketPlaceContext.SaveChanges();
            return produto;
        }

        public void Atualizar(Produto produto)
        {
            _marketPlaceContext.Produtos.Update(produto);
            _marketPlaceContext.SaveChanges();
        }

        public void Excluir(Produto produto)
        {
            _marketPlaceContext.Produtos.Remove(produto);
            _marketPlaceContext.SaveChanges();
        }

        public List<Produto> obterLista(int id)
        {
            throw new NotImplementedException();
        }

        public Produto ObterPorId(int id)
        {
            return _marketPlaceContext.Produtos.FirstOrDefault(p => p.Id.Equals(id));
        }

        public List<Produto> ObterTodos()
        {
            return _marketPlaceContext.Produtos.ToList();
        }
    }
}
