using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using System.Collections.Generic;

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
