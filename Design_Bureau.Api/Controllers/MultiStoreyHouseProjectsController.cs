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

namespace Design_Bureau.Api.Controllers
{
    [Authorize]
    public class MultiStoreyHouseProjectsController : Controller
    {
        private readonly IRepository<MultiStoreyHouseProject> _projectRepository;
        private readonly IRepository<Designer> _designerRepository;
        private readonly IRepository<PriceDetails> _priceDetailsRepository;
        private readonly IRepository<ChiefDesigner> _chiefDesignerRepository;
        private readonly IRepository<TermsOfReference> _termsOfReferenceRepository;
        private readonly IRepository<Customer> _customerRepository;

        public MultiStoreyHouseProjectsController(
            IRepository<MultiStoreyHouseProject> projectRepository,
            IRepository<Designer> designerRepository,
            IRepository<PriceDetails> priceDetailsRepository,
            IRepository<ChiefDesigner> chiefDesignerRepository,
            IRepository<TermsOfReference> termsOfReferenceRepository,
            IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
            _termsOfReferenceRepository = termsOfReferenceRepository;
            _chiefDesignerRepository = chiefDesignerRepository;
            _priceDetailsRepository = priceDetailsRepository;
            _designerRepository = designerRepository;
            _projectRepository = projectRepository;
        }

        // GET: MultiStoreyHouseProjects
        public async Task<IActionResult> Index()
        {
            var multiStoreyHouseProjects = _projectRepository
                .GetAll()
                .Include(m => m.ChiefDesigner)
                .Include(m => m.Customer)
                .Include(m => m.PriceDetails)
                .Include(m => m.TermsOfReference);
            return View(await multiStoreyHouseProjects.ToListAsync());
        }

        // GET: MultiStoreyHouseProjects/Details/5
        public IActionResult Details(int id)
        {
            var multiStoreyHouseProject = _projectRepository
                .Find(m => m.Id == id)
                .Include(m => m.ChiefDesigner)
                .Include(m => m.Customer)
                .Include(m => m.PriceDetails)
                .Include(m => m.TermsOfReference)
                .Include(m => m.Designers)
                .ToArray().FirstOrDefault();

            if (multiStoreyHouseProject == null)
            {
                return NotFound();
            }

            return View(multiStoreyHouseProject);
        }

        // GET: MultiStoreyHouseProjects/Create
        public IActionResult Create()
        {
            ViewData["ChiefDesignerId"] = new SelectList(_chiefDesignerRepository.GetAll().ToList(), "Id", "Name");
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll().ToList(), "Id", "Name");
            ViewData["PriceDetailsId"] = new SelectList(_priceDetailsRepository.GetAll().ToList(), "Id", "Id");
            ViewData["TermsOfReferenceId"] = new SelectList(_termsOfReferenceRepository.GetAll().ToList(), "Id", "Name");
            return View();
        }

