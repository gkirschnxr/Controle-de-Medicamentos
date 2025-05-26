using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("/pacientes")]
public class PacienteController : Controller
{
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
            $"O registro \"{novoPaciente.Nome}\" foi cadastrado com sucesso!");

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id) {
        var pacienteSelecionado = repositorioPaciente.SelecionarRegistroPorId(id);

        var editarVM = new EditarPacienteViewModel(pacienteSelecionado.Id, pacienteSelecionado.Nome,
                                                  pacienteSelecionado.Telefone, pacienteSelecionado.CartaoSus);

        return View(editarVM);
    }


    [HttpPost("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id, EditarPacienteViewModel editarVM)
    {
        var pacienteEditado = editarVM.ParaEntidade();

        repositorioPaciente.EditarRegistro(id, pacienteEditado);

        var notificacaoVM = new NotificacaoViewModel(
             "Paciente Editado!",
            $"O registro \"{pacienteEditado.Nome}\" foi editado com sucesso!");

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("visualizar")]
    public IActionResult Visualizar() {  
       var pacientes = repositorioPaciente.SelecionarRegistros();

       var visualizarVM = new VisualizarPacienteViewModel(pacientes);
        
       return View(visualizarVM); 
    }
}
