using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

public class RepositorioPrescricao : RepositorioBase<Prescricao>, IRepositorioPrescricao
{
    public RepositorioPrescricao(ContextoDeDados contexto) : base(contexto)
    {
    }

    protected override List<Prescricao> ObterRegistros()
    {
        return contexto.Prescricao;
    }
}
