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

        // Seleção de paciente
        ExibirCabecalhoTabelaPaciente();
        List<Paciente> pacientes = repositorioPaciente.SelecionarRegistros();
        foreach (var paciente in pacientes)
            ExibirLinhaTabelaPaciente(paciente);

        Console.Write("\nDigite o ID do paciente: ");
        int idPaciente = Convert.ToInt32(Console.ReadLine());

        Paciente pacienteSelecionado = repositorioPaciente.SelecionarRegistroPorId(idPaciente);

        if (pacienteSelecionado == null)
        {
            Notificador.ExibirMensagem("Paciente não encontrado!", ConsoleColor.Red);
            return null;
        }

        // Seleção de prescrição
        Console.WriteLine();
        ExibirCabecalhoTabelaPrescricao();
        List<Prescricao> prescricoes = repositorioPrescricao.SelecionarRegistros();
        foreach (var prescricao in prescricoes)
            ExibirLinhaTabelaPrescricao(prescricao);

        Console.Write("\nDigite o ID da prescrição médica: ");
        int idPrescricao = Convert.ToInt32(Console.ReadLine());

        Prescricao prescricaoSelecionada = repositorioPrescricao.SelecionarRegistroPorId(idPrescricao);

        if (prescricaoSelecionada == null)
        {
            Notificador.ExibirMensagem("Prescrição não encontrada!", ConsoleColor.Red);
            return null!;
        }

        // Seleção de medicamento
        Console.WriteLine();
        ExibirCabecalhoTabelaMedicamento();
        List<Medicamento> medicamentos = repositorioMedicamento.SelecionarRegistros();
        foreach (var medicamento in medicamentos)
            ExibirLinhaTabelaMedicamento(medicamento);

        Console.Write("\nDigite o ID do medicamento: ");
        int idMedicamento = Convert.ToInt32(Console.ReadLine());

        Medicamento medicamentoSelecionado = repositorioMedicamento.SelecionarRegistroPorId(idMedicamento);

        if (medicamentoSelecionado == null)
        {
            Notificador.ExibirMensagem("Medicamento não encontrado!", ConsoleColor.Red);
            return null!;
        }

        Console.Write("Digite a quantidade a requisitar: ");
        int quantidade = Convert.ToInt32(Console.ReadLine());

        if (quantidade > medicamentoSelecionado.Quantidade)
        {
            Notificador.ExibirMensagem("Quantidade indisponível no estoque!", ConsoleColor.Red);
            return null!;
        }

        medicamentoSelecionado.Quantidade -= quantidade;

        RequisicaoDeSaida novaRequisicao = new RequisicaoDeSaida(pacienteSelecionado, prescricaoSelecionada)
        {
            Prescricao = prescricaoSelecionada,
            Paciente = pacienteSelecionado,
            DataRequisicaoSaida = DateTime.Now,
            Medicamentos = new List<Medicamento> { medicamentoSelecionado }
        };

        Notificador.ExibirMensagem("Requisição realizada com sucesso!", ConsoleColor.Green);
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

            registro.Id, registro.Paciente.NomePaciente, registro.Prescricao.DataPrescricao.ToShortDateString(), registro.Prescricao.Medicamentos.Count 
            //mostrar todos os medicamentos separados por virgula, trazer os medicamentos direto da prescricao

        );
    }

    public void ExibirCabecalhoTabelaPaciente()
    {
        Console.WriteLine(
            "{0, -6} | {1, -25} | {2, -20}",
            "ID", "Nome", "Cartão do SUS"
        );
    }
    public void ExibirLinhaTabelaPaciente(Paciente registro)
    {
        Console.WriteLine(
            "{0, -6} | {1, -25} | {2, -20}",
            registro.Id, registro.NomePaciente, registro.CartaoSus
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

}
