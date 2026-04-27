using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIT195HonorsProject.Data;
using CIT195HonorsProject.Models;

namespace CIT195HonorsProject.Pages.HardDrives
{
    public class DetailsModel : PageModel
    {
        private readonly CIT195HonorsProject.Data.CIT195HonorsProjectContext _context;

        public DetailsModel(CIT195HonorsProject.Data.CIT195HonorsProjectContext context)
        {
            _context = context;
        }

        public HardDrive HardDrive { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harddrive = await _context.HardDrives.FirstOrDefaultAsync(m => m.Id == id);

            if (harddrive is not null)
            {
                HardDrive = harddrive;

                return Page();
            }

            return NotFound();
        }
    }
}
