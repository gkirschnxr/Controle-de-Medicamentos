using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

namespace ControleDeMedicamentos.ConsoleApp.Extensions;

public static class FuncionarioExtensions {
    public static Funcionario ParaEntidade(this FormularioFuncionarioViewModel formularioVM) {
        return new Funcionario(formularioVM.Nome, formularioVM.Telefone, formularioVM.CPF);    
    }

    public static DetalhesFuncionariosViewModel ParaDetalhesVM(this Funcionario f) {
        return new DetalhesFuncionariosViewModel(f.Id, f.Nome, f.Telefone, f.CPF);    
    }
}
