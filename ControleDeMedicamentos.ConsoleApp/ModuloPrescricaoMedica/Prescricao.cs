using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

public class Prescricao : EntidadeBase<Prescricao>
{
    public string CRM { get; set; }
    public DateTime DataPrescricao { get; set; }
    public Medicamento Medicamentos { get; set; }

    public Prescricao() { }

    public Prescricao(string crm, DateTime dataPrescricao, Medicamento medicamentos)
    {
        CRM = crm;
        DataPrescricao = dataPrescricao;
        Medicamentos = medicamentos;
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

        return erros;
    }
}
