using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Hackathon_Day
{
    public class Player
    {
        public Player(string name)
        {
            this.name = name;
        }
        public string name;
        public int roundsWon = 0;
        public int gamesWon = 0;
        public List<Card> hand = new List<Card>();
        public List<Card> playedCards = new List<Card>();
        public void resetCards()
        {
            this.hand.Clear();
        }
        public override string ToString()
        {
            return this.name;
        }

    }
}