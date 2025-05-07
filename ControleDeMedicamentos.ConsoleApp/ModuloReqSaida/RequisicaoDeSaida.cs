using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

namespace ControleDeMedicamentos.ConsoleApp.ModuloReqSaida;

public class RequisicaoDeSaida : EntidadeBase<RequisicaoDeSaida>
{
    public DateTime DataRequisicaoSaida { get; set; }
    public Paciente Paciente { get; set; }
    public Prescricao Prescricao { get; set; }
    public List<Medicamento> Medicamentos { get; set; }

    public RequisicaoDeSaida()
    {
        Medicamentos = new List<Medicamento>();
    }

    public RequisicaoDeSaida (Paciente paciente, Prescricao prescricao) : this()
    {
        DataRequisicaoSaida = DateTime.Now;
        Paciente = paciente;
        Prescricao = prescricao;
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
