using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.Util;
using System.Text;

namespace ControleDeMedicamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        WebApplication app = builder.Build();

        app.MapGet("/", PaginaInicial);

        app.MapGet("/fornecedor/visualizar", VisualizarFornecedores);

        app.Run();
    }

    static Task PaginaInicial(HttpContext context)
    {
        string conteudo = File.ReadAllText("Html/PaginaInicial.html");

        return context.Response.WriteAsync(conteudo);
    }

    static Task VisualizarFornecedores(HttpContext context)
    {
        ContextoDeDados contextoDeDados = new ContextoDeDados();
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor(contextoDeDados);

        string conteudo = File.ReadAllText("ModuloFornecedor/Html/Visualizar.html");

        StringBuilder sb = new StringBuilder(conteudo);

        foreach (Fornecedor f in repositorioFornecedor.SelecionarRegistros())
        {
            string itemLista = $"<li>{f.ToString()}</li> #fornecedor#";

            sb.Replace("#fornecedor#", itemLista);
        }

        sb.Replace("#fornecedor#", "");

        string conteudoString = sb.ToString();

        return context.Response.WriteAsync(conteudoString);
    }
}
