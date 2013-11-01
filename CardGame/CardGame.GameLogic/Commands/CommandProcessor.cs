using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands.Turn;

namespace CardGame.GameLogic.Commands
{
    public class CommandProcessor
    {
        private List<ICommand> _allCommandsEver = new List<ICommand>();

        public void ProcessCommands(Game game, IEnumerable<ICommand> commands)
        {
            foreach (var command in commands)
                command.Process(game);

            // 'log' the commands
            _allCommandsEver.AddRange(commands);
        }
    }
}
