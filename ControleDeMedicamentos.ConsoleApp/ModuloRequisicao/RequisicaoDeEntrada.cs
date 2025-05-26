using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes
{
    public class RequisicaoDeEntrada
    {
        public Guid Id { get; set; }
        public DateTime DataRequisicaoEntrada { get; set; }
        public Funcionario Funcionario { get; set; }
        public Prescricao Prescricao { get; set; }
        public Medicamento Medicamentos { get; set; }
        public int QuantidadeRequisitada { get; set; }

        public RequisicaoDeEntrada() { }

        public RequisicaoDeEntrada(Funcionario funcionario, Prescricao prescricao, Medicamento medicamentos, int quantidadeRequisitada)
        {
            Id = Guid.NewGuid();
            DataRequisicaoEntrada = DateTime.Now;
            Funcionario = funcionario;
            Prescricao = prescricao;
            Medicamentos = medicamentos;
            QuantidadeRequisitada = quantidadeRequisitada;
        }

        public string Validar()
        {
            string erros = "";

            if (Funcionario == null)
                erros += "O campo 'Paciente' é obrigatório. \n";

            if (Prescricao == null)
                erros += "O campo 'Prescricao' é obrigatório. \n";

            if (Medicamentos == null)
                erros += "O campo 'Medicamentos' é obrigatório. \n";

            if (QuantidadeRequisitada < 1)
                erros += "A requisição deve conter um valor positivo.\n";

            return erros;
        }
    }
}
