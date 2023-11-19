using Microsoft.AspNetCore.Mvc;
using PIM_VIII_UNIP.Models;
using PIM_VIII_UNIP.Repositories.Contracts;
using PIM_VIII_UNIP.Repositories.Services;

namespace PIM_VIII_UNIP.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IRepository<Carrinho> _carrinhoRepository;
        private readonly IRepository<ItemCarrinho> _itemCarrinhoRepository;
        private readonly IRepository<Produto> _produtoRepository;

        public PedidoController(IRepository<Carrinho> carrinhoRepository, IRepository<ItemCarrinho> itemCarrinhoRepository, IRepository<Produto> produtoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
            _itemCarrinhoRepository = itemCarrinhoRepository;
            _produtoRepository = produtoRepository;
        }

        public IActionResult PedidoIndex()
        {
            var userID = 1;

            var carrinhos = _carrinhoRepository.obterLista(userID);
            
            foreach (var carrinho in carrinhos)
            {
                if (carrinho.ProdutosCarrinho == null)
                {
                    carrinho.ProdutosCarrinho = new List<ItemCarrinho>();
                }
                var itens = _itemCarrinhoRepository.obterLista(carrinho.Id);

                foreach (var item in itens)
                {
                    var protuto = _produtoRepository.ObterPorId(item.ProdutoID.GetValueOrDefault()) ;
                    item.Produto = protuto;
                    carrinho.ProdutosCarrinho.Add(item);
                }
            }
            return View(carrinhos);

        }

    }
}
