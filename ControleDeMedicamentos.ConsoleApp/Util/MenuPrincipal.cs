using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;
using ControleDeMedicamentos.ConsoleApp.ModuloReqSaida;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeEntrada;

namespace ControleDeMedicamentos.ConsoleApp.Util
{
    public class MenuPrincipal
    {
        private char opcaoPrincipal;
        
        private ContextoDeDados contexto;
        private TelaFornecedor telaFornecedor;
        private TelaFuncionario telaFuncionario;
        private TelaMedicamento telaMedicamento;
        private TelaPaciente telaPaciente;               
        private TelaPrescricao telaPrescricao;      
        private TelaRequisicaoDeSaida telaRequisicaoDeSaida;
        private TelaRequisicaoDeEntrada telaRequisicaoDeEntrada;
        

        public MenuPrincipal()
        {
            contexto = new ContextoDeDados(true);

            IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor(contexto);
            telaFornecedor = new TelaFornecedor(repositorioFornecedor);

            IRepositorioPaciente repositorioPaciente = new RepositorioPaciente(contexto);
            telaPaciente = new TelaPaciente(repositorioPaciente);

            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario(contexto);
            telaFuncionario = new TelaFuncionario(repositorioFuncionario);

            IRepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento(contexto);
            telaMedicamento = new TelaMedicamento(repositorioMedicamento,telaFornecedor);

            IRepositorioPrescricao repositorioPrescricao = new RepositorioPrescricao(contexto);
            telaPrescricao = new TelaPrescricao(repositorioPrescricao, repositorioMedicamento);

            IRepositorioRequisicao repositorioRequisicaoDeSaida = new RepositorioRequisicao(contexto);
            telaRequisicaoDeSaida = new TelaRequisicaoDeSaida(repositorioRequisicaoDeSaida, repositorioPaciente, repositorioPrescricao, repositorioMedicamento);

            IRepositorioRequisicaoDeEntrada repositorioRequisicaoDeEntrada = new RepositorioRequisicaoDeEntrada(contexto);
            telaRequisicaoDeEntrada = new TelaRequisicaoDeEntrada(repositorioRequisicaoDeEntrada);


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
                Console.WriteLine("2 - Controle de Pacientes");
                Console.WriteLine("3 - Controle de Medicamentos");
                Console.WriteLine("4 - Controle de Funcionarios");
                Console.WriteLine("5 - Controle de Prescrições Médicas");
                Console.WriteLine("6 - Controle de Requisições de Saída");
                Console.WriteLine("7 - Controle de Requisições de Entrada");
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
            if (opcaoPrincipal == '2')
                return telaPaciente;
            if (opcaoPrincipal == '3')
                return telaMedicamento;
            if (opcaoPrincipal == '4')
                return telaFuncionario;
            if (opcaoPrincipal == '5')
                return telaPrescricao;
            if (opcaoPrincipal == '6')
                return telaRequisicaoDeSaida;
            if (opcaoPrincipal == '7')
                return telaRequisicaoDeEntrada;

            return null!;
            ;
        }
    }
}
