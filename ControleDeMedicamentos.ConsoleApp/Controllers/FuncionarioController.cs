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
                                                    $"O funcionário \"{novoFuncionario.NomeFuncionario}\" foi cadastrado com sucesso!");

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("editar/{id:Guid}")]
    public IActionResult Editar([FromRoute] Guid id) { 
        var funcionarioSelecionado = repositorioFuncionario.SelecionarRegistroPorId(id);

        var editarVM = new EditarFuncionarioViewModel(funcionarioSelecionado.Id, funcionarioSelecionado.NomeFuncionario,
                                                     funcionarioSelecionado.Telefone, funcionarioSelecionado.CPF);

        return View(editarVM);
    }


    [HttpPost("editar/{id:Guid}")]
    public IActionResult Editar([FromRoute] Guid id, EditarFuncionarioViewModel editarVM) {
        var funcionarioAtualizado = new Funcionario(editarVM.Nome, editarVM.Telefone, editarVM.CPF);

        repositorioFuncionario.EditarRegistro(id, funcionarioAtualizado);

        var notificacaoVM = new NotificacaoViewModel("Funcionário Editado!",
                                                    $"O registro \"{funcionarioAtualizado.NomeFuncionario}\" foi atualizado com sucesso!");

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("excluir/{id:Guid}")]
    public IActionResult Excluir([FromRoute] Guid id) {
        var funcionarioSelecionado = repositorioFuncionario.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirFuncionarioViewModel(funcionarioSelecionado.Id, funcionarioSelecionado.NomeFuncionario);

        return View(excluirVM);
    }


    [HttpPost("excluir/{id:Guid}")]
    public IActionResult ExcluirFuncionario([FromRoute] Guid id) {
        repositorioFuncionario.ExcluirRegistro(id);

        var notificacaoVM = new NotificacaoViewModel("Funcionário Excluído!",
                                                    $"O funcionário foi excluído com sucesso"!);

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("visualizar")]
    public IActionResult Visualizar() {
        var funcionarios = repositorioFuncionario.SelecionarRegistros();

        var visualizarVM = new VisualizarFuncionarioViewModel(funcionarios);

        return View(visualizarVM);
    }
}
