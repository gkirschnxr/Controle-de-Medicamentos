using System.Text.RegularExpressions;

namespace ControleDeMedicamentos.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public Guid Id { get; set; }

        public abstract void AtualizarRegistro(T registroEditado);

        public abstract string Validar();

        public virtual string FormatarTelefone(string telefone)
        {
            if (telefone == null)
                return string.Empty;

            string numeroTelefone = new string(telefone.Where(char.IsDigit).ToArray());

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

            return telefone;
        }

        public virtual string FormatarCPF(string cpf) {
            string numeros = new string(cpf.Where(char.IsDigit).ToArray());

            if (numeros.Length != 11)
                return cpf;

            return Convert.ToUInt64(numeros).ToString(@"000\.000\.000\-00");
        }

        internal string FormatarCNPJ(string cNPJ)
        {
            throw new NotImplementedException();
        }
    }
}
