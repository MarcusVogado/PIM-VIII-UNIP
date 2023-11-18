using PIM_VIII_UNIP.DbContextConfig;
using PIM_VIII_UNIP.Models;
using PIM_VIII_UNIP.Repositories.Contracts;

namespace PIM_VIII_UNIP.Repositories.Services
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly MarketPlaceContext _marketPlaceContext;
        public ClienteRepository(MarketPlaceContext marketPlaceContext )
        {
            _marketPlaceContext = marketPlaceContext;
        }
        public Cliente Adicionar(Cliente cliente)
        {
            _marketPlaceContext.Clientes.Add(cliente);
            _marketPlaceContext.SaveChanges();
            return cliente;
        }

        public void Atualizar(Cliente cliente)
        {
            _marketPlaceContext.Clientes.Update(cliente);
            _marketPlaceContext.SaveChanges();
        }

        public void Excluir(Cliente cliente)
        {
            _marketPlaceContext.Clientes.Remove(cliente);
            _marketPlaceContext.SaveChanges();
        }

        public Cliente ObterPorId(int id)
        {
            return _marketPlaceContext.Clientes.FirstOrDefault(c => c.Id.Equals(id));
        }

        public List<Cliente> ObterTodos()
        {
           return _marketPlaceContext.Clientes.ToList();
        }
    }
}
