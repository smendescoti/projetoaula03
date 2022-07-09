using ProjetoAula03.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula03.Entities
{
    /// <summary>
    /// Classe de entidade
    /// </summary>
    public class Pessoa
    {
        #region Atributos

        private Guid _idPessoa;
        private string _nome;
        private string _cpf;
        private DateTime _dataNascimento;

        #endregion

        #region Propriedades

        public Guid IdPessoa
        {
            get => _idPessoa;
            set 
            {
                if (!IdValidation.IsValid(value))
                    throw new ArgumentException("ID da Pessoa é inválido.");

                _idPessoa = value; 
            }
        }

        public string Nome
        {
            get => _nome;
            set 
            {
                if(!NomeValidation.IsValid(value))
                    throw new ArgumentException("Nome da Pessoa é inválido.");

                _nome = value; 
            }
        }

        public string Cpf
        {
            get => _cpf;
            set 
            {
                if (!CpfValidation.IsValid(value))
                    throw new ArgumentException("CPF da Pessoa é inválido.");

                _cpf = value; 
            }
        }

        public DateTime DataNascimento
        {
            get => _dataNascimento;
            set 
            {
                if (!DataValidation.IsValid(value))
                    throw new Exception("Data de Nascimento da Pessoa é inválida.");

                _dataNascimento = value; 
            }
        }

        #endregion
    }
}
