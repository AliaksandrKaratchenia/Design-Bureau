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
    public class PriceDetailsController : Controller
    {
        private readonly IRepository<PriceDetails> _repository;

        public PriceDetailsController(IRepository<PriceDetails> repository)
        {
            _repository = repository;
        }

        // GET: PriceDetails
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAll().ToListAsync());
        }

        // GET: PriceDetails/Details/5
        public IActionResult Details(int? id)
        {
            var details = _repository.Find(m => m.Id == id).Include(m => m.MultiStoreyHouseProject).ToArray().FirstOrDefault();
            if (details == null)
            {
                return NotFound();
            }

            return View(details);
        }

        // GET: PriceDetails/Create
        [Authorize(Roles = Role.Admin)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: PriceDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Create([Bind("DesignCost,ConstructionCost,Id")] PriceDetails priceDetails)
        {
            if (ModelState.IsValid)
            {
                await _repository.Insert(priceDetails);
                return RedirectToAction(nameof(Index));
            }
            return View(priceDetails);
        }

        // GET: PriceDetails/Edit/5
        [Authorize(Roles = Role.Admin)]
        public IActionResult Edit(int id)
        {
            var priceDetails = _repository.Get(id);
            if (priceDetails == null)
            {
                return NotFound();
            }
            return View(priceDetails);
        }

        // POST: PriceDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Edit(int id, [Bind("DesignCost,ConstructionCost,Id")] PriceDetails priceDetails)
        {
            if (id != priceDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _repository.Update(priceDetails);
                return RedirectToAction(nameof(Index));
            }
            return View(priceDetails);
        }

        // GET: PriceDetails/Delete/5
        [Authorize(Roles = Role.Admin)]
        public IActionResult Delete(int id)
        {
            var priceDetails = _repository.Find(m => m.Id == id).Include(m => m.MultiStoreyHouseProject).ToArray().FirstOrDefault();
            if (priceDetails == null)
            {
                return NotFound();
            }

            return View(priceDetails);
        }

        // POST: PriceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var priceDetails = _repository.Get(id);
            await _repository.Delete(priceDetails);
            return RedirectToAction(nameof(Index));
        }
    }
}
