using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp.Models;

public abstract class FormularioFornecedorViewModel {
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string CNPJ { get; set; }
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
    public int Id { get; set; }

    public DetalhesFornecedorViewModel(int id, string nome, string telefone, string cnpj)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        CNPJ = cnpj;
    }
    public string ToString()
    {
        return $"Id: {Id}, Nome: {Nome}, Telefone: {Telefone}, CNPJ: {CNPJ}";
    }
}
