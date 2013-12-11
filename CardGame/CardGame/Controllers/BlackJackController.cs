﻿using System;
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
        public static Game _game;

        public ActionResult CreateNewGame()
        {
            var player = new Player(Guid.NewGuid());
            _game = new Blackjack(new[] { player }, new Deck(), null);

            return SetPlayerId(player.Id);
        }
        private void actionEvent(IEvent eventToProcess)
        {
            var eventProcessor = new EventProcessor();
            var commandProcessor = new CommandProcessor();

            var commands = eventProcessor.ProcessEvents(new List<IEvent> { eventToProcess }, _game, true);

            commandProcessor.ProcessCommands(_game, commands);
        }
        public ActionResult SetPlayerId(Guid playerId)
        {
            this.Response.Cookies.Add(new HttpCookie("CardGamePlayerId", playerId.ToString()));

            return RedirectToAction("BlackJack");
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
            return View();
        }
        public ActionResult playerHit()
        {
            var evt = new DrawEvent();
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
            var evt = new AdvanceTurnEvent();
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
            var evt = new NewBlackJackHandEvent();
            actionEvent(evt);
            return RedirectToAction("BlackJack");
        }
    }
}
