﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Hackathon_Day
{
    public class Program
    {
        static void Main(string[] args)
        {
			List<Card> cards = JsonToFile<Card>.ReadJson();

            Console.ForegroundColor = ConsoleColor.Red;
            foreach(var card in cards)
            {
                Console.WriteLine(card);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
