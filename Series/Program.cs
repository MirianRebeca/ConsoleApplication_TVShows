using System;
using System.Threading;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
             while (opcaoUsuario.ToUpper() != "S")
             {
                 switch (opcaoUsuario)
                 {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida!\n");
                        break;
                 }
                 opcaoUsuario = ObterOpcaoUsuario();
             }
             Console.Clear();
             Console.WriteLine("Obrigada por utilizar nossos serviços!");
             Thread.Sleep(2000);
        }

        public static Tuple<bool, int> Validar()
        {
            string value = Console.ReadLine();
            int number;
            bool success = Int32.TryParse(value, out number);
            return new Tuple<bool, int>(success, number);
        }
         private static void ExcluirSerie()
		{
            if (ListarSeries()) {
			Console.WriteLine("\nDigite o código da série: ");
            var dados = Validar();
            if(dados.Item1 && (dados.Item2 >= 0 && dados.Item2 <= repositorio.ProximoId())){
                Console.WriteLine("\nDigite S para confirmar a exclusão" );
                string confirmar = Console.ReadLine();
                if(confirmar.ToUpper()=="S")
			        repositorio.Exclui(dados.Item2);
                else{
                    Console.WriteLine("\nExclusão não realizada.\n");
                }
		    }else{
                ExcluirSerie();
            }
            }
        }

        private static void VisualizarSerie()
		{
            if (ListarSeries()){
			Console.Write("\nDigite o código da série:\n");
            var dados = Validar();
            if(dados.Item1 && (dados.Item2 >= 0 && dados.Item2 <= repositorio.ProximoId())){
			    var serie = repositorio.RetornaPorId(dados.Item2);
                Console.WriteLine();
			    Console.WriteLine(serie);
            } else{
                VisualizarSerie();
            } 
            }
		}
        private static bool ListarSeries()
        {
             Console.Clear();
            if (repositorio.ProximoId() == 0){
                Console.WriteLine("Nenhuma série cadastrada.\n");
                return false;
                 
            }else{
            Console.Clear();
            Console.WriteLine("Séries Disponíveis:\n");
            var lista = repositorio.Lista();
            foreach (var serie in lista){
                var excluido = serie.retornaExcluido();
                Console.WriteLine("Código {0} - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Fora do Catálogo" : "Disponível"));
            }return true;
            
        }
        }
         private static object[] PreencherInfos()
        {   
            Console.Clear();
            object[] infos = new object[4];
            bool aux = true;
            while(aux){
            Console.Write("Escolha o gênero da série:\n\n");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("\t{0}- {1}", i, Enum.GetName(typeof(Genero), i));
            }
            var dados = Validar();
            if(dados.Item1 && (dados.Item2 > 0 && dados.Item2 <= Enum.GetNames(typeof(Genero)).Length))
                {
                    infos[0] = dados.Item2;
                    aux = false;
                }
            else{
                    Console.Clear();
                    Console.WriteLine("Opção inválida!\n");
                }
            }
            
            Console.Write("Digite o título da série: ");
            infos[1] = Console.ReadLine(); 
            
            bool aux1 = true;
            while(aux1){
            Console.Write("Digite o ano de início da série: ");
            var dados = Validar();
            if(dados.Item1 && (dados.Item2 > 1945 && dados.Item2 <= DateTime.Now.Year))
                {
                    infos[2] = dados.Item2;
                    aux1 = false;                   
                }
            else{
                    Console.WriteLine("\nOpção inválida!");
                }
            }

            Console.Write("Digite a descrição da série: ");
            infos[3] = Console.ReadLine();

            return infos;
        }

        private static void InserirSerie()
        {   
            var dadosUsuario = PreencherInfos();

            Serie novaSerie = new Serie(
                id: repositorio.ProximoId(),
                titulo: Convert.ToString(dadosUsuario[1]),
                 genero: (Genero)dadosUsuario[0],
                ano: Convert.ToInt16(dadosUsuario[2]),
                descricao: Convert.ToString(dadosUsuario[3]));
            repositorio.Insere(novaSerie);
            Console.Clear();
        }

        private static void AtualizarSerie()
        {   
            if (ListarSeries()){
            Console.Write("\nDigite o código da série: ");
            var dados = Validar();
                if(dados.Item1 && (dados.Item2 >= 0 && dados.Item2 <= repositorio.ProximoId())){
                    var dadosUsuario = PreencherInfos();

                    Serie atualizaSerie = new Serie(
                        id: dados.Item2,
                        titulo: Convert.ToString(dadosUsuario[1]),
                        genero: (Genero)dadosUsuario[0],
                        ano: Convert.ToInt16(dadosUsuario[2]),
                        descricao: Convert.ToString(dadosUsuario[3]));
                    repositorio.Atualiza(dados.Item2, atualizaSerie);
                    Console.Clear();
                }else{
                    AtualizarSerie();
                }
                    }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Informe a Opção desejada:\n");
            Console.WriteLine("\t1- Listar Séries");
            Console.WriteLine("\t2- Inserir nova série");
            Console.WriteLine("\t3- Atualizar série");
            Console.WriteLine("\t4- Excluir série");
            Console.WriteLine("\t5- Visualizar série");
            Console.WriteLine("\tS- Sair");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}