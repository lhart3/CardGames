using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Events;

namespace CardGame.GameLogic.Commands
{
    class DoublingDownCommand : ICommand
    {
        public virtual IEnumerable<IEvent> Process(Game game)
        {
            //Blackjack f;

            //f = (Blackjack)game;
           // f.DoublingDown(
            return Enumerable.Empty<IEvent>();
        }
    }
}
