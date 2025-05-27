using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("/medicamentos")]
public class MedicamentoController : Controller {
    private ContextoDeDados contexto;
    private IRepositorioMedicamento repositorioMedicamento;
    private IRepositorioFornecedor repositorioFornecedor;

    public MedicamentoController() {
        contexto = new ContextoDeDados(true);
        repositorioMedicamento = new RepositorioMedicamento(contexto);
        repositorioFornecedor = new RepositorioFornecedor(contexto);
    }

    [HttpGet("visualizar")]
    public IActionResult Visualizar() {
        var medicamentos = repositorioMedicamento.SelecionarRegistros();
        
        var visualizarVM = new VisualizarMedicamentoViewModel(medicamentos);

        return View(visualizarVM);
    }
}
