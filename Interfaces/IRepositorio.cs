using System.Collections.Generic;

namespace series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Alterar(int id, T entidade);
        public void Avaliar(int id, double nota);
        int ProximoId();
    }
}