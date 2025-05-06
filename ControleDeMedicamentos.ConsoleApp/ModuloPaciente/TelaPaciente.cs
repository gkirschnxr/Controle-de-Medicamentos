using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.Util;


namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public class TelaPaciente : TelaBase<Paciente>, ITelaCrud
{
    IRepositorioPaciente repositorioPaciente;
    public TelaPaciente(IRepositorioPaciente repositorioPaciente) : base("Paciente", repositorioPaciente)
    {
        this.repositorioPaciente = repositorioPaciente;
    }
    public override void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine($"Cadastrando {nomeEntidade}...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Paciente novoRegistro = ObterDados();

        string erros = novoRegistro.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);
            CadastrarRegistro();

            return;
        }

        bool cartaoSusDuplicado = repositorioPaciente.CartaoSusDuplicado(novoRegistro);

        if (cartaoSusDuplicado)
        {

            Notificador.ExibirMensagem("Este CARTÃO SUS já está cadastrado", ConsoleColor.Red);

            CadastrarRegistro();
            return;
        }

        repositorio.CadastrarRegistro(novoRegistro);

        Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
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
            registro.Id, registro.Nome, registro.Telefone, registro.ObterCartaoSusFormatado()
        );
    }

    public void ExibirPacientes(Paciente registro)
    {
        ExibirCabecalhoTabela();
        ExibirLinhaTabela(registro);
    }
}
