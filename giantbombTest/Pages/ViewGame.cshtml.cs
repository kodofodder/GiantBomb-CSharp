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
    public class ViewGameModel : PageModel
    {
        private readonly GiantBombRestClient _client;

        public ViewGameModel()
        {
            _client = new GiantBombRestClient("e5b38cec2a076c4dba1022ca4f95b41a8662d638");
        }

        public Game Game { get; set; }

        public void OnGet(int id)
        {
            Game = _client.GetGame(id);
           
        }
    }
}