using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
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

    public override void EditarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine($"Editando {nomeEntidade}...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idRegistro = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Paciente pacienteExistente = repositorio.SelecionarRegistroPorId(idRegistro);

        if (pacienteExistente == null)
        {
            Notificador.ExibirMensagem("Paciente não encontrado!", ConsoleColor.Red);
            return;
        }

        Paciente registroEditado = ObterDados(pacienteExistente.CartaoSus);

        string erros = registroEditado.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);

            EditarRegistro();

            return;
        }

        bool conseguiuEditar = repositorio.EditarRegistro(idRegistro, registroEditado);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Houve um erro durante a edição do registro...", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("O registro foi editado com sucesso!", ConsoleColor.Green);
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

    public Paciente ObterDados(string cartaoSusExistente)
    {
        Console.Write("Digite o Nome do paciente: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite o Telefone do paciente: ");
        string telefone = Console.ReadLine()!;

        Console.WriteLine($"Cartão SUS atual (não pode ser alterado): {cartaoSusExistente}");

        return new Paciente(nome, telefone, cartaoSusExistente);
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
            registro.Id, registro.NomePaciente, registro.Telefone, registro.ObterCartaoSusFormatado()
        );
    }

    public void ExibirPacientes(Paciente registro)
    {
        ExibirCabecalhoTabela();
        ExibirLinhaTabela(registro);
    }
}
