using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Design_Bureau.DAL;
using Design_Bureau.DAL.Repositories;
using Design_Bureau.Entities;
using Microsoft.AspNetCore.Authorization;
using Design_Bureau.BLL.Authentication__Authorization.Models;

namespace Design_Bureau.Api.Controllers
{
    [Authorize]
    public class TermsOfReferencesController : Controller
    {
        private readonly IRepository<TermsOfReference> _repository;

        public TermsOfReferencesController(IRepository<TermsOfReference> repository)
        {
            _repository = repository;
        }

        // GET: TermsOfReferences
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAll().ToListAsync());
        }

        // GET: TermsOfReferences/Details/5
        public IActionResult Details(int id)
        {
            var termsOfReference = _repository.Find(m => m.Id == id).Include(m => m.MultiStoreyHouseProject).ToArray().FirstOrDefault();
            if (termsOfReference == null)
            {
                return NotFound();
            }

            return View(termsOfReference);
        }

        // GET: TermsOfReferences/Create
        [Authorize(Roles = Role.User)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TermsOfReferences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.User)]
        public async Task<IActionResult> Create([Bind("Name,Description,IsRegistered,Id")] TermsOfReference termsOfReference)
        {
            if (ModelState.IsValid)
            {
                await _repository.Insert(termsOfReference);
                return RedirectToAction(nameof(Index));
            }
            return View(termsOfReference);
        }

        // GET: TermsOfReferences/Edit/5
        [Authorize(Roles = Role.Admin)]
        public IActionResult Edit(int id)
        {
            var termsOfReference = _repository.Get(id);
            if (termsOfReference == null)
            {
                return NotFound();
            }
            return View(termsOfReference);
        }

        // POST: TermsOfReferences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,IsRegistered,Id")] TermsOfReference termsOfReference)
        {
            if (id != termsOfReference.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _repository.Update(termsOfReference);
                return RedirectToAction(nameof(Index));
            }
            return View(termsOfReference);
        }

        // GET: TermsOfReferences/Delete/5
        [Authorize(Roles = Role.Admin)]
        public IActionResult Delete(int id)
        {
            var termsOfReference = _repository.Find(m => m.Id == id).Include(m => m.MultiStoreyHouseProject).ToArray().FirstOrDefault();
            if (termsOfReference == null)
            {
                return NotFound();
            }

            return View(termsOfReference);
        }

        // POST: TermsOfReferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var termsOfReference = _repository.Get(id);
            await _repository.Delete(termsOfReference);
            return RedirectToAction(nameof(Index));
        }
    }
}
