
using ControleDeMedicamentos.ConsoleApp.Compartilhado;


namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class RepositorioFornecedor : RepositorioBase<Fornecedor>, IRepositorioFornecedor
    {
        public RepositorioFornecedor(ContextoDeDados contexto) : base(contexto)
        {
        }

        protected override List<Fornecedor> ObterRegistros()
        {
            return contexto.Fornecedores;
        }

        

        public bool CnpjEstaDuplicado(Fornecedor fornecedor)
        {
            foreach (Fornecedor f in SelecionarRegistros())
            {
                if (f.CNPJ == fornecedor.CNPJ)
                    return true;
            }
            return false; 
        }
    }
}
