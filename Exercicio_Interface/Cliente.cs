using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_Interface
{
    internal class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public IConta Conta { get; set; }

        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }
    }
}
