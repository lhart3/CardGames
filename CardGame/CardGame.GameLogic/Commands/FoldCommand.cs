using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic.Commands
{
    public class FoldCommand : ICommand
    {
        public Player Player { get; set; }
 
        public void Process(Game game)
        {
            game.Turn.RemoveFromHand(Player);
            game.Discard.AddRange(Player.Hand);
            Player.Hand.Clear();
        }
    }
}
