﻿using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("prescricoes-medicas")]
public class PrescricaoController : Controller
{
    private ContextoDeDados contexto;
    private IRepositorioPrescricao repositorioPrescricao;
    private IRepositorioPaciente repositorioPaciente;
    private IRepositorioMedicamento repositorioMedicamento;

    public PrescricaoController()
    {
        contexto = new ContextoDeDados(true);
        repositorioPrescricao = new RepositorioPrescricao(contexto);
        repositorioPaciente = new RepositorioPaciente(contexto);
        repositorioMedicamento = new RepositorioMedicamento(contexto);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar() {
        var pacientes = repositorioPaciente.SelecionarRegistros();
        var medicamentos = repositorioMedicamento.SelecionarRegistros();

        CadastrarPrescricaoViewModel cadastrarVM;

        var prescricaoArmazenada = TempData.Peek("Prescricao");

        if (prescricaoArmazenada is null && prescricaoArmazenada is string jsonString) {
            cadastrarVM = JsonSerializer.Deserialize<CadastrarPrescricaoViewModel>(jsonString)!;

            cadastrarVM.AdicionarPacientes(pacientes);
            cadastrarVM.AdicionarMedicamentos(medicamentos);

            return View(cadastrarVM);
        }

        cadastrarVM = new CadastrarPrescricaoViewModel(pacientes, medicamentos);

        return View(cadastrarVM);
    }


    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarPrescricaoViewModel cadastrarVM, string acaoSubmit) {
        var pacientes = repositorioPaciente.SelecionarRegistros();
        var medicamentos = repositorioMedicamento.SelecionarRegistros();

        if (TempData.TryGetValue("Prescricao", out var valor) && valor is string jsonString) {
            var vmAnterior = JsonSerializer.Deserialize<CadastrarPrescricaoViewModel>(jsonString)!;

            vmAnterior.CRM = cadastrarVM.CRM;
            vmAnterior.PacienteId = cadastrarVM.PacienteId;
            vmAnterior.MedicamentoId = cadastrarVM.MedicamentoId;
            vmAnterior.DosagemMedicamento = cadastrarVM.DosagemMedicamento;
            vmAnterior.PeriodoMedicamento = cadastrarVM.PeriodoMedicamento;
            vmAnterior.QuantidadeMedicamento = cadastrarVM.QuantidadeMedicamento;

            cadastrarVM = vmAnterior;
        }

        if (acaoSubmit == "adicionarMedicamento") {
            var medicamentoSelecionado = repositorioMedicamento.SelecionarRegistroPorId(cadastrarVM.MedicamentoId);

            var detalhesMedicamentoPrescritoVM = new DetalhesMedicamentoPrescritoViewModel(cadastrarVM.MedicamentoId, medicamentoSelecionado.Nome, cadastrarVM.DosagemMedicamento,
                                                                                          cadastrarVM.PeriodoMedicamento, cadastrarVM.QuantidadeMedicamento);

            cadastrarVM.MedicamentosPrescritos.Add(detalhesMedicamentoPrescritoVM);

            TempData["Prescricao"] = JsonSerializer.Serialize(cadastrarVM);

            return RedirectToAction("Cadastrar");
        }

        else if (acaoSubmit == "limpar") {
            TempData.Remove("Prescricao");

            return RedirectToAction("Cadastrar");
        }

        else {
            var novoRegistro = cadastrarVM.ParaEntidade(pacientes, medicamentos);

            repositorioPrescricao.CadastrarRegistro(novoRegistro);

            NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
                "Prescrição Cadastrada!",
                "A prescrição foi criada com sucesso!"
            );

            TempData.Remove("Prescricao");

            return View("Notificacao", notificacaoVM);
        }
    }


    [HttpGet("visualizar")]
    public IActionResult Visualizar() {
        var registros = repositorioPrescricao.SelecionarRegistros();

        var visualizarVM = new VisualizarPrescricoesViewModel(registros);

        return View(visualizarVM);
    }
}