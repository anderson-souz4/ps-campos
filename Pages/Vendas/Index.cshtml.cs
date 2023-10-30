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
    public class IndexModel : PageModel
    {
        private readonly ps.Data.CRUDDBContext _context;

        public IndexModel(ps.Data.CRUDDBContext context)
        {
            _context = context;
        }

        public IList<Venda> Venda { get;set; }

        public async Task OnGetAsync()
        {
            Venda = await _context.Vendas.ToListAsync();
        }
    }
}
