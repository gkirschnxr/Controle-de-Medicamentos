using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

public class Prescricao : EntidadeBase<Prescricao>
{
    public string CRM { get; set; }
    public DateTime DataPrescricao { get; set; }
    public List<Medicamento> Medicamentos { get; set; }

    public Prescricao()
    {
        Medicamentos = new List<Medicamento>();
    }

    public Prescricao(string crm, DateTime dataPrescricao) : this()
    {
        CRM = crm;
        DataPrescricao = dataPrescricao;
    }

    public override void AtualizarRegistro(Prescricao registroEditado)
    {
        CRM = registroEditado.CRM;
    }

    public override string Validar()
    {
        string erros = "";

        if (CRM.Length != 6)
            erros += "O CRM deve conter exatos 6 dígitos";
        if (Medicamentos == null)
            erros += "Deve Selecionar um Medicamento valido";

        return erros;
    }
}
