using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GiantBomb.Api;
using GiantBomb.Api.Model;

namespace giantbombTest.Pages
{
    public class TestPageModel : PageModel
    {
              
        private readonly GiantBombRestClient _client;

        public TestPageModel()
        {
            _client = new GiantBombRestClient("e5b38cec2a076c4dba1022ca4f95b41a8662d638");
        }

        public IList<Game> Games { get; set; }

        public void OnGet() {            
            var results = _client.SearchForAllGames("Assassins Creed");
            var query = from game in results
                        where game.OriginalReleaseDate != null
                        select game;
            Games = results.ToList();
        }
    }
}
