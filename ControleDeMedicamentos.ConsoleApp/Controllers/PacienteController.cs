using ControleDeMedicamentos.ConsoleApp.Compartilhado;
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

    [HttpGet("visualizar")]
    public IActionResult Visualizar() {  
       var pacientes = repositorioPaciente.SelecionarRegistros();

       var visualizarVM = new VisualizarPacienteViewModel(pacientes);
        
       return View(visualizarVM); 
    }
}
