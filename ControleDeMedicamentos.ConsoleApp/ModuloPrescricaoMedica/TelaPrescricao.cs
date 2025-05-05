using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

partial class TelaPrescricao : TelaBase<Prescricao>, ITelaCrud
{
    public TelaPrescricao (IRepositorioPrescricao repositorio) : base("Prescricao", repositorio)
    {
    }

    public override Prescricao ObterDados()
    {
        Console.Write("Digite o seu CRM: ");
        int crm = Convert.ToInt32(Console.ReadLine()!);

        Console.WriteLine();

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

        Prescricao novaPrescricao = new Prescricao(crm, DateTime.Now, medicamentoSelecionado);

        return novaPrescricao;
    }

    public override void ExibirCabecalhoTabela()
    {
        Console.WriteLine(
            "{0, -10} | {1, -12} | {2, -20} | {3, -20}",
            "ID", "CRM", "Data", "Lista de Medicamentos"
        );
    }

    public override void ExibirLinhaTabela(Prescricao registro)
    {
        Console.WriteLine(
            "{0, -10} | {1, -12} | {2, -20} | {3, -20}",
             registro.Id, registro.CRM, registro.DataPrescricao, registro.Medicamentos
        );
    }
    private List<Medicamento> ObterMedicamentos()
    {
        return new List<Medicamento>();
    }
}
