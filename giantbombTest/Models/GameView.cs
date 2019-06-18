using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiantBomb.Api.Model;

namespace giantbombTest.Models
{
    public class GameView
    {
        public GameItem GameItem;
        public GiantBomb.Api.Model.Game Game;

        public GameView(GameItem gameItem, Game game)
        {
            GameItem = gameItem;
            Game = game;
        }
    }
}
