﻿using JovemProgramadorWeb.Data.Repositório.Interface;
using JovemProgramadorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JovemProgramadorWeb.Controllers
{
    
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IConfiguration configuration, IAlunoRepositorio alunoRepositorio)
        {
            _configuration = configuration;
            _alunoRepositorio = alunoRepositorio;
            
        }
        public IActionResult Aluno()
        {
            var aluno = _alunoRepositorio.BuscarAlunos();
            return View(aluno);
        }

        public IActionResult InserirAluno(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.InserirAluno(aluno);
            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = "Erro ao inserir aluno!";
            }
            TempData["MsgSucesso"] = "Aluno adicionado com sucesso!";

            return RedirectToAction("Aluno");
        }
        public IActionResult EditarAluno(Aluno aluno)
        {
            
            try
            {
                _alunoRepositorio.EditarAluno(aluno);
            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = "Erro ao editar aluno!";
            }
            TempData["MsgSucesso"] = "Aluno editado com sucesso!";

            return RedirectToAction("Aluno");
        }
        public IActionResult ExcluirAluno(Aluno aluno)
        {

            try
            {
                _alunoRepositorio.ExcluirAluno(aluno);
            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = "Erro ao excluir aluno!";
            }
            TempData["MsgSucesso"] = "Aluno excluído com sucesso!";

            return RedirectToAction("Aluno");
        }
        public async Task<IActionResult>BuscarEndereco(string cep)
        {
            Endereco endereco = new Endereco();

            try
            {
                cep = cep.Replace("-", "");

                using var client = new HttpClient();
                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");

                if (!result.IsSuccessStatusCode)
                {
                    ViewData["MsgErro"] = "Erro na busca de endereço!";

                }
                else
                {
                    endereco = JsonSerializer.Deserialize<Endereco>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });

                }
            }
            catch (Exception)
            {
                throw;
            }
            return View("Endereco", endereco);
        }
        public IActionResult ModalEditarAluno(int id)
        {
            var alunoId = _alunoRepositorio.BuscarAlunoPorId(id);

            return View("EditarAluno", alunoId);
        }
    }
}
