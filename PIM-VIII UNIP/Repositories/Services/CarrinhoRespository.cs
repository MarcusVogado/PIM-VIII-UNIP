﻿using PIM_VIII_UNIP.DbContextConfig;
using PIM_VIII_UNIP.Models;
using PIM_VIII_UNIP.Repositories.Contracts;

namespace PIM_VIII_UNIP.Repositories.Services
{
    public class CarrinhoRespository : IRepository<Carrinho>
    {
        private readonly MarketPlaceContext _marketPlaceContext;
        public CarrinhoRespository(MarketPlaceContext marketPlaceContext)
        {   
            _marketPlaceContext = marketPlaceContext;
        }
        public Carrinho Adicionar(Carrinho carrinho)
        {
            _marketPlaceContext.Carrinhos.Add(carrinho);
            _marketPlaceContext.SaveChanges();
            return carrinho;
        }

        public void Atualizar(Carrinho carrinho)
        {
            _marketPlaceContext.Carrinhos.Update(carrinho);
            _marketPlaceContext.SaveChanges();
        }

        public void Excluir(Carrinho carrinho)
        {
            _marketPlaceContext.Carrinhos.Remove(carrinho);
            _marketPlaceContext.SaveChanges();
            
        }

        public Carrinho ObterPorId(int id)
        {
            return _marketPlaceContext.Carrinhos.FirstOrDefault(c=> c.Id.Equals(id)) ;
        }

        public List<Carrinho> ObterTodos()
        {
            return _marketPlaceContext.Carrinhos.ToList();
        }
    }
}
