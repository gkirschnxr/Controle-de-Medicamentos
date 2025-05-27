using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Extensions;

public static class MedicamentoExtensions {
    public static DetalhesMedicamentoViewModel ParaDetalhesVM(this Medicamento m) {
        return new DetalhesMedicamentoViewModel(m.Id, m.Nome!, m.Descricao!,
                                               m.Fornecedor!.Nome, m.QuantidadeTotal, m.EmFalta);
    
    }


}
