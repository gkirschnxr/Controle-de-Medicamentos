using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class TelaFornecedor : TelaBase<Fornecedor>, ITelaCrud
    {
        public string telefone;

        public TelaFornecedor(IRepositorioFornecedor repositorioFornecedor) : base("Fornecedor", repositorioFornecedor)
        {
            this.repositorioFornecedor = repositorioFornecedor;
        }

        public override void CadastrarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine();

            Console.WriteLine($"Cadastrando {nomeEntidade}...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            Fornecedor novoRegistro = ObterDados();

            string erros = novoRegistro.Validar();

            if (erros.Length > 0)
            {
                Notificador.ExibirMensagem(erros, ConsoleColor.Red);

                CadastrarRegistro();

                return;
            }

            bool cnpjDuplicado = repositorioFornecedor.CnpjEstaDuplicado(novoRegistro);

            if (cnpjDuplicado) 
            {
                
                Notificador.ExibirMensagem("Este CNPJ já está cadastrado", ConsoleColor.Red);

                CadastrarRegistro();
                return;
            }

            repositorio.CadastrarRegistro(novoRegistro);

            Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
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
