﻿using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Models;

public abstract class FormularioMedicamentoViewModel {
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public Guid FornecedorId { get; set; }
    public List<SelecionarFornecedorViewModel> FornecedoresDisponiveis { get; set; }

    protected FormularioMedicamentoViewModel() {
        FornecedoresDisponiveis = new List<SelecionarFornecedorViewModel>();
    }
}

public class SelecionarFornecedorViewModel {
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public SelecionarFornecedorViewModel(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class CadastrarMedicamentoViewModel : FormularioMedicamentoViewModel {
    public CadastrarMedicamentoViewModel() { }
    public CadastrarMedicamentoViewModel(List<Fornecedor> fornecedores)
    {
        foreach (var f in fornecedores)
        {
            var selecionarVM = new SelecionarFornecedorViewModel(f.Id, f.Nome);

            FornecedoresDisponiveis.Add(selecionarVM);
        }
    }
}

public class VisualizarMedicamentoViewModel {
    public List<DetalhesMedicamentoViewModel> Registros { get; }

    public VisualizarMedicamentoViewModel(List<Medicamento> medicamentos) {
        Registros = new List<DetalhesMedicamentoViewModel>();

        foreach (var m in medicamentos) {
            var detalhesVM = m.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class EditarMedicamentoViewModel : FormularioMedicamentoViewModel {
    public Guid Id { get; set; }

    public EditarMedicamentoViewModel() { }
    public EditarMedicamentoViewModel(Guid id, string nome, string descricao,
                                     Guid fornecedorId, List<Fornecedor> fornecedores) {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        FornecedorId = fornecedorId;

        foreach (var f in fornecedores) {
            var selecionarVM = new SelecionarFornecedorViewModel(f.Id, f.Nome);

            FornecedoresDisponiveis.Add(selecionarVM);
        }
    }
}

public class ExcluirMedicamentoViewModel {
    public Guid Id { get; set; } 
    public string Nome { get; set; } = string.Empty;

    public ExcluirMedicamentoViewModel() { }
    public ExcluirMedicamentoViewModel(Guid id, string nome) {
        Id = id;
        Nome = nome;
    }
}

public class DetalhesMedicamentoViewModel {
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string NomeFornecedor { get; set; }
    public int QuantidadeTotal { get; set; }
    public bool EmFalta { get; set; }

    public DetalhesMedicamentoViewModel(Guid id, string nome, string descricao, string nomeFornecedor, int quantidade, bool emFalta)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        NomeFornecedor = nomeFornecedor;
        QuantidadeTotal = quantidade;
        EmFalta = emFalta;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Nome: {Nome}, Descricao: {Descricao}, Fornecedor: {NomeFornecedor}, Quantidade no Estoque: {QuantidadeTotal}, Em falta? {EmFalta}";
    }
}