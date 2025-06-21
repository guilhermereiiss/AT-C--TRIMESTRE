using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgenciaViagem.Models;

namespace AgenciaViagem.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly AgenciaViagemContext _context;

        public IndexModel(AgenciaViagemContext context)
        {
            _context = context;
        }

        public IList<Cliente> Clientes { get; set; } = default!; 

        [BindProperty]
        public string NomeCompleto { get; set; } = string.Empty;
        [BindProperty]
        public string EnderecoEmail { get; set; } = string.Empty;
        [BindProperty]
        public string NumeroTelefone { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            Clientes = await _context.Clientes.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(NomeCompleto))
            {
                var cliente = new Cliente
                {
                    NomeCompleto = NomeCompleto,
                    EnderecoEmail = EnderecoEmail,
                    NumeroTelefone = NumeroTelefone
                };
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}