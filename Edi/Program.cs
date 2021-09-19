using System;

namespace DIO.Empregos
{
    class Program
    {
        static ProfissaoRepositorio repositorio = new ProfissaoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						InserirProfissao();
						break;
					case "2":
						ListarProfissoes();
						AtualizarProfissao();
						break;
					case "3":
						ListarProfissoes();
						ExcluirProfissao();
						break;
					case "4":
						ListarProfissoes();
						VisualizarProfissao();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("#MeContrataAvanade.");
			Console.ReadLine();
        }

        private static void ExcluirProfissao()
		{
			Console.WriteLine();
			Console.Write("Digite o id da profissão: ");
			int indiceProfissao = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceProfissao);
		}

        private static void VisualizarProfissao()
		{
			Console.WriteLine();
			Console.Write("Digite o id do profissional: ");
			int indiceProfissao = int.Parse(Console.ReadLine());

			var profissao = repositorio.RetornaPorId(indiceProfissao);

			Console.WriteLine(profissao);
		}

        private static void AtualizarProfissao()
		{
			Console.Write("Digite o id do profissional: ");
			int indiceProfissao = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Profissao)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Profissao), i));
			}
			Console.Write("Digite a profissão entre as opções acima: ");
			int entradaProfissao = int.Parse(Console.ReadLine());

			Console.Write("Digite o seu nome completo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite a sua data de nascimento(dia/mês/ano): ");
			string entradaAno = Console.ReadLine();
			//int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite suas soft skills: ");
			string entradaDescricao = Console.ReadLine();

			Empregos atualizaProfissao = new Empregos(id: indiceProfissao,
										profissao: (Profissao)entradaProfissao,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceProfissao, atualizaProfissao);
		}
        private static void ListarProfissoes()
		{
			Console.WriteLine("Profissionais cadastrados");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma profissão cadastrada.");
				return;
			}

			foreach (var profissao in lista)
			{
                var excluido = profissao.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", profissao.retornaId(), profissao.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
			Console.WriteLine();
		}

        private static void InserirProfissao()
		{
			Console.WriteLine("Inserir nova profissão");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Profissao)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Profissao), i));
			}
			Console.Write("Digite a profissão entre as opções acima: ");
			int entradaProfissao = int.Parse(Console.ReadLine());

			Console.Write("Digite o seu nome completo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite sua data de nascimento(dia/mês/ano): ");
			string entradaAno = Console.ReadLine();
			//int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite suas soft skills: ");
			string entradaDescricao = Console.ReadLine();

			Empregos novaProfissao = new Empregos(id: repositorio.ProximoId(),
										profissao: (Profissao)entradaProfissao,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaProfissao);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Digital Inovation One - Capacitando Novos Profissionais a seu Dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1 - Inserir profissonais");
			Console.WriteLine("2 - Atualizar lista de profissionais");
			Console.WriteLine("3 - Excluir nome de profissionais");
			Console.WriteLine("4 - Visualizar lista de profissionais");
			Console.WriteLine("C - Limpar tela");
			Console.WriteLine("X - Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
