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
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {

            _tagService = tagService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await _tagService.List(page, 10));

        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var tag = await _tagService.GetTagDetails(id);
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
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagModel tag)
        {
            if (!ModelState.IsValid)
            {
                return View(tag);
            }

            await _tagService.SaveTag(tag);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _tagService.GetTagForEdit(id.Value);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Tag tag)
        {
            if (id != tag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _tagService.UpdateAndSave(tag);

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(tag);
        }

        // GET: Projekts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _tagService.GetTagDetails(id.Value);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var project = await _context.Projects.FindAsync(id);
            //_context.Projects.Remove(project);
            //await _context.SaveChangesAsync();
            //await _projectService.RemoveAndSave(id);
            await _tagService.DeleteTag(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
