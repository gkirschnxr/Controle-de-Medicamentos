using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoSaida;

namespace ControleDeMedicamentos.ConsoleApp.Extensions;

public static class RequisicaoSaidaExtensions
{
    public static RequisicaoDeSaida ParaEntidade(this CadastrarRequisicaoSaidaCompletaViewModel formularioVM,
                                                List<Funcionario> funcionarios, List<Prescricao> prescricoes) {
        Funcionario funcionarioSelecionado = null!;

        foreach (var f in funcionarios) {
            
            if (f.Id == formularioVM.FuncionarioId)
                funcionarioSelecionado = f;
        }

        Prescricao prescricaoSelecionada = null!;

        foreach (var p in prescricoes) {
            
            if (p.Id == formularioVM.PrescricaoId)
                prescricaoSelecionada = p;
        }

        return new RequisicaoDeSaida(funcionarioSelecionado, prescricaoSelecionada);
    }

    public static DetalhesRequisicaoSaidaViewModel ParaDetalhesVM(this RequisicaoDeSaida requisicao) {
        
        return new DetalhesRequisicaoSaidaViewModel(requisicao.Id, requisicao.Funcionario.NomeFuncionario, requisicao.Prescricao.Paciente.NomePaciente,
                                                   requisicao.DataOcorrencia, requisicao.Prescricao.MedicamentosPrescritos);
    }
}