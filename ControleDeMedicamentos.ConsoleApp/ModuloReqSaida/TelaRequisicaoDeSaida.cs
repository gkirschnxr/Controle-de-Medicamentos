using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;
using ControleDeMedicamentos.ConsoleApp.Util;
using Microsoft.Win32;

namespace ControleDeMedicamentos.ConsoleApp.ModuloReqSaida;

public class TelaRequisicaoDeSaida : TelaBase<RequisicaoDeSaida>, ITelaCrud
{
    IRepositorioPaciente repositorioPaciente;
    IRepositorioPrescricao repositorioPrescricao;
    IRepositorioMedicamento repositorioMedicamento;

    private readonly string telefone;

    public TelaRequisicaoDeSaida (IRepositorioRequisicaoDeSaida repositorio, IRepositorioPaciente repositorioPaciente,
                                  IRepositorioPrescricao repositorioPrescricao, IRepositorioMedicamento repositorioMedicamento)
                                 : base("Requisição de Saída", repositorio)
    {
        this.repositorioPaciente = repositorioPaciente;
        this.repositorioPrescricao = repositorioPrescricao;
        this.repositorioMedicamento = repositorioMedicamento;
    }

    public override RequisicaoDeSaida ObterDados()
    {
        Console.WriteLine($"Data da requisição de saída: {DateTime.Now}");

        Console.WriteLine();

        ExibirCabecalhoTabelaPaciente();

        List<Paciente> pacientes = repositorioPaciente.SelecionarRegistros();

        foreach (var paciente in pacientes)
        {
            ExibirLinhaTabelaPaciente(paciente, telefone);
        }

        Console.WriteLine();

        Console.Write("Digite o ID do paciente: ");
        int idPaciente = Convert.ToInt32(Console.ReadLine() ?? "0");

        Console.WriteLine();

        ExibirCabecalhoTabelaPrescricao();

        List<Prescricao> prescricoes = repositorioPrescricao.SelecionarRegistros();

        foreach (var prescricao in prescricoes)
        {
            ExibirLinhaTabelaPrescricao(prescricao);
        }

        Console.WriteLine();

        Console.Write("Digite o ID da prescrição médica: ");
        int idPrescricao = Convert.ToInt32(Console.ReadLine() ?? "0");

        Console.WriteLine();

        ExibirCabecalhoTabelaMedicamento();

        List<Medicamento> medicamentos = repositorioMedicamento.SelecionarRegistros();

        foreach (var medicamento in medicamentos)
        {
            ExibirLinhaTabelaMedicamento(medicamento);
        }

        Console.WriteLine();

        Console.Write("Digite o ID da prescrição: ");
        int idPrescrição = Convert.ToInt32(Console.ReadLine() ?? "0");

        Console.WriteLine();

        RequisicaoDeSaida novaRequisicao = new RequisicaoDeSaida(DateTime.Now);

        return novaRequisicao;
    }

    public override void ExibirCabecalhoTabela()
    {
        Console.WriteLine(
             "{0, -6} | {1, -25} | {2, -20} | {3, -20}",
             "ID", "Paciente", "Prescricao", "Medicamentos"
        );
    }
    public override void ExibirLinhaTabela(RequisicaoDeSaida registro)
    {
        Console.WriteLine(
            "{0, -6} | {1, -25} | {2, -20} | {3, -20}",
            registro.Id, registro.Paciente, registro.Prescricao, registro.Medicamentos
        );
    }

    public void ExibirCabecalhoTabelaPaciente()
    {
        Console.WriteLine(
            "{0, -6} | {1, -25} | {2, -20} | {3, -20}",
            "ID", "Nome", "Telefone", "Cartão do SUS"
        );
    }
    public void ExibirLinhaTabelaPaciente(Paciente registro, string telefone)
    {
        Console.WriteLine(
            "{0, -6} | {1, -25} | {2, -20} | {3, -20}",
            registro.Id, registro.Nome, registro.FormatarTelefone(telefone), registro.CartaoSus
        );
    }

    public void ExibirCabecalhoTabelaPrescricao()
    {
        Console.WriteLine(
            "{0, -10} | {1, -12} | {2, -20} | {3, -20}",
            "ID", "CRM", "Data", "Lista de Medicamentos"
        );
    }
    public void ExibirLinhaTabelaPrescricao(Prescricao registro)
    {
        Console.WriteLine(
            "{0, -10} | {1, -12} | {2, -20} | {3, -20}",
             registro.Id, registro.CRM, registro.DataPrescricao, registro.Medicamentos.Count
        );
    }

    public void ExibirCabecalhoTabelaMedicamento()
    {
        Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -30}",
            "Id", "Medicamento", "Descricao", "Quantidade");
    }
    public void ExibirLinhaTabelaMedicamento(Medicamento medicamento)
    {
        Console.WriteLine("{0, -10} | {1, -30} | {2,-20} | {3, -30}",
            medicamento.Id, medicamento.NomeMedicamento, medicamento.Descricao, medicamento.Quantidade);
    }

    public override void VisualizarRegistros(bool exibirTitulo)
    {
        if (exibirTitulo)
            ExibirCabecalho();

        Console.WriteLine($"Visualizando {nomeEntidade}s...");
        Console.WriteLine("------------------------------------\n");

        ExibirCabecalhoTabela();

        List<RequisicaoDeSaida> registros = repositorio.SelecionarRegistros();

        foreach (RequisicaoDeSaida registro in registros)
            ExibirLinhaTabela(registro);



        Notificador.ExibirMensagem("\nPressione ENTER para continuar...", ConsoleColor.Yellow);
    }

}
