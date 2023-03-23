using Contatos.Models;
using Contatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.GetContatoList();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }


        public IActionResult Editar(int id)
        {
            try
            {
                ContatoModel contatoId = _contatoRepositorio.ListarPorId(id);
                TempData["MensagemSucesso"] = "Contato EDITADO com sucesso";
                return View(contatoId);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Nao foi possivel Editar seu cadastro {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult ApagaConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        [HttpGet]
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato APAGADO com sucesso";
                    
                }
                else
                {
                    TempData["MensagemErro"] = $"Nao foi possivel APAGAR seu cadastro";
                }
                return RedirectToAction("index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Nao foi possivel APAGAR seu cadastro {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Nao foi possivel realizar seu cadstro {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato Alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Nao foi possivel Alterar seu cadastro {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
