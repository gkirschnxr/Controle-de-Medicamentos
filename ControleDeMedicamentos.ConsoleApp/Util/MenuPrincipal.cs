

using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ClubeDaLeitura2.ConsoleApp.Util
{
    public class MenuPrincipal
    {
        private char opcaoPrincipal;
        
        private ContextoDeDados contexto;
        private TelaFornecedor telaFornecedor;

        

        public MenuPrincipal()
        {
            contexto = new ContextoDeDados(true);

            IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor(contexto);
            telaFornecedor = new TelaFornecedor(repositorioFornecedor);
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
                Console.WriteLine("S - Sair");


                Console.WriteLine();

                Console.Write("Escolha uma das opções: ");
                Console.ResetColor();
                opcaoPrincipal = Console.ReadLine()[0];


            
            

       }

        public ITelaCrud ObterTela()
        {
            if (opcaoPrincipal == '1')
                return telaFornecedor;
            return null;
        }

    }
}
