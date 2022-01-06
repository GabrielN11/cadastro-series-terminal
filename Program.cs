using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio;
		static void Main(string[] args)
        {
			repositorio = new SerieRepositorio();
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
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
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
        }

        private static void ExcluirSerie()
		{
			Console.Clear();
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			string resp = repositorio.Excluir(indiceSerie);
			Console.Clear();
			Console.WriteLine(resp);
		}

        private static void VisualizarSerie()
		{
			Console.Clear();
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornarPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Clear();
			int indiceSerie;
            try
            {
				Console.Write("Digite o id da série: ");
				indiceSerie = int.Parse(Console.ReadLine());

            }
            catch
            {
				Console.Clear();
				Console.WriteLine("Valor Inválido");
				return;
            }

			int categs = 0;
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				categs++;
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			int entradaGenero = 0;
			while(entradaGenero < 1 || entradaGenero > categs)
            {
                try
                {
					Console.Write("Digite o gênero entre as opções acima: ");
					entradaGenero = int.Parse(Console.ReadLine());
                }
                catch
                {
					Console.Clear();
					Console.WriteLine("Valor inválido");
					return;
                }
			}

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno;

			try
            {
				entradaAno = int.Parse(Console.ReadLine());
            }
            catch
            {
				Console.Clear();
				Console.WriteLine("Valor inválido.");
				return;
            }

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			int entradaTemporadas;
			try
            {
				Console.Write("Digite a quantidade de temporadas que a série possuí: ");
				entradaTemporadas = int.Parse(Console.ReadLine());
            }
            catch
            {
				Console.Clear();
				Console.WriteLine("Valor inválido.");
				return;
            }

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
                                        temporadas: entradaTemporadas,
										descricao: entradaDescricao);

			repositorio.Atualizar(indiceSerie, atualizaSerie);
			Console.Clear();
		}
        private static void ListarSeries()
		{
			Console.Clear();
			Console.WriteLine("Listar séries");

			var lista = repositorio.Listar();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.Status();
                
				if(!excluido)
				Console.WriteLine("#ID {0}: - {1}", serie.getId(), serie.getTitulo());
			}
		}

        private static void InserirSerie()
		{
			Console.Clear();
			Console.WriteLine("Inserir nova série");

			int categs = 0;
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				categs++;
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			int entradaGenero = 0;
			while(entradaGenero < 1 || entradaGenero > categs)
            {
                try
                {
					Console.Write("Digite o gênero entre as opções acima: ");
					entradaGenero = int.Parse(Console.ReadLine());
                }
                catch
                {
					Console.Clear();
					Console.WriteLine("Valor inválido");
					return;
                }
			}

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			int entradaAno;

            try
            {
				Console.Write("Digite o Ano de Início da Série: ");
				entradaAno = int.Parse(Console.ReadLine());
            }
            catch
            {
				Console.Clear();
				Console.WriteLine("Valor inválido");
				return;
            }

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			int entradaTemporadas;
            try
            {
				Console.Write("Digite a quantidade de temporadas que a série possuí: ");
				entradaTemporadas = int.Parse(Console.ReadLine());
            }
            catch
            {
				Console.Clear();
				Console.WriteLine("Valor inválido");
				return;
            }

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
                                        temporadas: entradaTemporadas,
										descricao: entradaDescricao);

			repositorio.Inserir(novaSerie);
			Console.Clear();
			Console.WriteLine("Série inserida.");
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
