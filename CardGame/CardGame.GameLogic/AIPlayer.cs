using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic
{
    public abstract class AIPlayer : Player
    {
        public abstract void PlayGame(Game game);
    }
}
