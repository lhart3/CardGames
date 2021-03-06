﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Events
{
    public class MatchBidEvent : IEvent
    {
        public Guid PlayerId { get; set; }

        public IEnumerable<Commands.ICommand> GenerateCommands(Game game)
        {
            var playerHand = game.Turn.Players.FirstOrDefault(h => h.Player.Id == PlayerId);

            yield return new MatchBidCommand() { Player = playerHand.Player };
        }
    }

    public class RaiseBidEvent : IEvent
    {
        public Guid PlayerId { get; set; }
        public int BidAmount { get; set; }

        public RaiseBidEvent(Guid playerId, int bidAmount)
        {
            PlayerId = playerId;
            BidAmount = bidAmount;
        }

        public IEnumerable<ICommand> GenerateCommands(Game game)
        {
            var playerHand = game.Turn.Players.FirstOrDefault(h => h.Player.Id == PlayerId);

            yield return new BidCommand() { Player = playerHand.Player, BidAmount = BidAmount };
        }
    }
    public class AnteBidEvent : IEvent
    {
        public Guid PlayerId { get; set; }
        public int BidAmount { get; set; }

        public IEnumerable<ICommand> GenerateCommands(Game game)
        {
            var playerHand = game.Turn.Players.FirstOrDefault(h => h.Player.Id == PlayerId);

            yield return new BidCommand() { Player = playerHand.Player, BidAmount = 25 };
        }
    }
}
