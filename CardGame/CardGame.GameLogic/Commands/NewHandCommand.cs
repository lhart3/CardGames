using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic.Commands
{
    class NewBlackJackHandCommand : ICommand
    {
        public virtual void Process(Game game)
        {
            DealerPlayer dp = new DealerPlayer();
            dp.BlackJackStartUp();
            dp.DealerBlackJackFSM(game);
        }
    }
}
