using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloReqSaida
{
    public class RepositorioRequisicaoDeSaida : RepositorioBase<RequisicaoDeSaida>, IRepositorioRequisicaoDeSaida
    {
        public RepositorioRequisicaoDeSaida(ContextoDeDados contexto) : base(contexto)
        {
        }

        protected override List<RequisicaoDeSaida> ObterRegistros()
        {
            return contexto.RequisicaoSaida;
        }
    }
}