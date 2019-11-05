using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

/** Exercise 2: 31/10/19
    Written by Dylan Sukha for Valocity.
*/

namespace exTwo
{
    /// <summary>Class <c>Card</c> Holds the card type (A,2,3...K) and
    /// group (hearts, diamonds, etc...).</summary>
    ///
    public class Card
    {
        private string cardType;
        private char cardGroup;
        private bool isFlipped = false;

        public Card(string type, char group) //Primary constructor.
        {
            //Console.WriteLine("Type: " + type + " Group: " + group);
            cardType = type; cardGroup = group;
        }

        public Card(string type, char group, bool flip) //Constructor if 'flipping' a card's state is required.
        {
            cardType = type; cardGroup = group; isFlipped = flip;
        }

        public string getCard() //Securely returns a card summary.
        {
            return (cardType + "-" + cardGroup + " is flipped? " + isFlipped);
        }

    }

    /// <summary>Class <c>Deck</c> hold the list of cards
    /// with special functions.</summary>
    ///
    public class Deck
    {
        public List<Card> cardDeck = new List<Card>();
        public Deck()
        {
            Console.WriteLine("Empty Deck Created!");
        }
        /** addSampleCards() is a method that adds a generic deck of cards for testing purposes.
            Key: H = Hearts, D = Diamonds, S = Spades, C = Clubs*/
        public void addSampleCards()
        {
            for (int i = 2; i < 11; i++)
            {
                cardDeck.Add(new Card(i.ToString(), 'H'));
                cardDeck.Add(new Card(i.ToString(), 'D'));
                cardDeck.Add(new Card(i.ToString(), 'S'));
                cardDeck.Add(new Card(i.ToString(), 'C'));
            }
            cardDeck.Add(new Card("A", 'H')); cardDeck.Add(new Card("A", 'D'));
            cardDeck.Add(new Card("A", 'S')); cardDeck.Add(new Card("A", 'C'));
            cardDeck.Add(new Card("J", 'H')); cardDeck.Add(new Card("J", 'D'));
            cardDeck.Add(new Card("J", 'S')); cardDeck.Add(new Card("J", 'C'));
            cardDeck.Add(new Card("Q", 'H')); cardDeck.Add(new Card("J", 'D'));
            cardDeck.Add(new Card("Q", 'S')); cardDeck.Add(new Card("J", 'C'));
            cardDeck.Add(new Card("K", 'H')); cardDeck.Add(new Card("J", 'D'));
            cardDeck.Add(new Card("K", 'S')); cardDeck.Add(new Card("J", 'C'));
            Console.WriteLine(cardDeck.Count + " cards added.");
        }

        public void shuffleDeck()
        { //Adapted Fisher-Yates shuffle from: https://www.dotnetperls.com/shuffle
            Random _random = new Random();
            int j = cardDeck.Count;
            for (int i = 0; i < j; i++)
            {

                int r = i + _random.Next(j - i);
                Card t = cardDeck[r]; //Temp card placeholder.
                cardDeck[r] = cardDeck[i];
                cardDeck[i] = t;
            }
            Console.WriteLine(cardDeck.Count + " cards remaining.");
        }
        /* TODO: Pickup function. Commented lines may aid direction. (Scaffolding).
        public Card pickup()
        {
            //Card temp = cardDeck[carddeck.Count - 1]; //Making the end of desk will require less computation. (O(1) < O(n))
            //cardDeck.Remove(temp);
            //return temp;
        } */

    }
    /// <summary>Class <c>Hand</c> The cards in each player's 'hand'. </summary>
    ///
    /*
    public class Card
    {
        //TODO: (Scaffolding)
        //-Make a List or array of type *Cards*.
        //-Implement methods that may be useful depending on the game, i.e. pickup, discard etc...

    } 
    */
    /// <summary>Class <c>Program</c> where the test routine is called.</summary>
    ///
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**Card Game Test Program**");
            System.Threading.Thread.Sleep(1000); //Delay of 1 second.
            Deck gameDeck = new Deck();
            gameDeck.addSampleCards(); //Adding cards to deck.
            Console.WriteLine("Loading preview of cards in order...");
            System.Threading.Thread.Sleep(2000);
            for (int i = 0; i < gameDeck.cardDeck.Count; i++)
            {
                Console.WriteLine(gameDeck.cardDeck[i].getCard()); //Previewing unshuffled deck.
            }
            Console.WriteLine("Shuffling...");
            System.Threading.Thread.Sleep(2000);
            gameDeck.shuffleDeck();
            Console.WriteLine("Loading preview of shuffled deck...");
            System.Threading.Thread.Sleep(2000);
            for (int i = 0; i < gameDeck.cardDeck.Count; i++)
            {
                Console.WriteLine(gameDeck.cardDeck[i].getCard()); //Result of shuffled deck.
            }
            Console.WriteLine("Cards have been shuffled. Press enter to end test.");
            Console.ReadLine();
        }
    }
}
