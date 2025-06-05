using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;
using System.Diagnostics.CodeAnalysis;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoSaida;

public class RequisicaoDeSaida
{
    public Guid Id { get; set; }
    public DateTime DataOcorrencia { get; set; }
    public Funcionario Funcionario { get; set; } = null!;
    public Prescricao Prescricao { get; set; } = null!;

    [ExcludeFromCodeCoverage]
    public RequisicaoDeSaida() { }

    public RequisicaoDeSaida(Funcionario funcionario, Prescricao prescricao) {
        Id = Guid.NewGuid();
        DataOcorrencia = DateTime.Now;
        Funcionario = funcionario;
        Prescricao = prescricao;
    }

    public string Validar()
    {
        string erros = string.Empty;

        if (Funcionario == null)
            erros += "O campo \"Paciente\" é obrigatório.";

        if (Prescricao == null)
            erros += "O campo \"Medicamento\" é obrigatório.";

        else if (Prescricao.MedicamentosPrescritos == null || Prescricao.MedicamentosPrescritos.Count < 1)
            erros += "O campo \"Medicamentos Prescritos da Prescrição\" necessita conter ao menos um medicamento.";

        if (Prescricao!.MedicamentosPrescritos != null) {
            
            foreach (var item in Prescricao.MedicamentosPrescritos) {
                
                if (item.Quantidade > item.Medicamento.QuantidadeEmEstoque)
                    erros += $"O medicamento \"{item.Medicamento}\" não está disponível na quantidade requisitada.";
            }
        }

        return erros;
    }
}