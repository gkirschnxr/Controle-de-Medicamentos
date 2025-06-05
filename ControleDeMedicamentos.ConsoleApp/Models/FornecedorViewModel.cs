using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp.Models;

public abstract class FormularioFornecedorViewModel {
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CNPJ { get; set; } = string.Empty;
}

public class CadastrarFornecedorViewModel : FormularioFornecedorViewModel {
    public CadastrarFornecedorViewModel() { }
    public CadastrarFornecedorViewModel(string nome, string telefone, string cnpj) : this()
    {
        Nome = nome;
        Telefone = telefone;
        CNPJ = cnpj;
    }
}

public class EditarFornecedorViewModel : FormularioFornecedorViewModel {
    public Guid Id { get; set; }

    public EditarFornecedorViewModel() { }

    public EditarFornecedorViewModel(Guid id, string nome, string telefone, string cnpj) : this()
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        CNPJ = cnpj;
    }
}

public class ExcluirFornecedorViewModel {
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public ExcluirFornecedorViewModel(Guid id, string nome) {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarFornecedorViewModel {
    public List<DetalhesFornecedorViewModel> Registros { get; }

    public VisualizarFornecedorViewModel(List<Fornecedor> fornecedores) {

        Registros = [];

        foreach (var f in fornecedores) {
            var detalhesVM = f.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesFornecedorViewModel : FormularioFornecedorViewModel {
    public Guid Id { get; set; }

    public DetalhesFornecedorViewModel(Guid id, string nome, string telefone, string cnpj)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        CNPJ = cnpj;
    }
    public override string ToString()
    {
        return $"Id: {Id}, Nome: {Nome}, Telefone: {Telefone}, CNPJ: {CNPJ}";
    }
}
