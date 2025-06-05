using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using System.Text.RegularExpressions;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

public class Funcionario : EntidadeBase<Funcionario>
{
    public string NomeFuncionario { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    
    public Funcionario() { }

    public Funcionario(string nome, string telefone, string cpf) : this() {
        Id = Guid.NewGuid();
        NomeFuncionario = nome;
        Telefone = telefone;
        CPF = cpf;
    }

    public override void AtualizarRegistro(Funcionario registroEditado) {
        this.NomeFuncionario = registroEditado.NomeFuncionario;
        this.Telefone = registroEditado.Telefone;
        this.CPF = registroEditado.CPF;
    }
    
    public override string FormatarTelefone(string telefone) {
        return base.FormatarTelefone(Telefone);
    }

    public override string Validar() {
        List<Funcionario> funcionariosCadastrados = new List<Funcionario>();

        string erros = "";

        if (string.IsNullOrWhiteSpace(NomeFuncionario))
            erros += "O campo 'Nome' é obrigatório.\n";
        else if (NomeFuncionario.Length < 3 || NomeFuncionario.Length > 100)
            erros += "O campo 'Nome' deve conter entre 3 e 100 caracteres.\n";

        if (string.IsNullOrWhiteSpace(Telefone))
            erros += "O campo 'Telefone' é obrigatório.\n";
        else if (!Regex.IsMatch(Telefone, @"^\(?\d{2}\)?\s?(9\d{4}|\d{4})-?\d{4}$"))
            erros += "O campo 'Telefone' deve seguir o padrão (DDD) 0000-0000 ou (DDD) 00000-0000.\n";

        if (string.IsNullOrWhiteSpace(CPF))
            erros += "O campo 'CPF' é obrigatório.\n";
        else if (!Regex.IsMatch(CPF, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$"))
            erros += "O campo 'CPF' deve seguir o formato 000.000.000-00.\n";
        else
        {
            foreach (var f in funcionariosCadastrados)
            {
                if (f.CPF == this.CPF)
                {
                    erros += "Já existe um funcionário cadastrado com este CPF.\n";
                    break;
                }
            }
        }

        FormatarTelefone(Telefone);

        FormatarCPF(CPF); 

        return erros;
    }        
}
