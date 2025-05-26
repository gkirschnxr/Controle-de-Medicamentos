namespace ControleDeMedicamentos.ConsoleApp.Models;

public class NotificacaoViewModel {
    public string Mensagem { get; set; }
    public string TituloPagina { get; set; }
    public NotificacaoViewModel(string mensagem, string tituloPagina)
    {
        Mensagem = mensagem;
        TituloPagina = tituloPagina;
    }
}
