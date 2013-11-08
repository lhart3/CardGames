using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic.Commands
{

    class BidCommand : ICommand
    {
        public Player Player { get; set; }
        public int BidAmount{ get; set; }

        public virtual void Process(Game game)
        {
            // either bid the requested amount, or go all in
            var bid = Math.Min(BidAmount, Player.Currency);

            Player.Currency = Player.Currency - bid;
            game.Turn.Pot = game.Turn.Pot + bid;
            game.Turn.CurrentPlayer.HighBid += bid;
        }
    }

    public class MatchCommand : BidCommand
    {
        public override void Process(Game game)
        {
            var playerHand = game.Turn.Players.FirstOrDefault(h => h.Player == Player);
            BidAmount = game.Turn.HighBid - playerHand.HighBid;

            base.Process(game);
        }
    }
}
