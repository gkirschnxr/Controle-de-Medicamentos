using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class RepositorioMedicamento : RepositorioBase<Medicamento>, IRepositorioMedicamento
    {
        public RepositorioMedicamento(ContextoDeDados contexto) : base(contexto)
        {
        }

        protected override List<Medicamento> ObterRegistros()
        {
            return contexto.Medicamentos;
        }
        
    }
}
