using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

namespace ControleDeMedicamentos.ConsoleApp.Models;

public class FormularioFuncionarioViewModel { 
    public string Nome {  get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
}

public class CadastrarFuncionarioViewModel : FormularioFuncionarioViewModel { 
    public CadastrarFuncionarioViewModel() { }
    public CadastrarFuncionarioViewModel(string nome, string telefone, string cpf) : this()
    {
        Nome = nome;
        Telefone = telefone;
        CPF = cpf;
    }
}

public class EditarFuncionarioViewModel : FormularioFuncionarioViewModel { 
    public int Id { get; set; }

    public EditarFuncionarioViewModel() { }
    public EditarFuncionarioViewModel(int id, string nome, string telefone, string cpf)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        CPF = cpf;
    }
}

public class ExcluirFuncionarioViewModel {
    public int Id { get; set; }
    public string Nome { get; set; }

    public ExcluirFuncionarioViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarFuncionarioViewModel {
    public List<DetalhesFuncionariosViewModel> Registros {  get; }

    public VisualizarFuncionarioViewModel(List<Funcionario> funcionarios) {

        Registros = [];

        foreach (var f in funcionarios) {
            DetalhesFuncionariosViewModel detalhesVM = f.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesFuncionariosViewModel : FormularioFuncionarioViewModel {
    public int Id { get; set; }

    public DetalhesFuncionariosViewModel(int id, string nome, string telefone, string cpf)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        CPF = cpf;
    }

    public override string ToString() {
        return $"Id: {Id}, Nome: {Nome}, Telefone: {Telefone}, CPF: {CPF}";
    }

}
