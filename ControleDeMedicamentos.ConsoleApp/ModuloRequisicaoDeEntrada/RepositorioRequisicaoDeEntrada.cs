using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloReqSaida;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeEntrada
{
    public class RepositorioRequisicaoDeEntrada : RepositorioBase<RequisicaoDeEntrada>, IRepositorioRequisicaoDeEntrada
    {
        public RepositorioRequisicaoDeEntrada(ContextoDeDados contexto) : base(contexto)
        {
        }

        protected override List<RequisicaoDeEntrada> ObterRegistros()
        {
            return contexto.RequisicaoEntrada;
        }
    }
}
