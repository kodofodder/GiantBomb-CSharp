using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiantBomb.Api;
using GiantBomb.Api.Model;
using giantbombTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace giantbombTest.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly giantbombTest.Models.dbContext _context;
        private readonly GiantBombRestClient _client;

        public IndexModel(giantbombTest.Models.dbContext context)
        {
            _context = context;
            _client = new GiantBombRestClient("e5b38cec2a076c4dba1022ca4f95b41a8662d638");
        }

        public IList<GameItem> GameEntry { get; set; }
        public IList<GameView> Games { get; set; }

        public async Task OnGet()
        {
            GameEntry = await _context.GameItem.ToListAsync();
            Games = new List<GameView>();
            foreach (var entry in GameEntry)
            {
                Games.Add(new GameView(entry, _client.GetGame(entry.GbID)));
            }
            
        }
        
    }
}
