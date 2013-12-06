using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic
{
    public class Turn
    {
        public int RoundNumber { get; set; }
        public int Pot { get; set; }
        public int HighBid { get { return _turnOrder.Max(h => h.HighBid); } }

        private LinkedList<PlayerHand> _turnOrder;
        private LinkedListNode<PlayerHand> _currentPlayerNode;

        public Turn(IEnumerable<Player> players)
        {
            _turnOrder = new LinkedList<PlayerHand>(players.Select(p=>new PlayerHand(p)));
            _currentPlayerNode = _turnOrder.First;
        }

        public PlayerHand CurrentPlayer { get { return _currentPlayerNode.Value; } }
        public IEnumerable<PlayerHand> Players { get { return _turnOrder; } }

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

        public void RemoveFromHand(PlayerHand player)
        {
            _turnOrder.Remove(player);
        }

        public PlayerHand GetHandForPlayer(Player player)
        {
            var playerHand = Players.FirstOrDefault(h => h.Player == player);
            return playerHand;
        }
    }
}
