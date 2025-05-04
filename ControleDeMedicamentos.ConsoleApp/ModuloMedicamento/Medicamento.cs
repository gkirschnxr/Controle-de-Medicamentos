using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento : EntidadeBase<Medicamento>
    {
        public string NomeMedicamento { get; set; }

        public string Descricao { get; set; }

        public string Quantidade { get; set; }
    
        public Medicamento(string nomeMedicamento, string descricao, string quantidade)
            {
            NomeMedicamento = nomeMedicamento;
            Descricao = descricao;
            Quantidade = quantidade;
        }

        public override void AtualizarRegistro(Medicamento registroEditado)
        {
            NomeMedicamento = registroEditado.NomeMedicamento;
            Descricao = registroEditado.Descricao;
            Quantidade = registroEditado.Quantidade;
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
