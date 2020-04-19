using AutoMapper;
using ProvaCandidato.Data;
using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaCandidato.Controllers
{
    public class CidadeController : Controller
    {
        Repository<Cidade> repository = new Repository<Cidade>();
        // GET: Cidade
        public ActionResult Index()
        {
            CidadeViewModel viewModel = new CidadeViewModel();

            List<Cidade> listModel = repository.GetAll();

            listModel.ForEach(x => viewModel.CidadeViewModels.Add(Mapper.Map<CidadeViewModel>(x)));

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View(new Cidade());
        }

        [HttpPost]
        public ActionResult Insert(Cidade model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);

                TempData["UserMessage"] = "Cidade cadastrado com sucesso!";

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(repository.GetById(id));
        }

        [HttpPost]
        public ActionResult Update(Cidade model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);

                TempData["UserMessage"] = "Cidade atualizado com sucesso!";

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}