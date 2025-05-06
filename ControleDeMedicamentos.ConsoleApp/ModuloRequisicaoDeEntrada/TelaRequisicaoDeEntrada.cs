using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeEntrada
{
    public class TelaRequisicaoDeEntrada : TelaBase<RequisicaoDeEntrada>, ITelaCrud
    {
        public TelaRequisicaoDeEntrada(IRepositorioRequisicaoDeEntrada repositorio) : base("Requisição de Entrada", repositorio)
        {
        }

        public override RequisicaoDeEntrada ObterDados()
        {
            Console.WriteLine($"Data da requisição de Entrada: {DateTime.Now}");

            List<Funcionario> funcionarios = ObterFuncionario();

            Console.WriteLine("Funcionarios disponíveis: ");
            foreach (var funcionario in funcionarios)
            {
                Console.WriteLine($"ID: {funcionario.Id}, Nome: {funcionario.Nome}");
            }

            Console.WriteLine();

            Console.Write("Digite o ID do funcionario: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine() ?? "0");

            Funcionario funcionarioSelecionado = funcionarios.FirstOrDefault(funcionario => funcionario.Id == idFuncionario)!;

            if (funcionarioSelecionado == null)
            {
                Console.WriteLine("Funcionario não encontrado. Operação cancelada.");
                return null!;
            }

            List<Medicamento> medicamentos = ObterMedicamento();

            Console.WriteLine("Medicamentos disponíveis:");
            foreach (var medicamento in medicamentos)
            {
                Console.WriteLine($"ID: {medicamento.Id}, Nome: {medicamento.NomeMedicamento}");
            }

            Console.WriteLine();

            Console.Write("Digite o ID do medicamento: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine() ?? "0");

            Medicamento medicamentoSelecionado = medicamentos.FirstOrDefault(medicamento => medicamento.Id == idMedicamento)!;

            if (medicamentoSelecionado == null)
            {
                Console.WriteLine("Medicamento não encontrado. Operação cancelada.");
                return null!;
            }

            List<Prescricao> prescricoes = ObterPrescricao();

            Console.WriteLine("Prescrições disponíveis:");
            foreach (var prescricao in prescricoes)
            {
                Console.WriteLine($"ID: {prescricao.Id}, CRM {prescricao.CRM}, Nome: {prescricao.Medicamentos}");
            }

            Console.WriteLine();

            Console.Write("Digite o ID da prescrição: ");
            int idPrescrição = Convert.ToInt32(Console.ReadLine() ?? "0");

            Prescricao prescricaoSelecionada = prescricoes.FirstOrDefault(prescricoes => prescricoes.Id == idPrescrição)!;

            if (prescricaoSelecionada == null)
            {
                Console.WriteLine("Medicamento não encontrado. Operação cancelada.");
                return null!;
            }

            RequisicaoDeEntrada novaRequisicao = new RequisicaoDeEntrada(DateTime.Now, funcionarioSelecionado, prescricaoSelecionada, medicamentoSelecionado);

            return novaRequisicao;
        }

        private List<Medicamento> ObterMedicamento()
        {
            return new List<Medicamento>();
        }
        private List<Prescricao> ObterPrescricao()
        {
            return new List<Prescricao>();
        }

        private List<Funcionario> ObterFuncionario()
        {
            return new List<Funcionario>();
        }

        public override void ExibirCabecalhoTabela()
        {
            Console.WriteLine(
                 "{0, -6} | {1, -25} | {2, -20} | {3, -20}",
                 "ID", "Funcionario", "Prescricao", "Medicamentos"
            );
        }
        public override void ExibirLinhaTabela(RequisicaoDeEntrada registro)
        {
            Console.WriteLine(
                "{0, -6} | {1, -25} | {2, -20} | {3, -20}",
                registro.Id, registro.Funcionario, registro.Prescricao, registro.Medicamentos
            );
        }
    }
}
