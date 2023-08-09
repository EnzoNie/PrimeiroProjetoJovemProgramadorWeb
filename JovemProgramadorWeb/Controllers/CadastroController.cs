using JovemProgramadorWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Cadastro model)
        {
            if (ModelState.IsValid)
            {
                // Verificar se o checkbox foi marcado
                if (model.AceitouTermos)
                {
                    // Fazer o processamento de cadastro
                    return RedirectToAction("Sucesso");
                }
                else
                {
                    ModelState.AddModelError("AceitouTermos", "Você deve aceitar os termos e condições.");
                }
            }

            return View(model);
        }

    }
}
