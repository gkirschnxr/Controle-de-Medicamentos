using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;

public interface IRepositorioPrescricao
{
    public void CadastrarRegistro(Prescricao novoRegistro);
    public List<Prescricao> SelecionarRegistros();
}

public class RepositorioPrescricao : IRepositorioPrescricao
{
    private ContextoDeDados contexto;
    private List<Prescricao> registros = new List<Prescricao>();

    public RepositorioPrescricao(ContextoDeDados contexto) {
        this.contexto = contexto;
        registros = contexto.Prescricao;
    }

    public void CadastrarRegistro(Prescricao novoRegistro) {
        registros.Add(novoRegistro);

        contexto.Salvar();
    }

    public List<Prescricao> SelecionarRegistros() {
        return registros;
    }
}