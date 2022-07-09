using ProjetoAula03.Controllers;

namespace ProjetoAula03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\n*** SISTEMA DE CONTROLE DE PESSOAS ***\n");

                Console.WriteLine("(1) Cadastrar Pessoas");
                Console.WriteLine("(2) Atualizar Pessoas");
                Console.WriteLine("(3) Excluir Pessoas");
                Console.WriteLine("(4) Consultar Pessoas");

                Console.Write("\nInforme a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());

                var pessoaController = new PessoaController();
                Console.Clear();

                switch(opcao)
                {
                    case 1:
                        pessoaController.CadastrarPessoa();
                        break;

                    case 2:
                        pessoaController.AtualizarPessoa();
                        break;

                    case 3:
                        pessoaController.ExcluirPessoa();
                        break;

                    case 4:
                        pessoaController.ConsultarPessoas();
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha: {e.Message}");
            }
            finally
            {
                Console.Write("\nDeseja sair do programa? (S,N): ");
                var desejaSair = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);

                if (!desejaSair)
                {
                    Console.Clear();
                    Main(args);
                }
                else
                {
                    Console.WriteLine("\nFIM DO PROGRAMA!");
                }
            }

            Console.ReadKey();
        }
    }
}