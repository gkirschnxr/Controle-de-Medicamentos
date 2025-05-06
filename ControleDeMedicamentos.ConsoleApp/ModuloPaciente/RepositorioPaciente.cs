using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;


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
    public bool CartaoSusDuplicado(Paciente paciente)
    {
        foreach (Paciente p in SelecionarRegistros())
        {
            if (p.CartaoSus == paciente.CartaoSus)
                return true;
        }
        return false;
    }

   
}
