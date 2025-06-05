using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoEntrada;

namespace ControleDeMedicamentos.ConsoleApp.Extensions;

public static class RequisicaoEntradaExtensions
{
    public static RequisicaoDeEntrada ParaEntidade(this CadastrarRequisicaoEntradaViewModel formularioVM,
                                                List<Funcionario> funcionarios, List<Medicamento> medicamentos) {
        Funcionario funcionarioSelecionado = null!;

        foreach (var f in funcionarios)
        {
            if (f.Id == formularioVM.FuncionarioId)
                funcionarioSelecionado = f;
        }

        Medicamento medicamentoSelecionado = null!;

        foreach (var m in medicamentos)
        {
            if (m.Id == formularioVM.MedicamentoId)
                medicamentoSelecionado = m;
        }

        return new RequisicaoDeEntrada(funcionarioSelecionado, medicamentoSelecionado, formularioVM.QuantidadeRequisitada);
    }
}
