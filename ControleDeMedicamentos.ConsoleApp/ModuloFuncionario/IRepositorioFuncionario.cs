using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
    public interface IRepositorioFuncionario : IRepositorio<Funcionario>
    {
        bool CpfEstaDuplicado(Funcionario funcionario);
    }

