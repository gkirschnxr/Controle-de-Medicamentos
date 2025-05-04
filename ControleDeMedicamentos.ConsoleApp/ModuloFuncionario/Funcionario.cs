using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        
        public Funcionario()
        {
            
        }

        public Funcionario(string nome, string telefone, string cpf)
        {
            Nome = nome;
            Telefone = telefone;
            CPF = cpf;
        }

        public override void AtualizarRegistro(Funcionario registroEditado)
        {
            Nome = registroEditado.Nome;
            Telefone = registroEditado.Telefone;
            CPF = registroEditado.CPF;
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

            if (string.IsNullOrWhiteSpace(CPF))
                erros += "O campo 'CPF' é obrigatório.\n";

            string cpfNumerico = new string(CPF.Where(char.IsDigit).ToArray());

            if (cpfNumerico.Length != 11)
                erros += "O campo 'CPF' deve conter exatamente 11 dígitos numéricos.\n";


            return erros;
        }

        public string ObterCpfFormatado()
        {
            string numeros = new string(CPF.Where(char.IsDigit).ToArray());

            if (numeros.Length != 11)
                return CPF; // Retorna como está se inválido

            return Convert.ToUInt64(numeros).ToString(@"000\.000\.000\-00");
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
