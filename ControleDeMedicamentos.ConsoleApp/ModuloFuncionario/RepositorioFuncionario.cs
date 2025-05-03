
using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBase<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionario(ContextoDeDados contexto) : base(contexto)
        {
        }

        protected override List<Funcionario> ObterRegistros()
        {
            return contexto.Funcionarios;
        }
    }
}
