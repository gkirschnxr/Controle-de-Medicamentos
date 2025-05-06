using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento : TelaBase<Medicamento>, ITelaCrud
    {
        public TelaMedicamento(IRepositorioMedicamento repositorio) : base("Medicamento", repositorio)
        {
        }
        public override Medicamento ObterDados()
        {
            Console.Write("Digite o Nome do medicamento: ");
            string nomeMedicamento = Console.ReadLine()!;

            Console.Write("Digite a Descrição do medicamento: ");
            string descricao = Console.ReadLine()!;

            Console.Write("Digite a quantidade do medicamento: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

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
