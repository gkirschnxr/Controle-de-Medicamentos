using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

namespace ControleDeMedicamentos.ConsoleApp.ModuloReqSaida;

public class RequisicaoDeSaida
{
    public Guid Id { get; set; }
    public DateTime DataRequisicaoSaida { get; set; }
    public Paciente Paciente { get; set; }
    public Prescricao Prescricao { get; set; }
    public Medicamento Medicamentos { get; set; }
    public int QuantidadeRequisita { get; set; }

    public RequisicaoDeSaida() { }

    public RequisicaoDeSaida (Paciente paciente, Prescricao prescricao, Medicamento medicamento, int quantidadeRequisita) : this()
    {
        Id = Guid.NewGuid();
        DataRequisicaoSaida = DateTime.Now;
        Paciente = paciente;
        Prescricao = prescricao;
        Medicamentos = medicamento;
        QuantidadeRequisita = quantidadeRequisita;
    }

    public string Validar()
    {
        string erros = "";

        if (Paciente == null)
            erros += "O campo 'Paciente' é obrigatório. \n";

        if (Prescricao == null)
            erros += "O campo 'Prescricao' é obrigatório. \n";

        if (Medicamentos == null)
            erros += "O campo 'Medicamentos' é obrigatório. \n";

        if (QuantidadeRequisita < 1)
            erros += "A requisição deve conter um valor positivo.\n";

        if (QuantidadeRequisita > Medicamentos.QuantidadeTotal)
            erros += "A quantidade solicitada não pode ser maior que a quantidade em estoque.\n";

        return erros;
    }
}
