using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardGame.GameLogic.Events;
using CardGame.GameLogic;
using CardGame.GameLogic.Commands;

namespace CardGame.Controllers
{
    public class BlackJackController : Controller
    {
        public static Blackjack _game;
        public static List<IEvent> _events;

        public BlackJackController()
        {
        }

        public ActionResult CreateGame()
        {
            var player = new Player(Guid.NewGuid());
            var dealerPlayer = new BlackjackDealerPlayer();
            var dealer = new BlackjackDealer();
            _game = new Blackjack(new[] { player, dealerPlayer }, new Deck(), dealer);

            NewBlackJackHand();

            return SetPlayerId(player.Id);
        }

        private void actionEvent(IEvent eventToProcess, bool allEvents = false)
        {
            var eventProcessor = new EventProcessor();
            var commandProcessor = new CommandProcessor();

            _events.Add(eventToProcess);

            eventProcessor.ProcessEvents(_events, _game, allEvents);
        }

        public ActionResult SetPlayerId(Guid playerId)
        {
            this.Response.Cookies.Add(new HttpCookie("CardGamePlayerId", playerId.ToString()));

            return RedirectToAction("BlackJack");
        }

        private Guid GetPlayerId()
        {
            var value = this.Request.Cookies.Get("CardGamePlayerId").Value;
            return Guid.Parse(value);
        }

        private Guid TryGetPlayerId()
        {
            var cookie = this.Request.Cookies["CardGamePlayerId"];

            //if (cookie == null)
            //    throw 

            Guid playerId;
            if (!Guid.TryParse(cookie.Value, out playerId))
                throw new Exception("Cookie doesn't have valid player id!");

            // return playerId;

            return playerId;
        }

        public ActionResult BlackJack()
        {
            if (_game == null)
                return RedirectToAction("CreateGame");

            return View(_game);
        }

        public ActionResult playerHit()
        {
            var evt = new DrawEvent() { PlayerId = GetPlayerId() };
            actionEvent(evt);
            // perform hit event!
            return RedirectToAction("BlackJack");
        }
        public ActionResult playerBet(int betAmount)
        {
            Guid playerId = TryGetPlayerId();

            var evt = new RaiseBidEvent(playerId, betAmount);
            actionEvent(evt);

            // perform bet event!
            return RedirectToAction("BlackJack");
        }
        public ActionResult playerStay()
        {
            var evt = new AdvanceTurnEvent() { PlayerId = GetPlayerId() };
            actionEvent(evt);
            return RedirectToAction("BlackJack");
        }
        public ActionResult playerFold()
        {
            var evt = new FoldEvent();
            actionEvent(evt);
            return RedirectToAction("BlackJack");
        }
        public ActionResult playerDoubleDown()
        {
            Guid playerId = TryGetPlayerId();

            var evt = new DoublingDownEvent();
            actionEvent(evt);
            return RedirectToAction("BlackJack");
        }
        public ActionResult NewBlackJackHand()
        {
            _events = new List<IEvent>();

            var evt = new NewBlackJackHandEvent();
            actionEvent(evt, true);
            return RedirectToAction("BlackJack");
        }
    }
}
