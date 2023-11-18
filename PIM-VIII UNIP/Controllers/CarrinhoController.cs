using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PIM_VIII_UNIP.Models;
using PIM_VIII_UNIP.Models.ViewModels;
using PIM_VIII_UNIP.Repositories.Contracts;
using PIM_VIII_UNIP.Repositories.Services;

namespace PIM_VIII_UNIP.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly IRepository<Produto> _produtoRepository;

        public CarrinhoController(IRepository<Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public ActionResult CarrinhoIndex()
        {

            string jsonItensCarrinho = TempData["ItensCarrinho"] as string;
            if (jsonItensCarrinho == null) return View();
            List<ItemCarrinho> itensCarrinho = JsonConvert.DeserializeObject<List<ItemCarrinho>>(jsonItensCarrinho) ?? new List<ItemCarrinho>();
            double valorTotal = itensCarrinho.Sum(produto => produto.ValorTotal);
            List<Produto> produtos = new List<Produto>();
            foreach(var  item in itensCarrinho)
            {
                var produtoAdd = _produtoRepository.ObterPorId(item.Id);
                produtos.Add(produtoAdd);
            }
            CarrinhoViewDTO carrinhoView = new CarrinhoViewDTO()
            {
                Produtos = produtos,
                ValorTotal = valorTotal,
                ItensCarrinho = itensCarrinho
            };

            return View(carrinhoView);
        }
    }
}