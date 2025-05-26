using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp.Extensions;

public static class FornecedorExtensions {

    public static Fornecedor ParaEntidade(this FormularioFornecedorViewModel formularioVM) {
        return new Fornecedor(formularioVM.Nome, formularioVM.Telefone, formularioVM.CNPJ);
    }

    public static DetalhesFornecedorViewModel ParaDetalhesVM(this Fornecedor f) {
        return new DetalhesFornecedorViewModel(f.Id, f.Nome, f.Telefone, f.CNPJ);
    }
}
