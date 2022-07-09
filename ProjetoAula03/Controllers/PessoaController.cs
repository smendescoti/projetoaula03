using ProjetoAula03.Entities;
using ProjetoAula03.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula03.Controllers
{
    /// <summary>
    /// Classe de controle para operações de pessoa
    /// </summary>
    public class PessoaController
    {
        public void CadastrarPessoa()
        {
            try
            {
                Console.WriteLine("\n *** CADASTRO DE PESSOA ***\n");

                var pessoa = new Pessoa();
                pessoa.IdPessoa = Guid.NewGuid();

                Console.Write("Informe o nome da pessoa...............: ");
                pessoa.Nome = Console.ReadLine();

                Console.Write("Informe o cpf da pessoa................: ");
                pessoa.Cpf = Console.ReadLine();

                Console.Write("Informe a data de nascimento da pessoa.: ");
                pessoa.DataNascimento = DateTime.Parse(Console.ReadLine());

                var pessoaRepository = new PessoaRepository();
                pessoaRepository.Create(pessoa);

                Console.WriteLine("\nPessoa cadastrada com sucesso!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"\nErro de validação: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao cadastrar: {e.Message}");
            }
            finally
            {
                if (DesejaRepetirOProcesso())
                {
                    Console.Clear();
                    CadastrarPessoa();
                }
            }
        }

        public void AtualizarPessoa()
        {
            try
            {
                Console.WriteLine("\n *** ATUALIZAÇÃO DE PESSOA ***\n");

                Console.Write("Informe o Id da pessoa.................: ");
                var idPessoa = Guid.Parse(Console.ReadLine());

                //consultando pessoa através do ID..
                var pessoaRepository = new PessoaRepository();
                var pessoa = pessoaRepository.GetById(idPessoa);

                //verificando se nenhum registro foi encontrado
                if (pessoa == null)
                    throw new ArgumentException("O ID informado não existe no banco de dados.");

                var desejaAtualizar = false;

                Console.Write("\nDeseja alterar o nome? (S,N)...........: ");
                desejaAtualizar = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);

                if(desejaAtualizar)
                {
                    Console.Write("Informe o Nome da pessoa...............: ");
                    pessoa.Nome = Console.ReadLine();
                }

                Console.Write("\nDeseja alterar o CPF? (S,N)............: ");
                desejaAtualizar = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);

                if (desejaAtualizar)
                {
                    Console.Write("Informe o CPF da pessoa................: ");
                    pessoa.Cpf = Console.ReadLine();
                }

                Console.Write("\nDeseja alterar a Data de Nasc? (S,N)...: ");
                desejaAtualizar = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);

                if (desejaAtualizar)
                {
                    Console.Write("Informe a Data de Nasc da pessoa.......: ");
                    pessoa.DataNascimento = DateTime.Parse(Console.ReadLine());
                }

                //atualizando os dados da pessoa
                pessoaRepository.Update(pessoa);

                Console.WriteLine("\nPessoa atualizada com sucesso!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"\nErro de validação: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao atualizar: {e.Message}");
            }
            finally
            {
                if(DesejaRepetirOProcesso())
                {
                    Console.Clear();
                    AtualizarPessoa();
                }
            }
        }

        public void ExcluirPessoa()
        {
            try
            {
                Console.WriteLine("\n *** EXCLUSÃO DE PESSOA ***\n");

                Console.Write("Informe o Id da pessoa.................: ");
                var idPessoa = Guid.Parse(Console.ReadLine());

                //consultando pessoa através do ID..
                var pessoaRepository = new PessoaRepository();
                var pessoa = pessoaRepository.GetById(idPessoa);

                //verificando se nenhum registro foi encontrado
                if (pessoa == null)
                    throw new ArgumentException("O ID informado não existe no banco de dados.");

                //excluindo..
                pessoaRepository.Delete(pessoa);

                Console.WriteLine("\nPessoa excluída com sucesso!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"\nErro de validação: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao atualizar: {e.Message}");
            }
            finally
            {
                if (DesejaRepetirOProcesso())
                {
                    Console.Clear();
                    ExcluirPessoa();
                }
            }
        }

        public void ConsultarPessoas()
        {
            try
            {
                Console.WriteLine("\n *** CONSULTA DE PESSOAS ***\n");

                var pessoaRepository = new PessoaRepository();
                var pessoas = pessoaRepository.GetAll();

                foreach (var item in pessoas)
                {
                    Console.WriteLine($"ID PESSOA..............: {item.IdPessoa}");
                    Console.WriteLine($"NOME DA PESSOA.........: {item.Nome}");
                    Console.WriteLine($"CPF....................: {item.Cpf}");
                    Console.WriteLine($"DATA DE NASCIMENTO.....: {item.DataNascimento.ToString("dd/MM/yyyy")}");
                    Console.WriteLine("...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao atualizar: {e.Message}");
            }
            finally
            {
                if (DesejaRepetirOProcesso())
                {
                    Console.Clear();
                    ConsultarPessoas();
                }
            }
        }

        //método para verificar se o usuário deseja repetir o processo
        private bool DesejaRepetirOProcesso()
        {
            Console.Write("\nDeseja repetir o processo? (S,N): ");
            var opcao = Console.ReadLine();

            return opcao != null && opcao.Equals("S", StringComparison.OrdinalIgnoreCase);
        }
    }
}
