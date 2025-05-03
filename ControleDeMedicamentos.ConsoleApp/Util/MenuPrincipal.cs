

using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ClubeDaLeitura2.ConsoleApp.Util
{
    public class MenuPrincipal
    {
        private char opcaoPrincipal;
        
        private ContextoDeDados contexto;
        private TelaFornecedor telaFornecedor;
        private TelaFuncionario telaFuncionario;
        private TelaMedicamento telaMedicamento;

        

        public MenuPrincipal()
        {
            contexto = new ContextoDeDados(true);

            IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor(contexto);
            IRepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento(contexto);
            telaFornecedor = new TelaFornecedor(repositorioFornecedor);

            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario(contexto);
            telaFuncionario = new TelaFuncionario(repositorioFuncionario);
            telaMedicamento = new TelaMedicamento(repositorioMedicamento);
        }


        public void ApresentarMenu()
        {

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("|                                         |");
                Console.WriteLine("|        Controle de Medicamentos         |");
                Console.WriteLine("|                                         |");
                Console.WriteLine("-------------------------------------------");

                Console.ResetColor();
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("1 - Controle de Fornecedores");
                Console.WriteLine("4 - Controle de Funcionarios");
                Console.WriteLine("3 - Controle de Medicamentos");
                Console.WriteLine("S - Sair");


                Console.WriteLine();

                Console.Write("Escolha uma das opções: ");
                Console.ResetColor();
                opcaoPrincipal = Console.ReadLine()![0];


            
            

       }

        public ITelaCrud ObterTela()
        {
            if (opcaoPrincipal == '1')
                return telaFornecedor;
            if (opcaoPrincipal == '4')
                return telaFuncionario;
            return null;

            if (opcaoPrincipal == '3')
                return telaMedicamento;

                return null;
        }
    }
}
