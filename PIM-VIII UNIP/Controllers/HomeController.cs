using Microsoft.AspNetCore.Mvc;
using PIM_VIII_UNIP.Models;
using PIM_VIII_UNIP.Repositories.Contracts;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace PIM_VIII_UNIP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Produto> _produtoDb;  
        private List<ItemCarrinho> _itemCarrinhoList;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, IRepository<Produto> produtoDb, IMemoryCache memoryCache)
        {
            _logger = logger;
            _produtoDb = produtoDb;
            _itemCarrinhoList = new List<ItemCarrinho>();            
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            var produtos = _produtoDb.ObterTodos();
            return View(produtos);
        }

        public ActionResult AdicionarProdutoAoCarrinho(Produto produto)        {
            
            List<ItemCarrinho> itensCarrinho = _memoryCache.TryGetValue("ItensCarrinho", out List<ItemCarrinho> cachedItens)
             ? cachedItens
             : new List<ItemCarrinho>();
            Produto produtoAdd = _produtoDb.ObterPorId(produto.Id);
            // Verifique se o produto já está no carrinho
            ItemCarrinho itemExistente = itensCarrinho.FirstOrDefault(item => item.ProdutoID == produto.Id);

            if (itemExistente != null)
            {
                // Se o produto já estiver no carrinho, atualize a quantidade e o valor total
                itemExistente.Quantidade++;
                itemExistente.ValorTotal = itemExistente.Quantidade * itemExistente.Produto.Preco; // Atualize com o valor do produto
            }
            else
            {
                // Caso contrário, crie um novo item e adicione à lista
                
                ItemCarrinho novoItem = new ItemCarrinho
                {
                    CarrinhoID = 0,
                    Quantidade = 1,
                    Produto = produtoAdd,
                    ProdutoID= produtoAdd.Id,
                    ValorTotal = produtoAdd.Preco
                };
                itensCarrinho.Add(novoItem);
            }            
            _memoryCache.Set("ItensCarrinho", itensCarrinho);
            TempData["ItensCarrinho"] = JsonConvert.SerializeObject(itensCarrinho);
            
            return RedirectToAction("Index");
        }

    }
}