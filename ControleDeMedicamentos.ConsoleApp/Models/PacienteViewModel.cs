using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.Models;

public class FormularioPacienteViewModel {
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CartaoSUS { get; set; } = string.Empty;
}

public class CadastrarPacienteViewModel : FormularioPacienteViewModel {
    public CadastrarPacienteViewModel() { }
    public CadastrarPacienteViewModel(string nome, string telefone, string cartaoSus) : this()
    {
        Nome = nome;
        Telefone = telefone;
        CartaoSUS = cartaoSus;
    }
}

public class EditarPacienteViewModel : FormularioPacienteViewModel {
    public int Id { get; set; }
    public EditarPacienteViewModel() { }
    public EditarPacienteViewModel(int id, string nome, string telefone, string cartaoSus) 
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;    
        CartaoSUS = cartaoSus;
    }
}

public class ExcluirPacienteViewModel {
    public int Id { get; set; }
    public string Nome { get; set; }
    public ExcluirPacienteViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarPacienteViewModel {
    public List<DetalhesPacienteViewModel> Registros { get; }
    public VisualizarPacienteViewModel(List<Paciente> pacientes) {

        Registros = [];

        foreach (var p in pacientes) {
            DetalhesPacienteViewModel detalhesVM = p.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesPacienteViewModel : FormularioPacienteViewModel {
    public int Id { get; set; }
    public DetalhesPacienteViewModel(int id, string nome, string telefone, string cartaoSus)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        CartaoSUS = cartaoSus;
    }

    public override string ToString(){
        return $"Id: {Id}, Nome: {Nome}, Telefone: {Telefone}, Cartão SUS: {CartaoSUS}";
    }
}
