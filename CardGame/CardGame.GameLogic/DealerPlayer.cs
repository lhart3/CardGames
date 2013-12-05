using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace CardGame.GameLogic
{
    public class DealerPlayer : AIPlayerGames
    {
        public DealerState state = DealerState.Init;
        public bool alive = true;
        private Deck deck;
        private IEnumerable<PlayerHand> players;
        public void StartUp()
        {
            alive = true;
            state = DealerState.Init;
        }
        public void FSM(Game game)
        {
            while (alive)
            {
                switch (state)
                {
                    case DealerState.Init:
                        Init(game);
                        break;
                    case DealerState.Setup:
                        Setup(game);
                        break;
                    case DealerState.Deal:
                        Deal(game);
                        break;
                    case DealerState.Checking:
                        Checking(game);
                        break;
                    case DealerState.Hit:
                        Hit(game);
                        break;
                    case DealerState.EndGame:
                        EndGame(game);
                        break;
                }
            }
        }
        private void Init(Game game)
        {
            game.Turn = new GameLogic.Turn(game.Players);
            game.Discard.Clear();
            state = DealerState.Setup;
        }
        private void Setup(Game game)
        {
            deck = new Deck();
            players = game.Turn.Players;
            state = DealerState.Deal;
        }
        private void Deal(Game game)
        {
            game.Dealer.DealStartingHand(deck, players);
            state = DealerState.Checking;
        }
        private void Checking(Game game)
        {
            foreach(PlayerHand ph in players)
            {
                
            }
        }
        private void Hit(Game game)
        {
            game.Turn.CurrentPlayer.Hand.Add(game.Deck.Draw());
            state = DealerState.Checking;
        }
        private void EndGame(Game game)
        {
            alive = false;
        }
    }
    public enum DealerState
    {
        Init,
        Setup,
        Deal,
        Checking,
        Hit,
        EndGame
    }
}