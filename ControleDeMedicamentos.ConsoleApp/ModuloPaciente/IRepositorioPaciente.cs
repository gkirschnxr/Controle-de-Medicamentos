using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public interface IRepositorioPaciente : IRepositorio<Paciente> 
{
    bool CartaoSusDuplicado(Paciente paciente);
}
