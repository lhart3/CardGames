using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Events;

namespace CardGame.GameLogic.Commands
{
    public class DrawCommand : ICommand
    {
        public Player Player { get; set; }
        public int DrawCount { get; set; }

        public DrawCommand(Player player, int drawCount)
        {
            Player = player;
            DrawCount = drawCount;
        }

        public IEnumerable<IEvent> Process(Game game)
        {
            var playerHand = game.Turn.GetHandForPlayer(Player);
            game.Dealer.DealForCurrentRound(game.Deck, playerHand, DrawCount);

            return Enumerable.Empty<IEvent>();
        }
    }
}
