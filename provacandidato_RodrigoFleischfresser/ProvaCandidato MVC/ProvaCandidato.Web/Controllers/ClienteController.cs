using AutoMapper;
using ProvaCandidato.Data;
using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ProvaCandidato.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        Repository<Cliente> repository = new Repository<Cliente>();
        Repository<Cidade> repositoryCidade = new Repository<Cidade>();
        // GET: Cliente
        public ActionResult Index()
        {
            ClienteViewModel viewModel = new ClienteViewModel();

            List<Cliente> listModel = repository.GetAll();

            listModel.ForEach(x => viewModel.ClienteViewModels.Add(Mapper.Map<ClienteViewModel>(x)));

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View(new Cliente());
        }

        [HttpPost]
        public ActionResult Insert(Cliente model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);

                TempData["UserMessage"] = "Cliente cadastrado com sucesso!";

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            List<Cliente> listModel = repository.GetAll();

            ClienteViewModel viewModel = new ClienteViewModel();

            listModel.ForEach(x => viewModel.ClienteViewModels.Add(Mapper.Map<ClienteViewModel>(x)));

            viewModel.ClienteViewModels.ForEach(x => x.Cidade = repositoryCidade.GetById(x.CidadeId));

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Update(Cliente model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);

                TempData["UserMessage"] = "Cliente atualizado com sucesso!";

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

        [HttpGet]
        public ActionResult  GetCidades()
        {
            {
                var model = repositoryCidade.GetAll();

                Cidade cidade = new Cidade();

                return Json(model.Select(x => new
                {
                    Codigo = x.Codigo,
                    Nome = x.Nome
                }).ToList(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}