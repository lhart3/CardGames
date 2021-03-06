﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Events
{
    public class DrawEvent : EventBase
    {
        public override IEnumerable<Commands.ICommand> GenerateCommands(Game game)
        {
            var player = game.Players.Single(p => p.Id == PlayerId);
            yield return new DrawCommand(player, 1);
        }
    }
}
