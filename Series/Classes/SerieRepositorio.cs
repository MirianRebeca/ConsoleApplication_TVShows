//usada no programa principal

using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepoositorio<Serie> //  implementa a interface IRepositorio da classe Serie()
    { 
        private List<Serie> listaSerie = new List<Serie>();
        //implementação dos métodos da interface, já sustituindo o <T> por <Serie.cs>
        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }
        // para excluir foi criado um método em Serie.cs, assim o id excluido fica com Excluido = True
        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}