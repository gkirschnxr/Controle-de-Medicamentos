﻿using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicao;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("requisicoes-medicamentos")]
public class RequisicaoMedicamentoController : Controller
{
    private ContextoDeDados contextoDados;
    private IRepositorioRequisicao repositorioRequisicao;
    private IRepositorioFuncionario repositorioFuncionario;
    private IRepositorioMedicamento repositorioMedicamento;
    private IRepositorioPaciente repositorioPaciente;
    private IRepositorioPrescricao repositorioPrescricao;

    public RequisicaoMedicamentoController() {
        contextoDados = new ContextoDeDados(true);
        repositorioRequisicao = new RepositorioRequisicao(contextoDados);
        repositorioFuncionario = new RepositorioFuncionario(contextoDados);
        repositorioMedicamento = new RepositorioMedicamento(contextoDados);
        repositorioPaciente = new RepositorioPaciente(contextoDados);
        repositorioPrescricao = new RepositorioPrescricao(contextoDados);
    }


    [HttpGet("entrada/{medicamentoId:guid}")]
    public IActionResult CadastrarEntrada(Guid medicamentoId) {
        var funcionarios = repositorioFuncionario.SelecionarRegistros();

        var medicamentoSelecionado = repositorioMedicamento.SelecionarRegistroPorId(medicamentoId);

        var cadastrarVM = new CadastrarRequisicaoEntradaViewModel(medicamentoId, funcionarios);

        ViewBag.NomeMedicamento = medicamentoSelecionado.Nome;

        return View("CadastrarEntrada", cadastrarVM);
    }


    [HttpPost("entrada/{medicamentoId:guid}")]
    public IActionResult CadastrarEntrada(Guid medicamentoId, CadastrarRequisicaoEntradaViewModel cadastrarVM) {
        var funcionarios = repositorioFuncionario.SelecionarRegistros();
        var medicamentos = repositorioMedicamento.SelecionarRegistros();

        var registro = cadastrarVM.ParaEntidade(funcionarios, medicamentos);

        var medicamentoSelecionado = repositorioMedicamento.SelecionarRegistroPorId(medicamentoId);

        medicamentoSelecionado.AdicionarAoEstoque(registro);

        repositorioRequisicao.CadastrarRequisicaoEntrada(registro);

        NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
            "Requisição de Entrada Cadastrada!",
            $"O estoque do medicamento foi atualizado!"
        );

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("saida/cadastrar")]
    public IActionResult CadastrarSaida() {
        var pacientes = repositorioPaciente.SelecionarRegistros();
        var funcionarios = repositorioFuncionario.SelecionarRegistros();

        var cadastrarVM = new CadastrarRequisicaoSaidaViewModel(funcionarios, pacientes);

        return View(cadastrarVM);
    }


    [HttpPost("saida/cadastrar")]
    public IActionResult CadastrarSaida(CadastrarRequisicaoSaidaViewModel cadastrarVM) {
        var funcionarios = repositorioFuncionario.SelecionarRegistros();
        var pacientes = repositorioPaciente.SelecionarRegistros();
        var prescricoes = repositorioPrescricao.SelecionarRegistros();

        Funcionario funcionarioSelecionado = null!;

        foreach (var f in funcionarios) {
            
            if (f.Id == cadastrarVM.FuncionarioId)
                funcionarioSelecionado = f;
        }

        Paciente pacienteSelecionado = null!;

        foreach (var p in pacientes) {
            
            if (p.Id == cadastrarVM.PacienteId)
                pacienteSelecionado = p;
        }

        var prescricoesDoPaciente = new List<Prescricao>();

        foreach (var p in prescricoes) {
            
            if (p.Paciente.Id == pacienteSelecionado!.Id)
                prescricoesDoPaciente.Add(p);
        }

        var cadastrarSaidaCompletaVM = new CadastrarRequisicaoSaidaCompletaViewModel(funcionarioSelecionado, pacienteSelecionado,prescricoesDoPaciente);

        return View("CadastrarSaidaCompleta", cadastrarSaidaCompletaVM);
    }


    [HttpPost("saida/completar-cadastro")]
    public IActionResult CadastrarSaidaCompleta(CadastrarRequisicaoSaidaCompletaViewModel cadastrarRequisicaoSaidaCompletaVM) {
        var funcionarios = repositorioFuncionario.SelecionarRegistros();
        var prescricoes = repositorioPrescricao.SelecionarRegistros();

        var entidade = cadastrarRequisicaoSaidaCompletaVM.ParaEntidade(funcionarios, prescricoes);

        foreach (var medPrescrito in entidade.Prescricao.MedicamentosPrescritos) {

            var medicamentoSelecionado = medPrescrito.Medicamento;

            medicamentoSelecionado.RemoverDoEstoque(entidade);
        }

        repositorioRequisicao.CadastrarRequisicaoSaida(entidade);

        var notificacaoVM = new NotificacaoViewModel(
            "Requisição de Saída Cadastrada!",
            $"O estoque do medicamento foi atualizado!"
        );

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("saida/visualizar")]
    public IActionResult VisualizarRequisicoesSaida() {
        var registros = repositorioRequisicao.SelecionarRequisicaoSaida();

        var visualizarVM = new VisualizarRequisicoesSaidaViewModel(registros);

        return View("VisualizarRequisicoes", visualizarVM);
    }
}