using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodersLab.Mvc.Workshops.Models;
using CodersLab.Mvc.Workshops.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodersLab.Mvc.Workshops.Controllers
{
    public class PersonController : Controller
    {
		private SourceManager _repo = new SourceManager();

		[HttpGet]
		public IActionResult Index(int page = 1, string filterLastName = "")
        {
			var repo = new SourceManager();
			List<PersonModel> list = _repo.Get();

			if (!String.IsNullOrWhiteSpace(filterLastName))
			{
				list = list.Where(q => q.LastName.StartsWith(filterLastName)).ToList();
			}

			var pageElements = 5;
			var pages = Math.Ceiling((decimal) list.Count() / pageElements);

			list = list.Skip( (page - 1) * pageElements ).Take(pageElements).ToList();

			ViewBag.Page = page;
			ViewBag.Pages = pages;
			ViewBag.FilterLastName = filterLastName;

			return View(list);
        }

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(PersonModel model)
		{
			_repo.Add(model);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var model = _repo.GetById(id);

			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(PersonModel model)
		{
			_repo.Update(model);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			PersonModel model = _repo.GetById(id);

			return View(model);
		}

		[HttpPost]
		[ActionName("Delete")]
		public IActionResult DeleteConfirm(int id)
		{
			_repo.Remove(id);

			return RedirectToAction("Index");
		}
	}
}