namespace PIM_VIII_UNIP.Repositories.Contracts
{
    public interface IRepository<T>
    {
        T Adicionar(T classe);
        void Atualizar(T classe);
        void Excluir(T classe);
        T ObterPorId(int id);
        List<T> ObterTodos();
        List<T> obterLista(int id);

    }
}
