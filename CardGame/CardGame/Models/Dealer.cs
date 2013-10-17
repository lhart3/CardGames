using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.Models
{
    public abstract class Dealer
    {
        public abstract void Deal(Deck deck, int count, Player player);
    }
}