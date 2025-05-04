using ControleDeMedicamentos.ConsoleApp.Compartilhado;


namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public class RepositorioPaciente : RepositorioBase<Paciente>, IRepositorioPaciente
{
    public RepositorioPaciente(ContextoDeDados contexto) : base(contexto)
    {
    }

    protected override List<Paciente> ObterRegistros()
    {
        return contexto.Pacientes;
    }
}
