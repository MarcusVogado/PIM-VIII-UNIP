using PIM_VIII_UNIP.DbContextConfig;
using PIM_VIII_UNIP.Models;
using PIM_VIII_UNIP.Repositories.Contracts;

namespace PIM_VIII_UNIP.Repositories.Services
{
    public class EnderecoRepository : IRepository<Endereco>
    {
        private readonly MarketPlaceContext _marketPlaceContext;
        public EnderecoRepository(MarketPlaceContext marketPlaceContext)
        {
            _marketPlaceContext = marketPlaceContext;
        }
        public Endereco Adicionar(Endereco endereco)
        {
            _marketPlaceContext.Enderecos.Add(endereco);
            _marketPlaceContext.SaveChanges();
            return endereco;
        }

        public void Atualizar(Endereco endereco)
        {
            _marketPlaceContext.Enderecos.Update(endereco);
            _marketPlaceContext.SaveChanges();
        }

        public void Excluir(Endereco endereco)
        {
            _marketPlaceContext.Enderecos.Remove(endereco);
            _marketPlaceContext.SaveChanges();
        }

        public Endereco ObterPorId(int id)
        {
            return _marketPlaceContext.Enderecos.FirstOrDefault(e => e.Id.Equals(id));
        }

        public List<Endereco> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
