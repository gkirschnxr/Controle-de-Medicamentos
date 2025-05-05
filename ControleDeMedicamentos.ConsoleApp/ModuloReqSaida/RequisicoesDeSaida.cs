using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

namespace ControleDeMedicamentos.ConsoleApp.ModuloReqSaida;

public class RequisicoesDeSaida : EntidadeBase<RequisicoesDeSaida>
{
    public DateTime DataRequisicaoSaida { get; set; }
    public Paciente Paciente { get; set; }
    public Prescricao Prescricao { get; set; }
    public Medicamento Medicamentos { get; set; }

    public RequisicoesDeSaida() { }

    public RequisicoesDeSaida (DateTime dataRequisicaoSaida, Paciente paciente, Prescricao prescricao, Medicamento medicamentos)
    {
        DataRequisicaoSaida = dataRequisicaoSaida;
        Paciente = paciente;
        Prescricao = prescricao;
        Medicamentos = medicamentos;
    }

    public override void AtualizarRegistro(RequisicoesDeSaida registroEditado)
    {
        DataRequisicaoSaida = registroEditado.DataRequisicaoSaida;
    }

    public override string Validar()
    {
        string erros = "";

        if (DataRequisicaoSaida > DateTime.Now)
            erros += "O campo 'Data Requisição de Saída' deve conter uma data passada.\n";

        return erros;
    }
}
