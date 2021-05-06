namespace series
{
    public class Serie : Base
    {
        private int TemporadaAtual {get; set;}
        private int EpisodioAtual {get; set;}

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
            this.Assistido = false;
            this.TemporadaAtual = 0;
            this.EpisodioAtual = 0;
        }

        public override string ToString()
        {
            string serie = "Título: " + this.Titulo + "\n";
            serie += "Gênero: " + this.Genero + "\n";
            serie += "Descrição: " + this.Descricao + "\n";
            serie += "Ano: " + this.Ano + "\n";

            if(this.Assistido)  serie += "Nota: " + this.Avaliacao;
            else                serie += this.GetEpisodioAtual();

            return serie;
        }

        public void Atualizar(int episodio, int temporada){
            this.TemporadaAtual = temporada;
            this.EpisodioAtual = episodio;
        }

        public string GetEpisodioAtual(){
            return this.TemporadaAtual + "ª temporada - episódio " + this.EpisodioAtual;
        }
    }
}