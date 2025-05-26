using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class TelaFuncionario : TelaBase<Funcionario>, ITelaCrud
    {

        private IRepositorioFuncionario repositorioFuncionario;

        string? telefone { get; set; }
        string? cpf { get; set; }
        public TelaFuncionario(IRepositorioFuncionario repositorioFuncionario) : base("Funcionario", repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }
        public override void CadastrarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine();

            Console.WriteLine($"Cadastrando {nomeEntidade}...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            Funcionario novoRegistro = ObterDados();

            string erros = novoRegistro.Validar();

            if (erros.Length > 0)
            {
                Notificador.ExibirMensagem(erros, ConsoleColor.Red);
                CadastrarRegistro();

                return;
            }

            bool cpfDuplicado = repositorioFuncionario.CpfEstaDuplicado(novoRegistro);

            if (cpfDuplicado)
            {

                Notificador.ExibirMensagem("Este CPF já está cadastrado", ConsoleColor.Red);

                CadastrarRegistro();
                return;
            }

            repositorio.CadastrarRegistro(novoRegistro);

            Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
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
                "Id", "Nome", "Telefone");
        }

        public override void ExibirLinhaTabela(Funcionario funcionario)
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2,-20} | {3, -30}",
            funcionario.Id, funcionario.Nome, funcionario.FormatarTelefone(telefone!));
        }

        
    }
}
