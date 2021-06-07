using JobFindingAppTeamBruxemburg.Data;
using JobFindingAppTeamBruxemburg.Models;
using JobFindingAppTeamBruxemburg.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Controllers
{
    public class EmployerController : Controller
    {
        private readonly IEmployerService _employerService;

        public EmployerController(IEmployerService employerService)
        {

            _employerService = employerService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await _employerService.List(page, 10));

        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _employerService.GetEmployerDetails(id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployerModel employer)
        {
            if (!ModelState.IsValid)
            {
                return View(employer);
            }

            await _employerService.SaveEmployer(employer);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _employerService.GetEmployerForEdit(id.Value);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employer employer)
        {
            if (id != employer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _employerService.UpdateAndSave(employer);

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(employer);
        }

        // GET: Projekts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _employerService.GetEmployerDetails(id.Value);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var project = await _context.Projects.FindAsync(id);
            //_context.Projects.Remove(project);
            //await _context.SaveChangesAsync();
            //await _projectService.RemoveAndSave(id);
            await _employerService.DeleteEmployer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
