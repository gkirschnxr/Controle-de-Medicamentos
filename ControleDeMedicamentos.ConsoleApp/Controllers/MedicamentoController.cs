using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Security.Cryptography.X509Certificates;

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


    [HttpGet("cadastrar")]
    public IActionResult Cadastrar() {
        var fornecedores = repositorioFornecedor.SelecionarRegistros();

        var cadastrarVM = new CadastrarMedicamentoViewModel(fornecedores);

        return View(cadastrarVM);
    }


    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarMedicamentoViewModel cadastrarVM)
    {
        var fornecedores = repositorioFornecedor.SelecionarRegistros();

        var registro = cadastrarVM.ParaEntidade(fornecedores);

        repositorioMedicamento.CadastrarRegistro(registro);

        var notificacaoVM = new NotificacaoViewModel("Medicamento Cadastrado!",
                                                    $"O registro \"{registro.Nome}\" foi cadastrado com sucesso!");

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("editar/{id:Guid}")]
    public IActionResult Editar([FromRoute] Guid id) {
        var medicamentoSelecionado = repositorioMedicamento.SelecionarRegistroPorId(id);

        var fornecedor = repositorioFornecedor.SelecionarRegistros();

        var editarVM = new EditarMedicamentoViewModel(medicamentoSelecionado.Id, medicamentoSelecionado.Nome,
                                                     medicamentoSelecionado.Descricao, medicamentoSelecionado.Fornecedor!.Id, fornecedor);    
    
        return View();
    }


    [HttpPost("editar/{id:Guid}")]
    public IActionResult Editar([FromRoute] Guid id, EditarMedicamentoViewModel editarVM) {
        var fornecedor = repositorioFornecedor.SelecionarRegistros();

        var registro = editarVM.ParaEntidade(fornecedor);

        repositorioMedicamento.EditarRegistro(id, registro);

        var notificacaoVM = new NotificacaoViewModel("Medicamento Editado!",
                                                    $"O registro \"{registro.Nome}\" foi editado com sucesso!");

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("excluir/{id:Guid}")]
    public IActionResult Excluir([FromRoute] Guid id) {
        var registro = repositorioMedicamento.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirMedicamentoViewModel(registro.Id, registro.Nome);

        return View(excluirVM);
    }


    [HttpPost("excluir/{id:Guid}")]
    public IActionResult ExcluirConfirmado([FromRoute] Guid id) {
        repositorioMedicamento.ExcluirRegistro(id);

        var notificacaoVM = new NotificacaoViewModel("Medicamento Excluído!",
                                                    "O registro foi excluído com sucesso!");

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("visualizar")]
    public IActionResult Visualizar() {
        var medicamentos = repositorioMedicamento.SelecionarRegistros();

        VisualizarMedicamentoViewModel visualizarVM = new VisualizarMedicamentoViewModel(medicamentos);

        return View(visualizarVM);
    }
}