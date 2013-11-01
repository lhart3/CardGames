using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic
{
    public class Turn
    {
        public int RoundNumber { get; set; }

        private LinkedList<Player> _turnOrder;
        private LinkedListNode<Player> _currentPlayerNode;

        public Player CurrentPlayer { get { return _currentPlayerNode.Value; } }

        public bool AdvanceToNextPlayer()
        {
            _currentPlayerNode = _currentPlayerNode.Next;

            if (_currentPlayerNode == null)
            {
                _currentPlayerNode = _turnOrder.First;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
