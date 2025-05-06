using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

namespace ControleDeMedicamentos.ConsoleApp.ModuloReqSaida;

public class RequisicaoDeSaida : EntidadeBase<RequisicaoDeSaida>
{
    public DateTime DataRequisicaoSaida { get; set; }
    public List<Paciente> Paciente { get; set; }
    public List<Prescricao> Prescricao { get; set; }
    public List<Medicamento> Medicamentos { get; set; }

    public RequisicaoDeSaida()
    {
        Paciente = new List<Paciente>();
        Prescricao = new List<Prescricao>();
        Medicamentos = new List<Medicamento>();
    }

    public RequisicaoDeSaida (DateTime dataRequisicaoSaida) : this()
    {
        DataRequisicaoSaida = dataRequisicaoSaida;
    }

    public override void AtualizarRegistro(RequisicaoDeSaida registroEditado)
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
