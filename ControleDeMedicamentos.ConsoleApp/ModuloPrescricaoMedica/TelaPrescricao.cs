using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.Util;
using Microsoft.Win32;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

public class TelaPrescricao : TelaBase<Prescricao>, ITelaCrud
{
    IRepositorioMedicamento repositorioMedicamento;
    public TelaPrescricao (IRepositorioPrescricao repositorio, IRepositorioMedicamento repositorioMedicamento)
        : base("Prescricao", repositorio)
    {
        this.repositorioMedicamento = repositorioMedicamento;
    }

    public override Prescricao ObterDados()
    {
        Console.Write("Digite o seu CRM: ");
        string crm = Console.ReadLine()!;

        Console.WriteLine();

        ExibirCabecalhoTabelaMedicamento(); 

        List<Medicamento> medicamentos = repositorioMedicamento.SelecionarRegistros();

        foreach (var medicamento in medicamentos)
        {
            ExibirLinhaTabelaMedicamento(medicamento);
        }

        Console.WriteLine();

        Console.Write("Digite o ID do medicamento: ");
        int idMedicamento = Convert.ToInt32(Console.ReadLine() ?? "0");

        Medicamento medicamentoSelecionado = repositorioMedicamento.SelecionarRegistroPorId(idMedicamento);
        if (medicamentoSelecionado == null)
        {
            Notificador.ExibirMensagem("Medicamento não encontrado!", ConsoleColor.Red);

            return ObterDados();
        }

        Prescricao novaPrescricao = new Prescricao(crm, DateTime.Now);
        novaPrescricao.Medicamentos.Add(medicamentoSelecionado);

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
        Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}",
            registro.Id,
            registro.CRM,
            registro.DataPrescricao,
            CarregarMedicamentosEmString(registro));
    }

    public void ExibirCabecalhoTabelaMedicamento()
    {
        Console.WriteLine("{0, -10} | {1, -30} | {2, -20}",
            "Id", "Medicamento", "Descricao");
    }

    public void ExibirLinhaTabelaMedicamento(Medicamento medicamento)
    {
        Console.WriteLine("{0, -10} | {1, -30} | {2,-20}",
            medicamento.Id, medicamento.Nome, medicamento.Descricao);
    }

    public string CarregarMedicamentosEmString(Prescricao p)
    {
        return string.Join(", ", p.Medicamentos.Select(m => m.Nome));
    }

}
