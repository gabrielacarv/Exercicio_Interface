using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_Interface
{
    internal class Corrente: IConta
    {
        public double Saldo { get; set; }
        public string Numero { get; set; }
        public Cliente Cliente { get; set; }

        public Corrente(Cliente cliente)
        {
            Cliente = cliente;
        }

        public double CalcularSaldo()
        {
            return Saldo;
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        public void Sacar(double valor)
        {
            Saldo -= valor;
        }

        public double CalcularTarifa()
        {
            return 0;
        }

        public bool SaldoSuficiente(double valor)
        {
            return Saldo >= valor;
        }
    }
}
