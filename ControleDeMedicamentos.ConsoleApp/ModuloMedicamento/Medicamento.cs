using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloReqSaida;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento : EntidadeBase<Medicamento>
    {
        public string NomeMedicamento { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public List<RequisicaoDeSaida> RequisicoesDeSaida { get; set; }

        public Medicamento()
        {
            RequisicoesDeSaida = new List<RequisicaoDeSaida>();
        }

        public Medicamento(string nomeMedicamento, string descricao, int quantidade)
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
            string erros = "";

            if (string.IsNullOrWhiteSpace(NomeMedicamento))
                erros += "O campo 'Nome' é obrigatório.\n";

            if (NomeMedicamento.Length < 3)
                erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

            if (string.IsNullOrWhiteSpace(Descricao))
                erros += "O campo 'Descrição' é obrigatório.\n";

            if (Quantidade <= 0)
                erros += "O campo 'Quantidade' deve ser maior que Zero.\n";

            if(Quantidade <= 20)
                erros += "Medicamento em falta";

            return erros;
        }

        public void AdicionarRequisicao(RequisicaoDeSaida requisicoesDeSaida)
        {
            RequisicoesDeSaida.Add(requisicoesDeSaida);
        }

        public void ExcluirRequisicao(RequisicaoDeSaida requisicoesDeSaida)
        {
            RequisicoesDeSaida.Remove(requisicoesDeSaida);
        }
    }
}
