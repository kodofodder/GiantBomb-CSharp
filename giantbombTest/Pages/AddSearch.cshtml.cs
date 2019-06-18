using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiantBomb.Api;
using GiantBomb.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace giantbombTest.Pages
{
    public class AddSearchModel : PageModel
    {
        private readonly GiantBombRestClient _client;

        public AddSearchModel()
        {
            _client = new GiantBombRestClient("e5b38cec2a076c4dba1022ca4f95b41a8662d638");
        }

        public IList<Game> Games { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

       
        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                var results = await _client.SearchForGamesAsync(SearchString);
                //filters out unreleased games
                results = from game in results
                          where game.OriginalReleaseDate != null
                          select game;

                //results = results.OrderByDescending(g => g.OriginalReleaseDate);
                Games = results.ToList();
            }
        }
    }
}
