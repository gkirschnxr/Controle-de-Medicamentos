using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

namespace ControleDeMedicamentos.ConsoleApp.ModuloReqSaida;

public interface IRepositorioRequisicao
{
    public void CadastrarRequisicaoEntrada(RequisicaoDeEntrada requisicaoEntrada);
    public void CadastrarRequisicaoSaida(RequisicaoDeSaida requisicaoSaida);
}
