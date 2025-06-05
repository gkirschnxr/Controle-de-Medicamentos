using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("/")]
public class PaginaInicialController : Controller
{
    public IActionResult PaginaInicial() {
        return View("PaginaInicial");
    }
}
