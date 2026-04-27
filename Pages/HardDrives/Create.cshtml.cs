using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CIT195HonorsProject.Data;
using CIT195HonorsProject.Models;

namespace CIT195HonorsProject.Pages.HardDrives
{
    public class CreateModel : PageModel
    {
        private readonly CIT195HonorsProject.Data.CIT195HonorsProjectContext _context;

        public CreateModel(CIT195HonorsProject.Data.CIT195HonorsProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["NodeClusterId"] = new SelectList(_context.NodeClusters, "Id", "NodeLocation");
            return Page();
        }

        [BindProperty]
        public HardDrive HardDrive { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.HardDrives.Add(HardDrive);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
