using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_Interface
{
    interface IConta
    {
        double Saldo { get; set; }
        string Numero { get; set; }
        Cliente Cliente { get; set; }

        double CalcularSaldo();
        void Sacar(double valor);
        void Depositar(double valor);
        bool SaldoSuficiente(double valor);
    }
}
