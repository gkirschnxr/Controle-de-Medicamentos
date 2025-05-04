using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
    
        MenuPrincipal telaPrincipal = new MenuPrincipal();

        while (true)
        {
            Console.Clear();

            telaPrincipal.ApresentarMenu();
            ITelaCrud telaSelecionada = telaPrincipal.ObterTela(); 

            char opcaoEscolhida = telaSelecionada.ApresentarMenu();

            //if (telaSelecionada is TelaEmprestimo)
            //{
            //    TelaEmprestimo telaEmprestimo = (TelaEmprestimo)telaSelecionada;

            //    if (opcaoEscolhida == 5)
            //        telaEmprestimo.RegistrarDevolucao();
            //}

            switch (opcaoEscolhida)
            {
                case '1': telaSelecionada.CadastrarRegistro(); break;

                case '2': telaSelecionada.EditarRegistro(); break;

                case '3': telaSelecionada.ExcluirRegistro(); break;

                case '4': telaSelecionada.VisualizarRegistros(true); break;


            }


        }
    }

}
