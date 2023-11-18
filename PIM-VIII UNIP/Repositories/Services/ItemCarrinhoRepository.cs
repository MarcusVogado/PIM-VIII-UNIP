using PIM_VIII_UNIP.DbContextConfig;
using PIM_VIII_UNIP.Models;
using PIM_VIII_UNIP.Repositories.Contracts;

namespace PIM_VIII_UNIP.Repositories.Services
{
    public class ItemCarrinhoRepository : IRepository<ItemCarrinho>
    {
        private readonly MarketPlaceContext _marketPlaceContext;
        public ItemCarrinhoRepository(MarketPlaceContext marketPlaceContext)
        {
            _marketPlaceContext = marketPlaceContext;
        }
        public ItemCarrinho Adicionar(ItemCarrinho itemCarrinho)
        {
            _marketPlaceContext.ItensCarrinho.Add(itemCarrinho);
            _marketPlaceContext.SaveChanges();
            return itemCarrinho;
        }

        public void Atualizar(ItemCarrinho itemCarrinho)
        {
            _marketPlaceContext.ItensCarrinho.Update(itemCarrinho);
            _marketPlaceContext.SaveChanges();
        }

        public void Excluir(ItemCarrinho itemCarrinho)
        {
            _marketPlaceContext.ItensCarrinho.Remove(itemCarrinho);
            _marketPlaceContext.SaveChanges();
        }

        public ItemCarrinho ObterPorId(int id)
        {
            return _marketPlaceContext.ItensCarrinho.FirstOrDefault(i => i.Id.Equals(id));
        }

        public List<ItemCarrinho> ObterTodos()
        {
            return _marketPlaceContext.ItensCarrinho.ToList();
        }
    }
}