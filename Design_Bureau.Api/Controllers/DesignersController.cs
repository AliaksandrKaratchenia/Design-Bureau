using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Design_Bureau.DAL;
using Design_Bureau.Entities;
using Design_Bureau.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Design_Bureau.BLL.Authentication__Authorization.Models;

namespace Design_Bureau.Api.Controllers
{
    [Authorize]
    public class DesignersController : Controller
    {
        private readonly IRepository<Designer> _repository;

        public DesignersController(IRepository<Designer> repository)
        {
            _repository = repository;
        }

        // GET: Designers
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAll().ToListAsync());
        }

        // GET: Designers/Create
        [Authorize(Roles = Role.Admin)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Designers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Create([Bind("Name,Id")] Designer designer)
        {
            if (ModelState.IsValid)
            {
                await _repository.Insert(designer);
                return RedirectToAction(nameof(Index));
            }
            return View(designer);
        }

        // GET: Designers/Delete/5
        public IActionResult Delete(int id)
        {
            var designer = _repository.Find(m => m.Id == id).Include(m => m.MultiStoreyHouseProject).ToArray().FirstOrDefault();
            if (designer == null)
            {
                return NotFound();
            }

            return View(designer);
        }

        // POST: Designers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var designer = _repository.Get(id);
            await _repository.Delete(designer);
            return RedirectToAction(nameof(Index));
        }
    }
}
