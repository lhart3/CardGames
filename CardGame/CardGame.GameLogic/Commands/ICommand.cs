using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic.Commands
{
    public interface ICommand
    {
        void Process(Game game);
    }
}
