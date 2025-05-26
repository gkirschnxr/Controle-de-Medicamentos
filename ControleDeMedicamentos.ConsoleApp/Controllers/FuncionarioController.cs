using AspNetCoreGeneratedDocument;
using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("/funcionarios")]
public class FuncionarioController : Controller
{
    private ContextoDeDados contexto;
    private IRepositorioFuncionario repositorioFuncionario;

    public FuncionarioController()
    {
        contexto = new ContextoDeDados(true);
        repositorioFuncionario = new RepositorioFuncionario(contexto);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar() {
        var cadastrarVM = new CadastrarFuncionarioViewModel();

        return View(cadastrarVM);
    }


    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarFuncionarioViewModel cadastrarVM) {
        var novoFuncionario = cadastrarVM.ParaEntidade();

        repositorioFuncionario.CadastrarRegistro(novoFuncionario);

        var notificacaoVM = new NotificacaoViewModel("Funcionário Cadastrado!",
                                                    $"O funcionário \"{novoFuncionario.Nome}\" foi cadastrado com sucesso!");

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("visualizar")]
    public IActionResult Visualizar() {
        var funcionarios = repositorioFuncionario.SelecionarRegistros();

        var visualizarVM = new VisualizarFuncionarioViewModel(funcionarios);

        return View(visualizarVM);
    }
}
