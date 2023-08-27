using JovemProgramadorWeb.Data.Repositório.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAlunoRepositorio _alunoRepositorio;

        public LoginController(IConfiguration configuration, IAlunoRepositorio alunoRepositorio)
        {
            _configuration = configuration;
            _alunoRepositorio = alunoRepositorio;

        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult ValidacaoLogin(string email, string senha)
        {
            try
            {
                var resultado = _alunoRepositorio.ValidarLogin(email, senha);
                if (resultado != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = "Email ou senha inválidos!";
                return RedirectToAction("Login");
            }
           
        }
    }
}
