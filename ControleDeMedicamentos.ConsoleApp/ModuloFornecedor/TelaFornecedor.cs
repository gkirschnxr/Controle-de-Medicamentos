using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class TelaFornecedor : TelaBase<Fornecedor>, ITelaCrud
    {
        private IRepositorioFornecedor repositorioFornecedor;

        public TelaFornecedor(IRepositorioFornecedor repositorio) : base("Fornecedor", repositorio)
        {

        }

       
        public override Fornecedor ObterDados()
        {
            Console.WriteLine("Digite o Nome do fornecedor");
            string nome = Console.ReadLine()!;
            
            Console.WriteLine("Digite o Telefone do fornecedor");
            string telefone = Console.ReadLine()!;

            Console.WriteLine("Digite o CNPJ do fornecedor");
            string cnpj = Console.ReadLine()!;

            Fornecedor fornecedor = new Fornecedor(nome, telefone, cnpj);

                return fornecedor;
        }

        public override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -30}", 
                "Id", "Nome", "Telefone", "CNPJ");
        }

        public override void ExibirLinhaTabela(Fornecedor fornecedor)
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2,-20} | {3, -30}", 
                fornecedor.Id, fornecedor.Nome, fornecedor.Telefone, fornecedor.CNJP);
        }
    }
}
