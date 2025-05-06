using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class TelaFuncionario : TelaBase<Funcionario>, ITelaCrud
    {

        private IRepositorioFuncionario repositorioFuncionario;

        string telefone { get; set; }
        public TelaFuncionario(IRepositorioFuncionario repositorio) : base("Funcionario", repositorio)
        {

        }

        public override Funcionario ObterDados()
        {
            Console.WriteLine("Digite o Nome do Funcionario: ");
            string nome = Console.ReadLine()!;

            Console.WriteLine("Digite o Telefone do Funcionario: ");
            telefone = Console.ReadLine()!;

            Console.WriteLine("Digite o CPF do Funcionario: ");
            string cpf = Console.ReadLine()!;

            Funcionario funcionario = new Funcionario(nome, telefone, cpf);

            return funcionario;
        }
        public override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -30}",
                "Id", "Nome", "Telefone", "CPF");
        }

        public override void ExibirLinhaTabela(Funcionario funcionario)
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2,-20} | {3, -30}",
            funcionario.Id, funcionario.Nome, funcionario.FormatarTelefone(telefone), funcionario.ObterCpfFormatado());
        }

        
    }
}
