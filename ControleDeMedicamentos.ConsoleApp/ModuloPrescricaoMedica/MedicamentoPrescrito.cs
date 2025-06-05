using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System.Diagnostics.CodeAnalysis;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;

public class MedicamentoPrescrito
{
    public Guid Id { get; set; }
    public Medicamento Medicamento { get; set; } = null!;
    public string Dosagem { get; set; } = string.Empty;
    public string Periodo { get; set; } = string.Empty;
    public int Quantidade { get; set; }

    [ExcludeFromCodeCoverage]
    public MedicamentoPrescrito() { }

    public MedicamentoPrescrito(Medicamento medicamento, string dosagem, 
                               string periodo, int quantidade) {
        Id = Guid.NewGuid();
        Medicamento = medicamento;
        Dosagem = dosagem;
        Periodo = periodo;
        Quantidade = quantidade;
    }
}