using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PIM_VIII_UNIP.Models;
using PIM_VIII_UNIP.Models.Enums;
using PIM_VIII_UNIP.Models.ViewModels;
using PIM_VIII_UNIP.Repositories.Contracts;


namespace PIM_VIII_UNIP.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly IRepository<Produto> _produtoRepository;
        private readonly IRepository<Carrinho> _carrinhoRepository;
        private readonly IRepository<ItemCarrinho> _itemRepository;
        public CarrinhoController(IRepository<Produto> produtoRepository, IRepository<Carrinho> carrinhoRepository,IRepository<ItemCarrinho> itemRepository)
        {
            _produtoRepository = produtoRepository;
            _carrinhoRepository = carrinhoRepository;
            _itemRepository = itemRepository;
        }
        public ActionResult CarrinhoIndex()
        {

            string jsonItensCarrinho = TempData["ItensCarrinho"] as string;
            if (jsonItensCarrinho == null) return View();
            List<ItemCarrinho> itensCarrinho = JsonConvert.DeserializeObject<List<ItemCarrinho>>(jsonItensCarrinho) ?? 
                new List<ItemCarrinho>();
            double valorTotal = itensCarrinho.Sum(produto => produto.ValorTotal);
            List<Produto> produtos = new List<Produto>();
            foreach(var  item in itensCarrinho)
            {
                var produtoAdd = _produtoRepository.ObterPorId(item.Id);
                produtos.Add(produtoAdd);
            }
            CarrinhoView carrinhoView = new CarrinhoView()
            {
                Produtos = produtos,
                ValorTotal = valorTotal,
                ItensCarrinho = itensCarrinho
            };
            TempData["CarrinhoTemp"] = JsonConvert.SerializeObject(carrinhoView);
            return View(carrinhoView);
        }
        
        public ActionResult CriarPedido()
        {
            string jsonCarrinhoView = TempData["CarrinhoTemp"] as string;
            var carrinhoView = JsonConvert.DeserializeObject<CarrinhoView>(jsonCarrinhoView);
            try
            {   
                var carrinho = new Carrinho()
                {
                    ClienteID = 1,
                    DataPedido = DateTime.UtcNow,
                    ValorTotal = carrinhoView.ValorTotal,
                    Status = PedidoStatus.PedidoConfirmado,
                    ProdutosCarrinho = carrinhoView.ItensCarrinho
                };
               var carrinhoCreate = _carrinhoRepository.Adicionar(carrinho);

                foreach ( var item in carrinhoView.ItensCarrinho)
                {
                    var itemCarrinho = new ItemCarrinho()
                    {
                        Quantidade = item.Quantidade,
                        ValorTotal = item.ValorTotal,
                        CarrinhoID = carrinhoCreate.Id,                        
                        ProdutoID = item.ProdutoID
                    };
                    _itemRepository.Adicionar(itemCarrinho);
                }

                TempData["Alerta"] = "Pedido Criado com Sucesso";
                return RedirectToAction("Index","Home");
            }
            catch(Exception ex)
            {
                TempData["Alerta"] = $"Erro Ao finalizar Carrinho.{ex.Message}";
                return View("CarrinhoIndex");
            }           
        }
               
    }
}