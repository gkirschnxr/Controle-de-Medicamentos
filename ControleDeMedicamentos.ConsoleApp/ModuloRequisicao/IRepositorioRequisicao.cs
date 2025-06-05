using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoSaida;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoEntrada;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicao;

public interface IRepositorioRequisicao {
    public void CadastrarRequisicaoEntrada(RequisicaoDeEntrada requisicaoEntrada);
    public void CadastrarRequisicaoSaida(RequisicaoDeSaida requisicaoSaida);
    public List<RequisicaoDeSaida> SelecionarRequisicaoSaida();
}