﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula03.Validations
{
    /// <summary>
    /// Classe de validação para campos do tipo Nome 
    /// </summary>
    public class NomeValidation
    {
        public static bool IsValid(string nome)
        {
            var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{6,150}$");
            return regex.IsMatch(nome);
        }
    }
}
