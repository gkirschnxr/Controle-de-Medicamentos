using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoEntrada;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoSaida;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicao;

public class RepositorioRequisicao : IRepositorioRequisicao
{
    private ContextoDeDados contexto;
    private List<RequisicaoDeEntrada> requisicaoEntrada;
    private List<RequisicaoDeSaida> requisicaoSaida;

    public RepositorioRequisicao(ContextoDeDados contexto) {
        this.contexto = contexto;
        requisicaoEntrada = contexto.RequisicaoEntrada;
        requisicaoSaida = contexto.RequisicaoSaida;
    }

    public void CadastrarRequisicaoEntrada(RequisicaoDeEntrada requisicaoEntrada) {
        this.requisicaoEntrada.Add(requisicaoEntrada);

        contexto.Salvar();
    }

    public void CadastrarRequisicaoSaida(RequisicaoDeSaida requisicaoSaida) {
        this.requisicaoSaida.Add(requisicaoSaida);

        contexto.Salvar();
    }

    public List<RequisicaoDeSaida> SelecionarRequisicaoSaida() {
        return requisicaoSaida;
    }
}