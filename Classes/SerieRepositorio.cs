using System;
using System.Collections.Generic;
using series.Interfaces;

namespace series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        protected List<Serie> lista = new List<Serie>();
        private int quantidade = 0;


        public List<Serie> Lista()
        {
            return lista;
        }

        public Serie RetornaPorId(int id)
        {
            return lista[id];
        }

        public void Insere(Serie entidade)
        {
            lista.Add(entidade);
            quantidade += 1;
        }

        public void Exclui(int id)
        {
            lista[id].Excluir();
            quantidade -= 1;
        }

        public void Alterar(int id, Serie entidade)
        {
            lista[id] = entidade;
        }

        public void Avaliar(int id, double nota)
        {
            lista[id].Avaliar(nota);
        }

        public int ProximoId()
        {
            return lista.Count; 
        }

        public int Quantidade(){
            return quantidade;
        }
        public void Atualizar(int id, int epsodio, int temporada)
        {
            this.lista[id].Atualizar(epsodio, temporada);
        }
    }
}