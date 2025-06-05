using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

namespace ControleDeMedicamentos.ConsoleApp.Models;

public class CadastrarPrescricaoViewModel
{
    public Guid PacienteId { get; set; }
    public List<SelecionarPacienteViewModel> PacientesDisponiveis { get; set; }

    public string CRM { get; set; } = string.Empty;

    public List<SelecionarMedicamentoViewModel> MedicamentosDisponiveis { get; set; }
    public List<DetalhesMedicamentoPrescritoViewModel> MedicamentosPrescritos { get; set; }

    public Guid MedicamentoId { get; set; }
    public string DosagemMedicamento { get; set; } = string.Empty;
    public string PeriodoMedicamento { get; set; } = string.Empty;
    public int QuantidadeMedicamento { get; set; } 

    public CadastrarPrescricaoViewModel() {
        PacientesDisponiveis = new List<SelecionarPacienteViewModel>();
        MedicamentosDisponiveis = new List<SelecionarMedicamentoViewModel>();
        MedicamentosPrescritos = new List<DetalhesMedicamentoPrescritoViewModel>();
    }

    public CadastrarPrescricaoViewModel(List<Paciente> pacientes, List<Medicamento> medicamentos) : this() {
        AdicionarPacientes(pacientes);
        AdicionarMedicamentos(medicamentos);
    }

    public void AdicionarPacientes(List<Paciente> pacientes) {
        
        foreach (var p in pacientes) {
            var selecionarPacienteVM = new SelecionarPacienteViewModel(p.Id, p.NomePaciente);

            PacientesDisponiveis.Add(selecionarPacienteVM);
        }
    }

    public void AdicionarMedicamentos(List<Medicamento> medicamentos) {
        
        foreach (var m in medicamentos) {
            var selecionarMedicamentoVM = new SelecionarMedicamentoViewModel(m.Id, m.Nome);

            MedicamentosDisponiveis.Add(selecionarMedicamentoVM);
        }
    }
}

public class SelecionarMedicamentoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public SelecionarMedicamentoViewModel() { }

    public SelecionarMedicamentoViewModel(Guid id, string nome) : this() {
        Id = id;
        Nome = nome;
    }
}

public class DetalhesMedicamentoPrescritoViewModel
{
    public Guid MedicamentoId { get; set; }
    public string Medicamento { get; set; } = string.Empty;
    public string Dosagem { get; set; } = string.Empty;
    public string Periodo { get; set; } = string.Empty;
    public int Quantidade { get; set; }

    public DetalhesMedicamentoPrescritoViewModel() { }

    public DetalhesMedicamentoPrescritoViewModel(Guid medicamentoId, string nomeMedicamento, string dosagem,
                                                string periodo, int quantidade) : this() {
        MedicamentoId = medicamentoId;
        Medicamento = nomeMedicamento;
        Dosagem = dosagem;
        Periodo = periodo;
        Quantidade = quantidade;
    }
}

public class VisualizarPrescricoesViewModel
{
    public List<DetalhesPrescricaoViewModel> Registros { get; }

    public VisualizarPrescricoesViewModel(List<Prescricao> prescricoes) {
        Registros = [];

        foreach (var p in prescricoes) {
            var detalhesVM = p.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesPrescricaoViewModel
{
    public Guid Id { get; set; }
    public string CRM { get; set; } = string.Empty;
    public string Paciente { get; set; } = string.Empty;
    public DateTime DataPrescricao { get; set; }
    public List<SelecionarMedicamentoPrescritoViewModel> MedicamentosPrescritos { get; set; }

    public DetalhesPrescricaoViewModel(Guid id, string crmMedico, string paciente,
                                      DateTime dataEmissao, List<MedicamentoPrescrito> medicamentoPrescritos) {
        Id = id;
        CRM = crmMedico;
        Paciente = paciente;
        DataPrescricao = dataEmissao;

        MedicamentosPrescritos = new List<SelecionarMedicamentoPrescritoViewModel>();

        foreach (var m in medicamentoPrescritos) {
            
            if (m.Medicamento != null) {
                var selecionarVM = new SelecionarMedicamentoPrescritoViewModel(m.Medicamento.Nome);
                MedicamentosPrescritos.Add(selecionarVM);
            }
        }
    }
}