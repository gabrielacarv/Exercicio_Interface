using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> clientes = new List<Cliente>();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("================= MENU =================");
                Console.WriteLine("1 - Cadastrar Cliente e Criar Conta");
                Console.WriteLine("2 - Depositar");
                Console.WriteLine("3 - Sacar");
                Console.WriteLine("4 - Calcular Saldo");
                Console.WriteLine("5 - Exibir Clientes e Contas");
                Console.WriteLine("6 - Sair");
                Console.WriteLine("========================================");
                Console.WriteLine();
                Console.Write("Escolha uma opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Cliente cliente = CadastrarClienteECriarConta();
                        clientes.Add(cliente);
                        Console.WriteLine("Cliente e conta criados com sucesso!");
                        break;
                    case 2:
                        Console.Write("Digite o CPF do cliente: ");
                        string cpf = Console.ReadLine();
                        Cliente clienteEncontrado = clientes.Find(c => c.CPF == cpf);
                        if (clienteEncontrado != null)
                        {
                            Console.Write("Digite o valor para depósito: ");
                            double valorDeposito = double.Parse(Console.ReadLine());
                            Depositar(clienteEncontrado, valorDeposito);
                            Console.WriteLine("Depósito realizado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Cliente não encontrado!");
                        }
                        break;
                    case 3:
                        Console.Write("Digite o CPF do cliente: ");
                        cpf = Console.ReadLine();
                        clienteEncontrado = clientes.Find(c => c.CPF == cpf);
                        if (clienteEncontrado != null)
                        {
                            Console.Write("Digite o valor para saque: ");
                            double valorSaque = double.Parse(Console.ReadLine());
                            if (clienteEncontrado.Conta != null && clienteEncontrado.Conta.SaldoSuficiente(valorSaque))
                            {
                                Sacar(clienteEncontrado, valorSaque);
                                Console.WriteLine("Saque realizado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Saldo insuficiente ou conta não criada!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cliente não encontrado!");
                        }
                        break;
                    case 4:
                        Console.Write("Digite o CPF do cliente: ");
                        cpf = Console.ReadLine();
                        clienteEncontrado = clientes.Find(c => c.CPF == cpf);
                        if (clienteEncontrado != null)
                        {
                            Console.WriteLine($"Saldo atual: {CalcularSaldo(clienteEncontrado)}");
                        }
                        else
                        {
                            Console.WriteLine("Cliente não encontrado!");
                        }
                        break;
                    case 5:
                        ExibirClientesEContas(clientes);
                        break;
                    case 6:
                        Console.WriteLine("Saindo do programa.");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static Cliente CadastrarClienteECriarConta()
        {
            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o CPF do cliente: ");
            string cpf = Console.ReadLine();

            Cliente cliente = new Cliente(nome, cpf);

            int tipo;
            Console.WriteLine("Digite 1 para Conta Corrente, 2 para Conta Poupança ou 3 para Conta Salário: ");
            tipo = int.Parse(Console.ReadLine());

            switch (tipo)
            {
                case 1:
                    cliente.Conta = new Corrente(cliente);
                    break;
                case 2:
                    cliente.Conta = new Poupanca(cliente);
                    break;
                case 3:
                    cliente.Conta = new ContaSalario(cliente);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            return cliente;
        }      

        static void Depositar(Cliente cliente, double valor)
        {
            cliente.Conta.Depositar(valor);
        }

        static void Sacar(Cliente cliente, double valor)
        {
            cliente.Conta.Sacar(valor);
        }

        static double CalcularSaldo(Cliente cliente)
        {
            return cliente.Conta.CalcularSaldo();
        }

        static void ExibirClientesEContas(List<Cliente> clientes)
        {
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"CPF: {cliente.CPF}");
                if (cliente.Conta != null)
                {
                    Console.WriteLine($"Tipo de Conta: {cliente.Conta.GetType().Name}");
                }
                Console.WriteLine();
            }
        }
    }
}