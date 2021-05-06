using System;

namespace series
{
    class Program
    {
        static SerieRepositorio serie_repositorio = new SerieRepositorio();
        static FilmeRepositorio filme_repositorio = new FilmeRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario != "X"){
                switch(opcaoUsuario){
                    case "1":
                        ListarProgramas();
                        break;
                    case "2":
                        InserirPrograma();
                        break;
                    case "3":
                        AlterarPrograma();
                        break;
                    case "4":
                        AtualizarSerie();
                        break;
                    case "5":
                        AvaliarPrograma();
                        break;
                    case "6":
                        ExcluirPrograma();
                        break;
                    case "7":
                        VizualizarPrograma();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Entrada inválida. Tente novamente.");
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        //lista os programas existentes
        static void ListarProgramas(){
            //lista as series
            var lista = serie_repositorio.Lista();

            if(serie_repositorio.Quantidade() == 0){
                Console.WriteLine("Nenhuma série encontrada.");
            }
            else{
                Console.WriteLine("Séries presentes:");
                foreach(var serie in lista){
                    if(serie.EstaExcluido())  continue;
                    
                    Console.WriteLine("ID: S{0} | Título: {1}  | {2}", serie.RetornaId(), serie.RetornaTitulo(), (serie.Assistido ? "Nota: "+serie.GetNota() : serie.GetEpisodioAtual()));
                }
            }
            //lista os filmes
            var lista_f = filme_repositorio.Lista();

            if(filme_repositorio.Quantidade() == 0){
                Console.WriteLine("Nenhum filme encontrado.");
            }
            else{
                Console.WriteLine("Filmes presentes:");
                foreach(var filme in lista_f){
                    if(filme.EstaExcluido())  continue;
                    
                    Console.WriteLine("ID: F{0} | Título: {1}  {2}", filme.RetornaId(), filme.RetornaTitulo(), (filme.Assistido ? " |  Nota: "+filme.GetNota() : ""));
                }
            }
        }

        static void InserirPrograma(){
            string tipo_programa = "";
            do{
                Console.WriteLine("É uma série ou filme?  Digite S para série e F para filme.");
                tipo_programa = Console.ReadLine().ToUpper();
                Console.WriteLine();
            }while((tipo_programa != "S") && (tipo_programa != "F"));

            //coleta as informaçoes sobre o programa
            Console.WriteLine("Digite o título:");
            string titulo = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite uma descrição:");
            string descricao = Console.ReadLine();
            Console.WriteLine();

            int genero = ReadGenero();

            //le o ano e valida se é um inteiro
            int ano = 0;
            bool valido = false;
            while(!valido){
                Console.WriteLine("Digite o ano de lançamento:");
                valido = int.TryParse(Console.ReadLine(), out ano);
                Console.WriteLine();

                if(!valido)     Console.WriteLine("O valor do ano deve ser um inteiro. Tente novamente.\n");
            }

            //insere o programa no repositório
            if(tipo_programa == "S"){
                Serie nova = new Serie(id: serie_repositorio.ProximoId(),
                                        genero: (Genero)genero,
                                        titulo: titulo,
                                        descricao: descricao,
                                        ano: ano);

                serie_repositorio.Insere(nova);
            }
            else{
                Filme novo = new Filme(id: filme_repositorio.ProximoId(),
                                        genero: (Genero)genero,
                                        titulo: titulo,
                                        descricao: descricao,
                                        ano: ano);

                filme_repositorio.Insere(novo);
            }
        }

        static void AlterarPrograma(){
            ListarProgramas();
            Console.WriteLine();

            if((serie_repositorio.Quantidade() == 0) && (filme_repositorio.Quantidade() == 0))   return;

            string id = ReadID();

            //coleta as informações sobre o porgrama
            Console.WriteLine("Informe as novas informações:");
            Console.WriteLine("Digite o título:");
            string titulo = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite uma descrição:");
            string descricao = Console.ReadLine();
            Console.WriteLine();

            int genero = ReadGenero();

            //le o ano e valida se é um inteiro
            int ano = 0;
            bool valido = false;
            while(!valido){
                Console.WriteLine("Digite o ano de lançamento:");
                valido = int.TryParse(Console.ReadLine(), out ano);
                Console.WriteLine();

                if(!valido)     Console.WriteLine("O valor do ano deve ser um inteiro. Tente novamente.\n");
            }

            //faz a alteração
            int int_id = int.Parse(id.Substring(1).ToString());
            if(id[0] == 'S'){
                Serie nova = new Serie(id: int_id,
                                        genero: (Genero)genero,
                                        titulo: titulo,
                                        descricao: descricao,
                                        ano: ano);

                serie_repositorio.Alterar(int_id, nova);
            }
            if(id[0] == 'F'){
                Filme novo = new Filme(id: int_id,
                                        genero: (Genero)genero,
                                        titulo: titulo,
                                        descricao: descricao,
                                        ano: ano);

                filme_repositorio.Alterar(int_id, novo);
            }
        }

        static void AtualizarSerie(){
            if(serie_repositorio.Quantidade() == 0){
                Console.WriteLine("Nenhuma série existente.");
                return;
            }

            //exibir as séries existentes
            var lista = serie_repositorio.Lista();

            if(serie_repositorio.Quantidade() == 0){
                Console.WriteLine("Nenhuma série encontrada.");
            }
            else{
                Console.WriteLine("Séries presentes:");
                foreach(var serie in lista){
                    if(serie.EstaExcluido())  continue;
                    
                    Console.WriteLine("ID: S{0} | Título: {1}  | {2}", serie.RetornaId(), serie.RetornaTitulo(), (serie.Assistido ? "Nota: "+serie.GetNota() : serie.GetEpisodioAtual()));
                }
            }

            string id = "aa";
            while(id[0] != 'S'){
                Console.WriteLine();
                id = ReadID();

                if(id[0] != 'S')    Console.WriteLine("Você deve selecionar uma série.");
            }

            //le a temporada e valida se é um inteiro
            int temporada = 0;
            bool valido = false;
            while(!valido){
                Console.WriteLine("Qual a temporada do último episódio visto?");
                valido = int.TryParse(Console.ReadLine(), out temporada);
                Console.WriteLine();

                if(!valido)     Console.WriteLine("O valor da temporada deve ser um inteiro. Tente novamente.\n");
            }

            //le o episodio e valida se é um inteiro
            int episodio = 0;
            valido = false;
            while(!valido){
                Console.WriteLine("Qual o número do último episódio visto?");
                valido = int.TryParse(Console.ReadLine(), out episodio);
                Console.WriteLine();

                if(!valido)     Console.WriteLine("O valor do episodio deve ser um inteiro. Tente novamente.\n");
            }
            

            serie_repositorio.Atualizar(int.Parse(id.Substring(1).ToString()), episodio, temporada);
        }
      
        static void AvaliarPrograma(){
            ListarProgramas();
            Console.WriteLine();

            string id = ReadID();

            //le a nota e valida se é um número
            double nota = 0;
            bool valido = false;
            while(!valido){
                Console.WriteLine("Qual a nota de 0 a 5?");
                string nota_string = Console.ReadLine();
                nota_string = nota_string.Replace(',', '.');

                valido = double.TryParse(nota_string, out nota);
                Console.WriteLine();

                if(!valido)     Console.WriteLine("O valor da nota deve ser um número. Tente novamente.\n");
                else if((nota<0) || (nota>5))   Console.WriteLine("A nota deve ser entre 0 e 5. Tente novamente.");
            }

            //faz a avaliação
            int int_id = int.Parse(id.Substring(1).ToString());
            if(id[0] == 'S'){
                serie_repositorio.Avaliar(int_id, nota);
            }
            if(id[0] == 'F'){
                filme_repositorio.Avaliar(int_id, nota);
            }
        }

        static void ExcluirPrograma(){
            if((serie_repositorio.Quantidade() == 0) && (filme_repositorio.Quantidade() == 0)){
                Console.WriteLine("Não existe nenhum filme nem série para ser excluido.");
                return;
            }

            ListarProgramas();
            Console.WriteLine();
            //le o id do prgrama
            string id = ReadID();
            //exclui
            int int_id = int.Parse(id.Substring(1).ToString());
            if(id[0] == 'S'){
                serie_repositorio.Exclui(int_id);
            }
            if(id[0] == 'F'){
                filme_repositorio.Exclui(int_id);
            }
        }

        static void VizualizarPrograma(){
            if((serie_repositorio.Quantidade() == 0) && (filme_repositorio.Quantidade() == 0)){
                Console.WriteLine("Não existe nenhum filme nem série para ser visualizar.");
                return;
            }

            ListarProgramas();
            Console.WriteLine();

            string id = ReadID();

            int int_id = int.Parse(id.Substring(1).ToString());
            if(id[0] == 'S'){
                var programa = serie_repositorio.RetornaPorId(int_id);
                Console.WriteLine(programa);
            }
            if(id[0] == 'F'){
                var programa = filme_repositorio.RetornaPorId(int_id);
                Console.WriteLine(programa);
            }
        }

        private static string ReadID(){
            int int_id = 0;
            string id = "";
            bool existe = false, valido = false;

            while(!existe){
                Console.WriteLine("Qual o ID do programa?");
                id = Console.ReadLine().ToUpper();
                //Todos os IDs tem tamanho pelo menos 2
                //PRimeiro a letra S|F seguido de um número inteiro
                if(id.Length >= 2){
                    valido = int.TryParse(id.Substring(1).ToString(), out int_id);
                }
                Console.WriteLine();

                //se não a segunda parte do ID não for um inteiro
                if(!valido){
                    Console.WriteLine("O ID informado é inválido. Tente novamente.");
                    continue;
                }   

                //verifica se a primeira parte do id é válido (S ou F)
                if(id[0] == 'S'){
                    //verifica se a parte numérica do id existe
                    var lista = serie_repositorio.Lista();
                    foreach(var serie in lista){
                        if(!serie.EstaExcluido() && serie.RetornaId() == int_id){
                            existe = true;
                            break;
                        }
                    }
                }
                else if(id[0] == 'F'){
                     //verifica se a parte numérica do id existe
                    var lista = filme_repositorio.Lista();
                    foreach(var filme in lista){
                        if(!filme.EstaExcluido() && filme.RetornaId() == int_id){
                            existe = true;
                            break;
                        }
                    }
                }
                //a parte númerica do ID não existe no repositório
                if(!existe)     Console.WriteLine("O ID informado é inválido, tente novamente.");
            }
            return id;
        }

        private static int ReadGenero(){
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0}-{1}",i, Enum.GetName(typeof(Genero), i));
            }

            int genero = -1;
            bool valido = false;
            while(!valido){
                Console.WriteLine();
                Console.WriteLine("Digite o código do gênero de acordo com as opções acima:");
                valido = int.TryParse(Console.ReadLine(), out genero);
                Console.WriteLine();

                valido = Enum.IsDefined(typeof(Genero), genero);
                if(!valido)     Console.WriteLine("O valor passado não é'valido, Tente novamente.\n");
            }

            return genero;
        }
     
        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar programas");
            Console.WriteLine("2- Inserir novo programa");
            Console.WriteLine("3- Alterar informações do programa");
            Console.WriteLine("4- Atualizar último episódio assistido da série");
            Console.WriteLine("5- Avaliar programa");
            Console.WriteLine("6- Excluir programa");
            Console.WriteLine("7- Visualizar programa");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcao;
        }
    }

     
}
