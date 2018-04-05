using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Hackathon_Day
{
    public class Deck
    {
        List<Card> cards = JsonToFile<Card>.ReadJson();
        public List<Card> dealCards()
        {
            return cards.ToList();
        }
        public List<Card> resetCards()
        {
            return new List<Card>();
        }
    }
}







