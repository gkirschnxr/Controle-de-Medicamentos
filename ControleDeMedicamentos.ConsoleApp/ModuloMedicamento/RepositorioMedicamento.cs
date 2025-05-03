using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

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
