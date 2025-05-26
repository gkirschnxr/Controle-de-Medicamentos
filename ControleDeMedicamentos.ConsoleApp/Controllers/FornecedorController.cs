using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("/fornecedor")]
public class FornecedorController : Controller
{
    private ContextoDeDados contextoDados;
    private IRepositorioFornecedor repositorioFornecedor;

    public FornecedorController() {
        contextoDados = new ContextoDeDados(true);
        repositorioFornecedor = new RepositorioFornecedor(contextoDados);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar() {
        var cadastrarVM = new CadastrarFornecedorViewModel();

        return View(cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarFornecedorViewModel cadastrarVM) {
        var novoFornecedor = cadastrarVM.ParaEntidade();

        repositorioFornecedor.CadastrarRegistro(novoFornecedor);

        var notificacaoVM = new NotificacaoViewModel("Fornecedor Cadastrado!",
                                                     $"O registro \"{novoFornecedor.Nome}\" foi cadastrado com sucesso!");

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("visualizar")]
    public IActionResult Visualizar() {         
        var fornecedores = repositorioFornecedor.SelecionarRegistros();

        var visualizarVM = new VisualizarFornecedorViewModel(fornecedores);

        return View(visualizarVM);
    }
}
