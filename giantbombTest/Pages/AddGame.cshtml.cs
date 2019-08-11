using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using giantbombTest.Models;
using GiantBomb.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GiantBomb.Api;

namespace giantbombTest.Pages
{
    public class AddGameModel : PageModel
    {
        private readonly giantbombTest.Models.dbContext _context;
        private readonly GiantBombRestClient _client;

        public AddGameModel(giantbombTest.Models.dbContext context)
        {
            _context = context;
            _client = new GiantBombRestClient("e5b38cec2a076c4dba1022ca4f95b41a8662d638");
        }

        [BindProperty]
        public GameItem GameItem { get; set; }

        public Game Game { get; set; }

        public void OnGet(int id)
        {
            Game = _client.GetGame(id);
        }

        
        public async Task<IActionResult> OnPostAsync(int id)
        {

    

            _context.GameItem.Add(GameItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        

    }
}