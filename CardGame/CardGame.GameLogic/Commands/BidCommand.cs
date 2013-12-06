using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Events;

namespace CardGame.GameLogic.Commands
{

    public class BidCommand : ICommand
    {
        public Player Player { get; set; }
        public int BidAmount{ get; set; }

        public virtual IEnumerable<IEvent> Process(Game game)
        {
            // either bid the requested amount, or go all in
            var bid = Math.Min(BidAmount, Player.Currency);

            Player.Currency = Player.Currency - bid;
            game.Turn.Pot = game.Turn.Pot + bid;
            game.Turn.CurrentPlayer.HighBid += bid;

            return Enumerable.Empty<IEvent>();
        }
    }

    public class MatchBidCommand : BidCommand
    {
        public override IEnumerable<IEvent> Process(Game game)
        {
            var playerHand = game.Turn.GetHandForPlayer(Player);
            BidAmount = game.Turn.HighBid - playerHand.HighBid;

            return base.Process(game);
        }
    }
}
