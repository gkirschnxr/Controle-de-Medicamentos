using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("/fornecedores")]
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


    [HttpGet("editar/{id:Guid}")]
    public IActionResult Editar([FromRoute] Guid id) {
        var fornecedorSelecionado = repositorioFornecedor.SelecionarRegistroPorId(id);

        var editarVM = new EditarFornecedorViewModel(id, fornecedorSelecionado.Nome, 
                                                    fornecedorSelecionado.Telefone, fornecedorSelecionado.CNPJ);

        return View(editarVM);
    }


    [HttpPost("editar/{id:Guid}")]
    public IActionResult Editar([FromRoute] Guid id, EditarFornecedorViewModel editarVM) { 
        var fornecedorAtualizado = new Fornecedor(editarVM.Nome, editarVM.Telefone, editarVM.CNPJ);

        repositorioFornecedor.EditarRegistro(id, fornecedorAtualizado);

        var notificacaoVM = new NotificacaoViewModel("Fornecedor Editado!",
                                                    $"O fornecedor \"{fornecedorAtualizado.Nome}\" foi editado com sucesso!");

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("excluir/{id:Guid}")]
    public IActionResult Excluir([FromRoute] Guid id) {
        var fornecedorSelecionado = repositorioFornecedor.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirFornecedorViewModel(fornecedorSelecionado.Id, fornecedorSelecionado.Nome);

        return View(excluirVM);
    }


    [HttpPost("excluir/{id:Guid}")]
    public IActionResult ExcluirFornecedor([FromRoute] Guid id) {
        repositorioFornecedor.ExcluirRegistro(id);

        var notificacaoVM = new NotificacaoViewModel("Fornecedor Excluído!",
                                                    $"O fornecedor foi excluído com sucesso!");

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("visualizar")]
    public IActionResult Visualizar() {         
        var fornecedores = repositorioFornecedor.SelecionarRegistros();

        var visualizarVM = new VisualizarFornecedorViewModel(fornecedores);

        return View(visualizarVM);
    }
}