using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento : TelaBase<Medicamento>, ITelaCrud
    {
        int quantidade;

        private IRepositorioMedicamento repositorioMedicamento;
        public TelaMedicamento(IRepositorioMedicamento repositorioMedicamento) : base("Medicamento", repositorioMedicamento)
        {
            this.repositorioMedicamento = repositorioMedicamento;
        }

        
        public override Medicamento ObterDados()
        {
            Console.WriteLine("Digite o Nome do medicamento: ");
            string nomeMedicamento = Console.ReadLine()!;

            Console.WriteLine("Digite a Descrição do medicamento: ");
            string descricao = Console.ReadLine()!;

            Console.WriteLine("Digite a quantidade do medicamento: ");
            quantidade = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamento = new Medicamento(nomeMedicamento, descricao, quantidade);

            return medicamento;
        }

        public override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -30}",
                "Id", "Medicamento", "Descricao", "Quantidade");
        }

        public override void ExibirLinhaTabela(Medicamento medicamento)
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2,-20} | {3, -30}", 
                medicamento.Id, medicamento.NomeMedicamento, medicamento.Descricao, medicamento.Quantidade);
        }

        
    }
}
