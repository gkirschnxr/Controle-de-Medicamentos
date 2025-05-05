using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using System.Text.RegularExpressions;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente : EntidadeBase <Paciente>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CartaoSus { get; set; }

        public Paciente() { } //criar instancia vazia para o serializador JSON

        public Paciente (string nome, string telefone, string cartaoSus)
        {
            Nome = nome;
            Telefone = telefone;
            CartaoSus = cartaoSus;
        }

        public override void AtualizarRegistro(Paciente registroEditado) //pega o registro do paciente e passar para cá:
        {
            Nome = registroEditado.Nome;
            Telefone = registroEditado.Telefone;
            CartaoSus = registroEditado.CartaoSus;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrEmpty(Nome))
                erros += "O campo 'Nome' é obrigatório.\n";

            if (Nome.Length < 3 || Nome.Length > 100)
                erros += "O campo 'Nome' deve conter entre 3 e 100 caracteres.\n";

            if (Regex.IsMatch(Telefone, @"^\(?\d{2}\)?\s?(9\d{4})-?\d{4}$"))
                erros += "O campo 'Telefone' deve seguir o padrão (DDD) 0000-0000 ou (DDD) 00000-0000.\n";

            if (string.IsNullOrEmpty(CartaoSus))
                erros += "O campo Cartão SUS é obrigatório.\n";

            if (!Regex.IsMatch(CartaoSus, @"^\d{15}$"))
                erros += "O Cartão SUS deve conter 15 números.\n";

            return erros;
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

            return Telefone;
        }


    }
}
