
using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

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

        public bool CpfEstaDuplicado(Funcionario funcionario)
        {
            foreach (Funcionario f in SelecionarRegistros())
            {
                if (f.CPF == funcionario.CPF)
                    return true;
            }
            return false;
        }
    }
}
