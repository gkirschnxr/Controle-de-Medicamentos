using System.Text.Json.Serialization;
using System.Text.Json;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

namespace ControleDeMedicamentos.ConsoleApp.Compartilhado
{
    public class ContextoDeDados
    {
        private string pastaArmazenamento = "C:\\temp";
        private string arquivoArmazenamento = "dados-controle-medicamentos.json";

        public List<Fornecedor> Fornecedores { get; set; }
        public List<Funcionario> Funcionarios { get; set; }



        public ContextoDeDados()
        {
            Fornecedores = new List<Fornecedor>();
            Funcionarios = new List<Funcionario>();
        }

        public ContextoDeDados(bool carregarDados) : this()
        {
            if (carregarDados)
                Carregar();
        }

        public void Salvar()
        {
            string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.WriteIndented = true;
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            string json = JsonSerializer.Serialize(this, jsonOptions);

            if (!Directory.Exists(pastaArmazenamento))
                Directory.CreateDirectory(pastaArmazenamento);

            File.WriteAllText(caminhoCompleto, json);

        }
        public void Carregar()
        {
            string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            if (!File.Exists(caminhoCompleto))
                return;

            string json = File.ReadAllText(caminhoCompleto);

            if (string.IsNullOrWhiteSpace(json))
                return;

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;
            

            ContextoDeDados contextoArmazenado = JsonSerializer.Deserialize<ContextoDeDados>(json, jsonOptions)!;

            if (contextoArmazenado == null) return;

            Fornecedores = contextoArmazenado.Fornecedores;
            Funcionarios = contextoArmazenado.Funcionarios;

        }
    }
}
