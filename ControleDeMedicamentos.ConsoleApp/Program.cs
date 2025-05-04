using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        MenuPrincipal menuPrincipal = new MenuPrincipal();

        while (true)
        {
            menuPrincipal.ApresentarMenu();

            ITelaCrud telaSelecionada = menuPrincipal.ObterTela();

            char opcaoEscolhida = telaSelecionada.ApresentarMenu();

            switch (opcaoEscolhida)
            {
                case '1': telaSelecionada.CadastrarRegistro(); break;
                case '2': telaSelecionada.EditarRegistro(); break;
                case '3': telaSelecionada.ExcluirRegistro(); break;
                case '4': telaSelecionada.VisualizarRegistros(true); break;

                default: break;
            }
        }

    }
}
