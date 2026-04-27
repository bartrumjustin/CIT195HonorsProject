using CIT195HonorsProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CIT195HonorsProject.Pages.NodeClusters
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
            return Page();
        }

        [BindProperty]
        public NodeCluster NodeCluster { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _context.NodeClusters.Add(NodeCluster);
                // This is the ONLY request made to the database
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException)
            {
                Console.WriteLine("Location already being used");
                // If the database rejects the entry due to the Unique Index
                ModelState.AddModelError("NodeCluster.NodeLocation", "That Node Location is already occupied. Please enter another location.");
                return Page();
            }




        }
    }
}
