using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoSaida;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoEntrada;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

public class Medicamento : EntidadeBase<Medicamento>
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public Fornecedor Fornecedor { get; set; } = null!;
    public List<RequisicaoDeEntrada> RequisicoesEntrada { get; set; }
    public List<RequisicaoDeSaida> RequisicoesSaida { get; set; }

    public int QuantidadeEmEstoque {
        get {
            int quantidadeEmEstoque = 0;

            foreach (var req in RequisicoesEntrada) {
                quantidadeEmEstoque += req.QuantidadeRequisitada;
            }

            foreach (var req in RequisicoesSaida) {

                foreach (var med in req.Prescricao.MedicamentosPrescritos)
                    quantidadeEmEstoque += med.Quantidade;
            }

            return quantidadeEmEstoque;
        }
    }

    public bool EmFalta {
        get {  return QuantidadeEmEstoque < 20; }
    }

    public Medicamento() {
        RequisicoesEntrada = new List<RequisicaoDeEntrada>();            
        RequisicoesSaida = new List<RequisicaoDeSaida>();            
    }

    public Medicamento(string nome, string descricao, Fornecedor fornecedor) : this() {
        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;  
        Fornecedor = fornecedor;
    }

    public void AdicionarAoEstoque(RequisicaoDeEntrada requisicaoDeEntrada) {
        if (!RequisicoesEntrada!.Contains(requisicaoDeEntrada))
            RequisicoesEntrada.Add(requisicaoDeEntrada);
    }

    public void RemoverDoEstoque(RequisicaoDeSaida requisicaoDeSaida) {
        if (!RequisicoesSaida!.Contains(requisicaoDeSaida))
            RequisicoesSaida.Add(requisicaoDeSaida);
    }

    public override void AtualizarRegistro(Medicamento registroEditado) {
        Nome = registroEditado.Nome;
        Descricao = registroEditado.Descricao;
        Fornecedor = registroEditado.Fornecedor;
    }

    public override string Validar() {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo 'Nome' é obrigatório.\n";

        if (Nome!.Length < 3)
            erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

        if (string.IsNullOrWhiteSpace(Descricao))
            erros += "O campo 'Descrição' é obrigatório.\n";

        if (Fornecedor == null)
            erros += "O campo 'Fornecedor' é obrigatório.\n";      

        return erros;
    }
}