
using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class Fornecedor : EntidadeBase<Fornecedor>
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string CNJP { get; set; }

        public Fornecedor()
        {
            
        }
        public Fornecedor(string nome, string telefone, string cnpj)
        {
            Nome = nome;
            Telefone = telefone;
            CNJP = cnpj;
        }

        public override void AtualizarRegistro(Fornecedor registroEditado)
        {
            Nome = registroEditado.Nome;
            Telefone = registroEditado.Telefone;
            CNJP = registroEditado.CNJP;
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
