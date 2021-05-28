// design patterns repository 
//posui os metodos que são implementados em SerieRepositório
using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepoositorio<T>
    {
         List<T> Lista();
         T RetornaPorId(int id);
         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza(int id, T entidade);
         int ProximoId();
    }
}