using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIT195HonorsProject.Data;
using CIT195HonorsProject.Models;

namespace CIT195HonorsProject.Pages.NodeClusters
{
    public class DeleteModel : PageModel
    {
        private readonly CIT195HonorsProject.Data.CIT195HonorsProjectContext _context;

        public DeleteModel(CIT195HonorsProject.Data.CIT195HonorsProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NodeCluster NodeCluster { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nodecluster = await _context.NodeClusters.FirstOrDefaultAsync(m => m.Id == id);

            if (nodecluster is not null)
            {
                NodeCluster = nodecluster;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nodecluster = await _context.NodeClusters.FindAsync(id);
            if (nodecluster != null)
            {
                NodeCluster = nodecluster;
                _context.NodeClusters.Remove(NodeCluster);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
