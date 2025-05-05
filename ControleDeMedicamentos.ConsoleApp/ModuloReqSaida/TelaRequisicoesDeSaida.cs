using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

namespace ControleDeMedicamentos.ConsoleApp.ModuloReqSaida;

public class TelaRequisicoesDeSaida : TelaBase<RequisicoesDeSaida>, ITelaCrud
{
    public TelaRequisicoesDeSaida (IRepositorioRequisicaoDeSaida repositorio) : base("Requisição de Saída", repositorio)
    {
    }

    public override RequisicoesDeSaida ObterDados()
    {
        Console.WriteLine($"Data da requisição de saída: {DateTime.Now}");

        List<Paciente> pacientes = ObterPacientes();

        Console.WriteLine("Pacientes disponíveis:");
        foreach (var paciente in pacientes)
        {
            Console.WriteLine($"ID: {paciente.Id}, Nome: {paciente.Nome}");
        }

        Console.WriteLine();

        Console.Write("Digite o ID do paciente: ");
        int idPaciente = Convert.ToInt32(Console.ReadLine() ?? "0");

        Paciente pacienteSelecionado = pacientes.FirstOrDefault(paciente => paciente.Id == idPaciente)!;

        if (pacienteSelecionado == null)
        {
            Console.WriteLine("Paciente não encontrado. Operação cancelada.");
            return null!;
        }

        List<Medicamento> medicamentos = ObterMedicamentos();

        Console.WriteLine("Medicamentos disponíveis:");
        foreach (var medicamento in medicamentos)
        {
            Console.WriteLine($"ID: {medicamento.Id}, Nome: {medicamento.NomeMedicamento}");
        }

        Console.WriteLine();

        Console.Write("Digite o ID do medicamento: ");
        int idMedicamento = Convert.ToInt32(Console.ReadLine() ?? "0");

        Medicamento medicamentoSelecionado = medicamentos.FirstOrDefault(medicamento => medicamento.Id == idMedicamento)!;

        if (medicamentoSelecionado == null)
        {
            Console.WriteLine("Medicamento não encontrado. Operação cancelada.");
            return null!;
        }

        List<Prescricao> prescricoes = ObterPrescricoes();

        Console.WriteLine("Prescrições disponíveis:");
        foreach (var prescricao in prescricoes)
        {
            Console.WriteLine($"ID: {prescricao.Id}, CRM {prescricao.CRM}, Nome: {prescricao.Medicamentos}");
        }

        Console.WriteLine();

        Console.Write("Digite o ID da prescrição: ");
        int idPrescrição = Convert.ToInt32(Console.ReadLine() ?? "0");

        Prescricao prescricaoSelecionada = prescricoes.FirstOrDefault(prescricoes => prescricoes.Id == idPrescrição)!;

        if (prescricaoSelecionada == null)
        {
            Console.WriteLine("Medicamento não encontrado. Operação cancelada.");
            return null!;
        }

        RequisicoesDeSaida novaRequisicao = new RequisicoesDeSaida(DateTime.Now, pacienteSelecionado, prescricaoSelecionada, medicamentoSelecionado);

        return novaRequisicao;
    }

    private List<Medicamento> ObterMedicamentos()
    {
        return new List<Medicamento>();
    }
    private List<Prescricao> ObterPrescricoes()
    {
        return new List<Prescricao>();
    }

    private List<Paciente> ObterPacientes()
    {
        return new List<Paciente>();
    }

    public override void ExibirCabecalhoTabela()
    {
        Console.WriteLine(
             "{0, -6} | {1, -25} | {2, -20} | {3, -20}",
             "ID", "Paciente", "Prescricao", "Medicamentos"
        );
    }
    public override void ExibirLinhaTabela(RequisicoesDeSaida registro)
    {
        Console.WriteLine(
            "{0, -6} | {1, -25} | {2, -20} | {3, -20}",
            registro.Id, registro.Paciente, registro.Prescricao, registro.Medicamentos
        );
    }


}
