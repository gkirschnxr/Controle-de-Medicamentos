using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Models;

public class VisualizarMedicamentoViewModel {
    public List<DetalhesMedicamentoViewModel> Registros { get; }

    public VisualizarMedicamentoViewModel(List<Medicamento> medicamentos) {
        Registros = new List<DetalhesMedicamentoViewModel>();

        foreach (var m in medicamentos) {
            var detalhesVM = m.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesMedicamentoViewModel {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Fornecedor { get; set; }
    public int QuantidadeTotal { get; set; }
    public bool EmFalta { get; set; }

    public DetalhesMedicamentoViewModel(int id, string nome, string descricao, string fornecedor, int quantidade, bool emFalta)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Fornecedor = fornecedor;
        QuantidadeTotal = quantidade;
        EmFalta = emFalta;
    }
}
