

namespace ClubeDaLeitura2.ConsoleApp.Util
{
    public class MenuPrincipal
    {
        private char opcaoPrincipal;
        

        public MenuPrincipal()
        {

            
            
        }


        public void ApresentarMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|        Clube da Leitura         |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("-----------------------------------");

            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("1 - Gerenciar Amigos");
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
                

            return null;
        }

    }
}
