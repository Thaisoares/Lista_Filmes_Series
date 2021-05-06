namespace series
{
    public class Base
    {
        public int Id {get; protected set;}
        public int Ano {get; protected set;}
        public double Avaliacao {get; protected set;}
        public string Titulo {get; protected set;}
        public string Descricao {get; protected set;}
        public bool Assistido {get; protected set;}
        public bool Excluido {get; set;}
        public Genero Genero {get; set;}


        public string RetornaTitulo(){
            return this.Titulo;
        }
        public int RetornaId(){
            return this.Id;
        }

        public void Excluir(){
            this.Excluido = true;
        }

        public bool EstaExcluido(){
            return this.Excluido;
        }

        public void Avaliar(double nota){
            this.Avaliacao = nota;
            this.Assistido = true;
        }

        public double GetNota(){
            return this.Avaliacao;
        }
    }
}