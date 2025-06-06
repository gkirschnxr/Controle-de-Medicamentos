using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

public class Prescricao
{
    public Guid Id { get; set; } = Guid.Empty;
    public string CRM { get; set; } = string.Empty;
    public DateTime DataPrescricao { get; set; }
    public Paciente Paciente { get; set; } = null!;
    public string Dosagem { get; set; } 
    public string Periodo { get; set; }
    public int Quantidade { get; set; }
    public List<MedicamentoPrescrito> MedicamentosPrescritos { get; set; } = new List<MedicamentoPrescrito>();

    public Prescricao() { }

    public Prescricao(string crm, Paciente paciente,
                     List<MedicamentoPrescrito> medicamentosPrescritos) : this()
    {
        Id = Guid.NewGuid();
        CRM = crm;
        DataPrescricao = DateTime.Now;
        Paciente = paciente;
        MedicamentosPrescritos = medicamentosPrescritos;
    }
}
