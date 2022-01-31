using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Vehicle.API.Data;
using Vehicle.API.Data.Entities;

namespace Vehicle.API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DocumentTypesController : Controller
    {
        private readonly DataContext _context;

        public DocumentTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: VehicleTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DocumentTypes.ToListAsync());
        }


        // GET: DocumentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentTypes documentType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(documentType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de documento.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(documentType);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentTypes = await _context.DocumentTypes.FindAsync(id);
            if (documentTypes == null)
            {
                return NotFound();
            }
            return View(documentTypes);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DocumentTypes documentTypes)
        {
            if (id != documentTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentTypes);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de vehículo.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(documentTypes);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentTypes = await _context.DocumentTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentTypes == null)
            {
                return NotFound();
            }
            _context.DocumentTypes.Remove(documentTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
