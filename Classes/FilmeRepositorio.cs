using System;
using System.Collections.Generic;
using series.Interfaces;

namespace series
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        protected List<Filme> lista = new List<Filme>();
        private int quantidade = 0;


        public List<Filme> Lista()
        {
            return lista;
        }

        public Filme RetornaPorId(int id)
        {
            return lista[id];
        }

        public void Insere(Filme entidade)
        {
            lista.Add(entidade);
            quantidade += 1;
        }

        public void Exclui(int id)
        {
            lista[id].Excluir();
            quantidade -= 1;
        }

        public void Alterar(int id, Filme entidade)
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
    }
}