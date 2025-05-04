
using ControleDeMedicamentos.ConsoleApp.Compartilhado;


namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class Fornecedor : EntidadeBase<Fornecedor>
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string CNPJ { get; set; }

        public Fornecedor()
        {
        }
        public Fornecedor(string nome, string telefone, string cnpj)
        {
            Nome = nome;
            Telefone = telefone;
            CNPJ = cnpj;
        }

        public override void AtualizarRegistro(Fornecedor registroEditado)
        {
            Nome = registroEditado.Nome;
            Telefone = registroEditado.Telefone;
            CNPJ = registroEditado.CNPJ;
        }
        

        public override string Validar()
        {
        
        string erros = "";

            if (string.IsNullOrWhiteSpace(Nome))
                erros += "O campo 'Nome' é obrigatório.\n";

            if (Nome.Length < 3)
                erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

            if (string.IsNullOrWhiteSpace(Telefone))
                erros += "O campo 'Telefone' é obrigatório.\n";

            if (string.IsNullOrWhiteSpace(CNPJ))
                erros += "O campo 'CNPJ' é obrigatório.\n";

            string cnpjNumerico = new string(CNPJ.Where(char.IsDigit).ToArray());

            if (cnpjNumerico.Length != 14)
                erros += "O campo 'CNPJ' deve conter exatamente 14 dígitos numéricos.\n";


            return erros;
        }

        public string ObterCnpjFormatado()
        {
            string numeros = new string(CNPJ.Where(char.IsDigit).ToArray());

            if (numeros.Length != 14)
                return CNPJ; // Retorna como está se inválido

            return Convert.ToUInt64(numeros).ToString(@"00\.000\.000\/0000\-00");
        }

        internal object FormatarTelefone(string telefone)
        {
            string numeroTelefone = new string(Telefone.Where(char.IsDigit).ToArray());

            if (numeroTelefone.Length == 10)// Formato (XX) XXXX-XXXX
            { 
                string ddd = numeroTelefone.Substring(0, 2);
                string parte1 = numeroTelefone.Substring(2, 4);
                string parte2 = numeroTelefone.Substring(6, 4);
                return $"({ddd}) {parte1}-{parte2}";
            }
            if (numeroTelefone.Length == 11) // Formato (XX) 9XXXX-XXXX
            {
                string ddd = numeroTelefone.Substring(0, 2);
                string parte1 = numeroTelefone.Substring(2, 5);
                string parte2 = numeroTelefone.Substring(7, 4);
                return $"({ddd}) {parte1}-{parte2}";
            }

            return Telefone; // Retorna como está se inválido
        }
    }
}
