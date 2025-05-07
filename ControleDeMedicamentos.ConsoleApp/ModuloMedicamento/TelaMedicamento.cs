using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;


namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento : TelaBase<Medicamento>, ITelaCrud
    {
        int quantidade;


        
        private IRepositorioMedicamento repositorioMedicamento;
        public TelaFornecedor telaFornecedor;
        public TelaMedicamento(IRepositorioMedicamento repositorioMedicamento, TelaFornecedor telaFornecedor) : base("Medicamento", repositorioMedicamento)
        {
            this.repositorioMedicamento = repositorioMedicamento;
            this.telaFornecedor = telaFornecedor;
        }

        
        public override Medicamento ObterDados()
        {
            Console.Write("Digite o Nome do medicamento: ");
            string nomeMedicamento = Console.ReadLine()!;

            Console.Write("Digite a Descrição do medicamento: ");
            string descricao = Console.ReadLine()!;

            Console.WriteLine("Digite a quantidade do medicamento: ");
            quantidade = Convert.ToInt32(Console.ReadLine());

            telaFornecedor.VisualizarRegistros(false);
            Console.WriteLine("Digite o ID do Fornecedor: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());

            Fornecedor fornecedor = telaFornecedor.repositorioFornecedor.SelecionarRegistroPorId(idFornecedor);
            
            Medicamento medicamento = new Medicamento(nomeMedicamento, descricao, quantidade, fornecedor);

            return medicamento;
        }

        public override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -15} | {4, -30}",
                "Id", "Medicamento", "Descricao", "Quantidade","Nome Fornecedor");
        }

        public override void ExibirLinhaTabela(Medicamento medicamento)
        {
            
            Console.WriteLine("{0, -10} | {1, -30} | {2,-20} | {3, -15} | {4, -30}", 
                medicamento.Id, medicamento.NomeMedicamento, medicamento.Descricao, medicamento.Quantidade, medicamento.Fornecedor.NomeFornecedor);
        }

        
    }
}
