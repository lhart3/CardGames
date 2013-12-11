using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Events;

namespace CardGame.GameLogic.Commands
{
    class DoublingDownCommand : ICommand
    {
        public Player Player { get; set; }
        public bool DoubleDown { get; set; }

        public virtual IEnumerable<IEvent> Process(Game game)
        {
               var playerHand = game.Turn.GetHandForPlayer(Player);
               Blackjack f;

               f = (Blackjack)game;
               f.DoublingDown(playerHand);
               return Enumerable.Empty<IEvent>();
        }
    }
}
