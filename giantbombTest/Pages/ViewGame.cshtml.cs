using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GiantBomb.Api;
using GiantBomb.Api.Model;
using giantbombTest.Models;

namespace giantbombTest.Pages
{
    public class ViewGameModel : PageModel
    {
        private readonly giantbombTest.Models.dbContext _context;
        private readonly GiantBombRestClient _client;

        public ViewGameModel(giantbombTest.Models.dbContext context)
        {
            _context = context;
            _client = new GiantBombRestClient("e5b38cec2a076c4dba1022ca4f95b41a8662d638");
        }

        public GameItem GameItem { get; set; }
        public Game Game { get; set; }

        public void OnGet(int id)
        {
            GameItem = _context.GameItem.Find(id);
            Game = _client.GetGame(GameItem.GbID);
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            GameItem = await _context.GameItem.FindAsync(id);

            if (GameItem != null)
            {
                _context.GameItem.Remove(GameItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}