using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoSaida;

namespace ControleDeMedicamentos.ConsoleApp.Models;

public class CadastrarRequisicaoEntradaViewModel
{
    public Guid MedicamentoId { get; set; }
    public Guid FuncionarioId { get; set; }
    public int QuantidadeRequisitada { get; set; }
    public List<SelecionarFuncionarioViewModel> FuncionariosDisponiveis { get; set; } = new List<SelecionarFuncionarioViewModel>();

    public CadastrarRequisicaoEntradaViewModel() { }

    public CadastrarRequisicaoEntradaViewModel(Guid medicamentoId, List<Funcionario> funcionarios) {
        MedicamentoId = medicamentoId;
        FuncionariosDisponiveis = new List<SelecionarFuncionarioViewModel>();

        foreach (var f in funcionarios) {
            var selecionarVM = new SelecionarFuncionarioViewModel(f.Id, f.NomeFuncionario);

            FuncionariosDisponiveis.Add(selecionarVM);
        }
    }
}

public class CadastrarRequisicaoSaidaViewModel
{
    public Guid FuncionarioId { get; set; }
    public Guid PacienteId { get; set; }
    public List<SelecionarFuncionarioViewModel> FuncionariosDisponiveis { get; set; } = new List<SelecionarFuncionarioViewModel>();
    public List<SelecionarPacienteViewModel> PacientesDisponiveis { get; set; } = new List<SelecionarPacienteViewModel>();

    public CadastrarRequisicaoSaidaViewModel() { }

    public CadastrarRequisicaoSaidaViewModel(List<Funcionario> funcionarios, List<Paciente> pacientes) {
        FuncionariosDisponiveis = new List<SelecionarFuncionarioViewModel>();

        foreach (var p in funcionarios) {
            var selecionarVM = new SelecionarFuncionarioViewModel(p.Id, p.NomeFuncionario);

            FuncionariosDisponiveis.Add(selecionarVM);
        }

        PacientesDisponiveis = new List<SelecionarPacienteViewModel>();

        foreach (var p in pacientes) {
            var selecionarVM = new SelecionarPacienteViewModel(p.Id, p.NomePaciente);

            PacientesDisponiveis.Add(selecionarVM);
        }
    }
}

public class CadastrarRequisicaoSaidaCompletaViewModel
{
    public Guid FuncionarioId { get; set; }
    public string NomeFuncionario { get; set; } = string.Empty;
    public Guid PacienteId { get; set; }
    public string NomePaciente { get; set; } = string.Empty;
    public Guid PrescricaoId { get; set; }
    public List<SelecionarPrescricaoViewModel> PrescricoesDisponiveis { get; set; } = new List<SelecionarPrescricaoViewModel>();

    public CadastrarRequisicaoSaidaCompletaViewModel() { }

    public CadastrarRequisicaoSaidaCompletaViewModel(Funcionario funcionario, Paciente paciente,
                                                    List<Prescricao> prescricoes) : this() {
        FuncionarioId = funcionario.Id;
        NomeFuncionario = funcionario.NomeFuncionario;
        PacienteId = paciente.Id;
        NomePaciente = paciente.NomePaciente;
        PrescricoesDisponiveis = new List<SelecionarPrescricaoViewModel>();

        foreach (var p in prescricoes) {
            var selecionarVM = new SelecionarPrescricaoViewModel(
                p.Id,
                p.Paciente.NomePaciente,
                p.DataPrescricao,
                p.MedicamentosPrescritos
            );
            PrescricoesDisponiveis.Add(selecionarVM);
        }
    }
}

public class VisualizarRequisicoesSaidaViewModel
{
    public List<DetalhesRequisicaoSaidaViewModel> Registros { get; }

    public VisualizarRequisicoesSaidaViewModel(List<RequisicaoDeSaida> requisicoes) {
        Registros = [];

        foreach (var r in requisicoes) {
            var detalhesVM = r.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesRequisicaoSaidaViewModel
{
    public Guid Id { get; set; }
    public string FuncionarioRequisitante { get; set; }
    public string Paciente { get; set; }
    public DateTime DataOcorrencia { get; set; }
    public List<string> MedicamentoPrescrito { get; set; }

    public DetalhesRequisicaoSaidaViewModel(Guid id, string funcionarioRequisitante, string paciente,
                                           DateTime dataOcorrencia, List<MedicamentoPrescrito> medicamentosPrescritos) {
        Id = id;
        FuncionarioRequisitante = funcionarioRequisitante;
        Paciente = paciente;
        DataOcorrencia = dataOcorrencia;
        MedicamentoPrescrito = new List<string>();

        foreach (var m in medicamentosPrescritos) {
            
            if (m.Medicamento != null) {
                MedicamentoPrescrito.Add(m.Medicamento.Nome);
            }
        }
    }
}

public class SelecionarFuncionarioViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public SelecionarFuncionarioViewModel(Guid id, string nome) {
        Id = id;
        Nome = nome;
    }
}

public class SelecionarPacienteViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public SelecionarPacienteViewModel(Guid id, string nome) {
        Id = id;
        Nome = nome;
    }
}

public class SelecionarPrescricaoViewModel
{
    public Guid Id { get; set; }
    public string NomePaciente { get; set; } = string.Empty;
    public DateTime DataEmissao { get; set; }
    public List<SelecionarMedicamentoPrescritoViewModel> MedicamentosPrescritos { get; set; } = new List<SelecionarMedicamentoPrescritoViewModel>();

    public SelecionarPrescricaoViewModel() { }

    public SelecionarPrescricaoViewModel(Guid id, string nomePaciente, DateTime dataEmissao,
                                        List<MedicamentoPrescrito> medicamentosPrescritos) : this() {
        Id = id;
        NomePaciente = nomePaciente;
        DataEmissao = dataEmissao;
        MedicamentosPrescritos = new List<SelecionarMedicamentoPrescritoViewModel>();

        foreach (var m in medicamentosPrescritos) {

            if (m.Medicamento != null) {
                var selecionarVM = new SelecionarMedicamentoPrescritoViewModel(m.Medicamento.Nome);

                MedicamentosPrescritos.Add(selecionarVM);
            }
        }
    }

    public override string ToString() {
        var nomesMedicamentos = string.Join(", ", MedicamentosPrescritos);

        return string.Join(" - ", $"Emissão: {DataEmissao.ToShortDateString()}", $"[{nomesMedicamentos}]");
    }
}

public class SelecionarMedicamentoPrescritoViewModel
{
    public string Nome { get; set; }

    public SelecionarMedicamentoPrescritoViewModel(string nome) {
        Nome = nome;
    }

    public override string ToString() {
        return Nome;
    }
}