using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic
{
    public abstract class AIPlayer : Player
    {
        public abstract void BlackJack(Game game);
        public abstract void TexasHoldEm(Game game);
        public abstract void FiveHandPoker(Game game);
    }
}
