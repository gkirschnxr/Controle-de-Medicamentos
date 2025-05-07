using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using System.Text.RegularExpressions;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente : EntidadeBase <Paciente>
    {
        public string NomePaciente { get; set; }
        public string Telefone { get; set; }
        public string CartaoSus { get; set; }

        public Paciente() { } //criar instancia vazia para o serializador JSON

        public Paciente (string nome, string telefone, string cartaoSus)
        {
            NomePaciente = nome;
            Telefone = telefone;
            CartaoSus = cartaoSus;
        }

        public override void AtualizarRegistro(Paciente registroEditado) //pega o registro do paciente e passar para cá:
        {
            NomePaciente = registroEditado.NomePaciente;
            Telefone = registroEditado.Telefone;
            CartaoSus = registroEditado.CartaoSus;
        }

        public override string FormatarTelefone(string telefone)
        {
            return base.FormatarTelefone(telefone);
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrEmpty(NomePaciente))
                erros += "O campo 'Nome' é obrigatório.\n";

            if (NomePaciente.Length < 3 || NomePaciente.Length > 100)
                erros += "O campo 'Nome' deve conter entre 3 e 100 caracteres.\n";

            if (string.IsNullOrWhiteSpace(Telefone))
                erros += "O campo 'Telefone' é obrigatório.\n";

            if (Telefone.Length < 10)
                erros += "O campo 'Telefone' deve ter no minimo 10 caracteres.\n";

            if (string.IsNullOrEmpty(CartaoSus))
                erros += "O campo Cartão SUS é obrigatório.\n";

            if (!Regex.IsMatch(CartaoSus, @"^\d{15}$"))
                erros += "O Cartão SUS deve conter 15 números.\n";

            Telefone = FormatarTelefone(Telefone);

            return erros;
        }

        public string ObterCartaoSusFormatado()
        {
            string numeros = new string(CartaoSus.Where(char.IsDigit).ToArray());

            if (numeros.Length != 15)
                return CartaoSus; // Retorna como está se inválido

            return Convert.ToUInt64(numeros).ToString(@"000\ 0000\ 0000\ 0000");
        }
    }
}
