using ControleDeMedicamentos.ConsoleApp.Compartilhado;


namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public class TelaPaciente : TelaBase<Paciente>, ITelaCrud
{
    public TelaPaciente(IRepositorioPaciente repositorio) : base("Paciente", repositorio)
    {
    }

    public override Paciente ObterDados()
    {
        Console.Write("Digite o nome do paciente: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o telefone do paciente: ");
        string telefone = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o número do Cartão SUS do paciente: ");
        string cartaoSus = Console.ReadLine() ?? string.Empty;

        Paciente paciente = new Paciente(nome, telefone, cartaoSus);

        return paciente;
    }

    public override void ExibirCabecalhoTabela()
    {
        Console.WriteLine(
            "{0, -6} | {1, -25} | {2, -20} | {3, -20}",
            "ID", "Nome", "Telefone", "Cartão do SUS"
        );
    }

    public override void ExibirLinhaTabela(Paciente registro)
    {
        Console.WriteLine(
            "{0, -6} | {1, -25} | {2, -20} | {3, -20}",
            registro.Id, registro.Nome, registro.Telefone, registro.CartaoSus
        );
    }
}
