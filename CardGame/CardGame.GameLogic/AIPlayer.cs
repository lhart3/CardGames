using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic
{
    public abstract class AIPlayer : Player
    {
        public AIPlayer()
            : base(Guid.NewGuid())
        {
        }

        public abstract void Play(Game game);
    }
}
