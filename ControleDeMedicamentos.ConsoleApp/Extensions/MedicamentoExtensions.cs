using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Extensions;

public static class MedicamentoExtensions {
    public static Medicamento ParaEntidade(this FormularioMedicamentoViewModel formularioVM,
                                           List<Fornecedor> fornecedores) {
        Fornecedor fornecedorSelecionado = null!;

        foreach (var f in fornecedores) {
            if (f.Id == formularioVM.FornecedorId)
                fornecedorSelecionado = f;
        }

        return new Medicamento(formularioVM.Nome, formularioVM.Descricao, fornecedorSelecionado);
    }

    public static DetalhesMedicamentoViewModel ParaDetalhesVM(this Medicamento m) {
        return new DetalhesMedicamentoViewModel(m.Id, m.Nome, m.Descricao,
                                               m.Fornecedor!.Nome, m.QuantidadeEmEstoque, m.EmFalta);
    
    }
}