        // POST: MultiStoreyHouseProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CustomerId,TermsOfReferenceId,PriceDetailsId,ChiefDesignerId,Id")] MultiStoreyHouseProject multiStoreyHouseProject)
        {
            if (ModelState.IsValid)
            {
                await _projectRepository.Insert(multiStoreyHouseProject);
                return RedirectToAction(nameof(Index));
            }

            ViewData["ChiefDesignerId"] = new SelectList(_chiefDesignerRepository.GetAll().ToList(), "Id", "Name");
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll().ToList(), "Id", "Name");
            ViewData["PriceDetailsId"] = new SelectList(_priceDetailsRepository.GetAll().ToList(), "Id", "Id");
            ViewData["TermsOfReferenceId"] = new SelectList(_termsOfReferenceRepository.GetAll().ToList(), "Id", "Name");
            return View(multiStoreyHouseProject);
        }
        ////
        ////        // GET: MultiStoreyHouseProjects/Edit/5
        ////        public async Task<IActionResult> Edit(int? id)
        ////        {
        ////            if (id == null)
        ////            {
        ////                return NotFound();
        ////            }
        ////
        ////            var multiStoreyHouseProject = await _context.MultiStoreyHouseProjects.FindAsync(id);
        ////            if (multiStoreyHouseProject == null)
        ////            {
        ////                return NotFound();
        ////            }
        ////            ViewData["ChiefDesignerId"] = new SelectList(_context.ChiefDesigners, "Id", "Name", multiStoreyHouseProject.ChiefDesignerId);
        ////            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", multiStoreyHouseProject.CustomerId);
        ////            ViewData["PriceDetailsId"] = new SelectList(_context.PriceDetails, "Id", "Id", multiStoreyHouseProject.PriceDetailsId);
        ////            ViewData["TermsOfReferenceId"] = new SelectList(_context.TermsOfReferences, "Id", "Description", multiStoreyHouseProject.TermsOfReferenceId);
        ////            return View(multiStoreyHouseProject);
        ////        }
        ////
        ////        // POST: MultiStoreyHouseProjects/Edit/5
        ////        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        ////        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        ////        [HttpPost]
        ////        [ValidateAntiForgeryToken]
        ////        public async Task<IActionResult> Edit(int id, [Bind("Name,CustomerId,TermsOfReferenceId,PriceDetailsId,ChiefDesignerId,Id")] MultiStoreyHouseProject multiStoreyHouseProject)
        ////        {
        ////            if (id != multiStoreyHouseProject.Id)
        ////            {
        ////                return NotFound();
        ////            }
        ////
        ////            if (ModelState.IsValid)
        ////            {
        ////                try
        ////                {
        ////                    _context.Update(multiStoreyHouseProject);
        ////                    await _context.SaveChangesAsync();
        ////                }
        ////                catch (DbUpdateConcurrencyException)
        ////                {
        ////                    if (!MultiStoreyHouseProjectExists(multiStoreyHouseProject.Id))
        ////                    {
        ////                        return NotFound();
        ////                    }
        ////                    else
        ////                    {
        ////                        throw;
        ////                    }
        ////                }
        ////                return RedirectToAction(nameof(Index));
        ////            }
        ////            ViewData["ChiefDesignerId"] = new SelectList(_context.ChiefDesigners, "Id", "Name", multiStoreyHouseProject.ChiefDesignerId);
        ////            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", multiStoreyHouseProject.CustomerId);
        ////            ViewData["PriceDetailsId"] = new SelectList(_context.PriceDetails, "Id", "Id", multiStoreyHouseProject.PriceDetailsId);
        ////            ViewData["TermsOfReferenceId"] = new SelectList(_context.TermsOfReferences, "Id", "Description", multiStoreyHouseProject.TermsOfReferenceId);
        ////            return View(multiStoreyHouseProject);
        ////        }
        ////
        ////        // GET: MultiStoreyHouseProjects/Delete/5
        ////        public async Task<IActionResult> Delete(int? id)
        ////        {
        ////            if (id == null)
        ////            {
        ////                return NotFound();
        ////            }
        ////
        ////            var multiStoreyHouseProject = await _context.MultiStoreyHouseProjects
        ////                .Include(m => m.ChiefDesigner)
        ////                .Include(m => m.Customer)
        ////                .Include(m => m.PriceDetails)
        ////                .Include(m => m.TermsOfReference)
        ////                .FirstOrDefaultAsync(m => m.Id == id);
        ////            if (multiStoreyHouseProject == null)
        ////            {
        ////                return NotFound();
        ////            }
        ////
        ////            return View(multiStoreyHouseProject);
        ////        }
        ////
        ////        // POST: MultiStoreyHouseProjects/Delete/5
        ////        [HttpPost, ActionName("Delete")]
        ////        [ValidateAntiForgeryToken]
        ////        public async Task<IActionResult> DeleteConfirmed(int id)
        ////        {
        ////            var multiStoreyHouseProject = await _context.MultiStoreyHouseProjects.FindAsync(id);
        ////            _context.MultiStoreyHouseProjects.Remove(multiStoreyHouseProject);
        ////            await _context.SaveChangesAsync();
        ////            return RedirectToAction(nameof(Index));
        ////        }
        ////
        ////        private bool MultiStoreyHouseProjectExists(int id)
        ////        {
        ////            return _context.MultiStoreyHouseProjects.Any(e => e.Id == id);
        ////        }
    }
}
