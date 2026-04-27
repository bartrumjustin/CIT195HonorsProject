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
    public class IndexModel : PageModel
    {
        private readonly CIT195HonorsProject.Data.CIT195HonorsProjectContext _context;

        public IndexModel(CIT195HonorsProject.Data.CIT195HonorsProjectContext context)
        {
            _context = context;
        }

        public IList<HardDrive> HardDrive { get;set; } = default!;

        public async Task OnGetAsync()
        {
            HardDrive = await _context.HardDrives
                .Include(h => h.NodeClusters).ToListAsync();
        }
    }
}
