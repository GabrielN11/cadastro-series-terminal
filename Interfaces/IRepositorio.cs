using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Listar();
        T RetornarPorId(int id);        
        void Inserir(T entidade);        
        string Excluir(int id);        
        void Atualizar(int id, T entidade);
        int ProximoId();
    }
}