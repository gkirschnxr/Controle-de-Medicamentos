using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("/pacientes")]
public class PacienteController : Controller {
    private ContextoDeDados contexto;
    private IRepositorioPaciente repositorioPaciente;
    
    public PacienteController() {
        contexto = new ContextoDeDados(true);
        repositorioPaciente = new RepositorioPaciente(contexto);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar() {
        var cadastrarVM = new CadastrarPacienteViewModel();

        return View(cadastrarVM);
    }


    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarPacienteViewModel cadastrarVM) {
        var novoPaciente = cadastrarVM.ParaEntidade();

        repositorioPaciente.CadastrarRegistro(novoPaciente);

        var notificacaoVM = new NotificacaoViewModel(
             "Paciente Cadastrado!",
            $"O registro \"{novoPaciente.NomePaciente}\" foi cadastrado com sucesso!");

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("editar/{id:Guid}")]
    public IActionResult Editar([FromRoute] Guid id) {
        var pacienteSelecionado = repositorioPaciente.SelecionarRegistroPorId(id);

        var editarVM = new EditarPacienteViewModel(pacienteSelecionado.Id, pacienteSelecionado.NomePaciente,
                                                  pacienteSelecionado.Telefone, pacienteSelecionado.CartaoSus);

        return View(editarVM);
    }


    [HttpPost("editar/{id:Guid}")]
    public IActionResult Editar([FromRoute] Guid id, EditarPacienteViewModel editarVM)
    {
        var pacienteEditado = editarVM.ParaEntidade();

        repositorioPaciente.EditarRegistro(id, pacienteEditado);

        var notificacaoVM = new NotificacaoViewModel(
             "Paciente Editado!",
            $"O registro \"{pacienteEditado.NomePaciente}\" foi editado com sucesso!");

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("excluir/{id:Guid}")]
    public IActionResult Excluir([FromRoute] Guid id) {
        var pacienteSelecionado = repositorioPaciente.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirPacienteViewModel(pacienteSelecionado.Id, pacienteSelecionado.NomePaciente);
    
        return View(excluirVM);
    }


    [HttpPost("excluir/{id:Guid}")]
    public IActionResult ExcluirPaciente([FromRoute] Guid id) {
        repositorioPaciente.ExcluirRegistro(id);

        var notificacaoVM = new NotificacaoViewModel(
             "Paciente Excluído!",
            $"O registro foi excluído com sucesso!");

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("visualizar")]
    public IActionResult Visualizar() {  
       var pacientes = repositorioPaciente.SelecionarRegistros();

       var visualizarVM = new VisualizarPacienteViewModel(pacientes);
        
       return View(visualizarVM); 
    }
}
