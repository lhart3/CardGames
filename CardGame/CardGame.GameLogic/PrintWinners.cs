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
    public partial class PrintWinners :Form 
    {
        public PrintWinners(Blackjack game)
        {
            var blackjackGame = (Blackjack)game;
            if(blackjackGame.IsGameOver)
            {
                foreach (Player winner in blackjackGame.WinnerList)
                {
                    foreach(Player loser in blackjackGame.Loserlist)
                    {
                        if (winner.GetType() == typeof(BlackjackDealerPlayer))
                        {
                            MessageBox.Show("The winner is Dealer. The loser is Player.");
                        }
                        else
                        {
                            MessageBox.Show("The winner is Player. The loser is Dealer.");
                        }
                    } 
                }
            }
        }
    }
}
