namespace series
{
    public class Filme : Base
    {

        public Filme(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
            this.Assistido = false;
        }

        public override string ToString()
        {
            string serie = "Título: " + this.Titulo + "\n";
            serie += "Gênero: " + this.Genero + "\n";
            serie += "Descrição: " + this.Descricao + "\n";
            serie += "Ano: " + this.Ano + "\n";

            if(this.Assistido)  serie += "Nota: " + this.Avaliacao;

            return serie;
        }

    }
}