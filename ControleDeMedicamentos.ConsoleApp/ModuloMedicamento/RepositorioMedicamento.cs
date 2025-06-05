using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

public class RepositorioMedicamento : RepositorioBase<Medicamento>, IRepositorioMedicamento
{
    public RepositorioMedicamento(ContextoDeDados contexto) : base(contexto) { }

    protected override List<Medicamento> ObterRegistros() {
        return contexto.Medicamentos;
    }    
}