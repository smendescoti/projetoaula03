using Dapper;
using ProjetoAula03.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula03.Repositories
{
    /// <summary>
    /// Classe de repositório de dados para Pessoa
    /// </summary>
    public class PessoaRepository
    {
        #region Atributos

        private string _connectionString;

        #endregion

        #region Construtores

        public PessoaRepository()
        {
            //inicializando o valor do atributo
            _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDProjetoAula03;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        #endregion

        /// <summary>
        /// Método para cadastrar pessoa no banco de dados
        /// </summary>
        public void Create(Pessoa pessoa)
        {
            //escrevendo uma query sql
            var sql = @"
                INSERT INTO PESSOA(
                    IDPESSOA, 
                    NOME, 
                    CPF, 
                    DATANASCIMENTO)
                VALUES(
                    @IdPessoa, 
                    @Nome, 
                    @Cpf, 
                    @DataNascimento)
            ";

            //abrindo conexão com o banco de dados do SqlServer
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando SQL
                connection.Execute(sql, pessoa);
            }
        }

        /// <summary>
        /// Método para atualizar os dados de pessoa no banco de dados
        /// </summary>
        public void Update(Pessoa pessoa)
        {
            var sql = @"
                UPDATE PESSOA SET
                    NOME = @Nome,
                    CPF = @Cpf,
                    DATANASCIMENTO = @DataNascimento
                WHERE
                    IDPESSOA = @IdPessoa
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, pessoa);
            }
        }

        /// <summary>
        /// Método para excluir uma pessoa no banco de dados
        /// </summary>
        public void Delete(Pessoa pessoa)
        {
            var sql = @"
                DELETE FROM PESSOA
                WHERE IDPESSOA = @IdPessoa
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, pessoa);
            }
        }

        /// <summary>
        /// Método para retornar uma lista com todas as pessoas cadastradas
        /// </summary>
        public List<Pessoa> GetAll()
        {
            var sql = @"
                SELECT * FROM PESSOA
                ORDER BY NOME
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Pessoa>(sql).ToList();
            }
        }

        /// <summary>
        /// Método para retornar uma pessoa baseado no ID
        /// </summary>
        public Pessoa GetById(Guid idPessoa)
        {
            var sql = @"
                SELECT * FROM PESSOA
                WHERE IDPESSOA = @idPessoa
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Pessoa>(sql, new { idPessoa }).FirstOrDefault();
            }
        }
    }
}
