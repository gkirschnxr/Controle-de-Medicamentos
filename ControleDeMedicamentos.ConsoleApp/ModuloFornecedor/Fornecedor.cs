using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

public class Fornecedor : EntidadeBase<Fornecedor>
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string CNPJ { get; set; }      

    public Fornecedor(string nome, string telefone, string cnpj) {
        Id = Guid.NewGuid();
        Nome = nome;
        Telefone = telefone;
        CNPJ = cnpj;
    }

    public override void AtualizarRegistro(Fornecedor registroEditado) {
        Nome = registroEditado.Nome;
        Telefone = registroEditado.Telefone;
        CNPJ = registroEditado.CNPJ;
    }

    public override string FormatarTelefone(string telefone) {
        return base.FormatarTelefone(Telefone); 
    }

    public override string Validar() {            
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo 'Nome' é obrigatório.\n";

        if (Nome.Length < 3)
            erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

        if (string.IsNullOrWhiteSpace(Telefone))
            erros += "O campo 'Telefone' é obrigatório.\n";

        if (Telefone.Length < 10)
            erros += "O campo 'Telefone' precisa conter ao menos 10 caracteres.\n";

        if (string.IsNullOrWhiteSpace(CNPJ))
            erros += "O campo 'CNPJ' é obrigatório.\n";

        string cnpjNumerico = new string(CNPJ.Where(char.IsDigit).ToArray());
        
        if (cnpjNumerico.Length != 14)
            erros += "O campo 'CNPJ' deve conter exatamente 14 dígitos numéricos.\n";

        FormatarTelefone(Telefone);        

        return erros;
    }        

    public string ObterCnpjFormatado() {
        string numeros = new string(CNPJ.Where(char.IsDigit).ToArray());

        if (numeros.Length != 14)
            return CNPJ; // Retorna como está se inválido

        return Convert.ToUInt64(numeros).ToString(@"00\.000\.000\/0000\-00");
    }
}