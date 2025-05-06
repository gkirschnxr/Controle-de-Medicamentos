using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class TelaFornecedor : TelaBase<Fornecedor>, ITelaCrud
    {
        public string telefone;

        public TelaFornecedor(IRepositorioFornecedor repositorio) : base("Fornecedor", repositorio)
        {
        }
        
        public override Fornecedor ObterDados()
        {
            Console.Write("Digite o Nome do fornecedor: ");
            string nome = Console.ReadLine()!;
            
            Console.Write("Digite o Telefone do fornecedor: ");
            telefone = Console.ReadLine()!;

            Console.Write("Digite o CNPJ do fornecedor: ");
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
                fornecedor.Id, fornecedor.Nome, fornecedor.FormatarTelefone(telefone), fornecedor.ObterCnpjFormatado());
        }

        

    }
}
