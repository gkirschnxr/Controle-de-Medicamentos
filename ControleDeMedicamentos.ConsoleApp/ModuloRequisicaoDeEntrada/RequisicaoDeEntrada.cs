using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeEntrada
{
    public class RequisicaoDeEntrada : EntidadeBase<RequisicaoDeEntrada>
    {
        public DateTime DataRequisicaoEntrada { get; set; }
        public Funcionario Funcionario { get; set; }
        public Prescricao Prescricao { get; set; }
        public Medicamento Medicamentos { get; set; }

        public RequisicaoDeEntrada() { }

        public RequisicaoDeEntrada(DateTime dataRequisicaoEntrada, Funcionario funcionario, Prescricao prescricao, Medicamento medicamentos)
        {
            DataRequisicaoEntrada = dataRequisicaoEntrada;
            Funcionario = funcionario;
            Prescricao = prescricao;
            Medicamentos = medicamentos;
        }

        public override void AtualizarRegistro(RequisicaoDeEntrada registroEditado)
        {
            DataRequisicaoEntrada = registroEditado.DataRequisicaoEntrada;
        }

        public override string Validar()
        {
            string erros = "";

            if (DataRequisicaoEntrada > DateTime.Now)
                erros += "O campo 'Data Requisição de Entrada' deve conter uma data passada.\n";

            return erros;
        }
    }
}
