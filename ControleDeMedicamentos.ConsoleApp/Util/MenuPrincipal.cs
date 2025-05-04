using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;

namespace ControleDeMedicamentos.ConsoleApp.Util
{
    public class MenuPrincipal
    {
        private char opcaoPrincipal;

        private ContextoDeDados contexto;
        private TelaPaciente telaPaciente;        

        public MenuPrincipal()
        {
            contexto = new ContextoDeDados(true);

            IRepositorioPaciente repositorioPaciente = new RepositorioPaciente(contexto);
            telaPaciente = new TelaPaciente(repositorioPaciente);
        }

        public void ApresentarMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|        Farmacinha do Biel       |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("-----------------------------------");

            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("1 - Gerenciar Pacientes");
            Console.WriteLine("2 - Gerenciar Caixas");
            Console.WriteLine("3 - Gerenciar Revistas");
            Console.WriteLine("4 - Gerenciar Emprestimos");
            Console.WriteLine("S - Sair");


            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            Console.ResetColor();
            opcaoPrincipal = Console.ReadLine()[0];

            

        }

        public ITelaCrud ObterTela()
        {
            if (opcaoPrincipal == '1')
                return telaPaciente;
                

            return null;
        }

    }
}
