using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ps.Data;
using ps.Models;

namespace ps.Pages_Vendas
{
    public class DetailsModel : PageModel
    {
        private readonly ps.Data.CRUDDBContext _context;

        public DetailsModel(ps.Data.CRUDDBContext context)
        {
            _context = context;
        }

        public Venda Venda { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venda = await _context.Vendas.FirstOrDefaultAsync(m => m.Id == id);

            if (Venda == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
