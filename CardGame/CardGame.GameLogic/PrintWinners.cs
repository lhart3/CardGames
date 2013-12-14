using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CardGame.GameLogic;

namespace CardGame.GameLogic
{
    public partial class PrintWinners : Form
    {
        public PrintWinners(Blackjack game)
        {
            int playercounter = 0;
            int computercounter = 0;
            var blackjackGame = (Blackjack)game;
            if (blackjackGame.IsGameOver)
            {
                foreach (Player winner in blackjackGame.WinnerList)
                {
                    foreach (Player loser in blackjackGame.Loserlist)
                    {
                        if (winner.GetType() == typeof(AIPlayerGames))
                        {
                            computercounter++;
                            MessageBox.Show("The winner is Computer Player" + computercounter + ". The loser is Dealer.");
                        }
                        else if (winner.GetType() == typeof(BlackjackDealerPlayer) && loser.GetType() == typeof(AIPlayerGames))
                        {
                            computercounter++;
                            MessageBox.Show("The winner is Dealer. The loser is Computer" + computercounter + ".");
                        }
                        else if (winner.GetType() == typeof(BlackjackDealerPlayer))
                        {
                            playercounter++;
                            MessageBox.Show("The winner is Dealer. The loser is Player" + playercounter + ".");
                        }
                        else
                        {
                            playercounter++;
                            MessageBox.Show("The winner is Player" + playercounter + ". The loser is Dealer.");
                        }
                    }
                }
            }
        }
    }
}
