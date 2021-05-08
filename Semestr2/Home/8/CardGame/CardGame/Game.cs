using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Game
    {
        MyList<Card> Deck = new MyList<Card>();
        List<Player> Players = new List<Player>();

        public void GenDeck()
        {
            foreach (Card.RANKS rank in Enum.GetValues(typeof(Card.RANKS)))
            {
                foreach (Card.SUITS suit in Enum.GetValues(typeof(Card.SUITS)))
                {
                    Deck.Add(new Card { Suit = suit, Rank = rank });
                }
            }

            Deck.Shuffle();
        }
        public void CreatePlayers(int i)
        {
            for (int t = 0; t < i; t++)
                Players.Add(new Player { PlayerId = t });
        }
        public void CardDistribution()
        {
            int player = 0;
            foreach (Card card in Deck)
            {
                if (player == Players.Count) player = 0;
                Players[player++].AddCard(card);
            }
        }
        public Player Move()
        {
            List<Card> PlayDeck = new List<Card>();

            Player winerPlayer = null;
            int winerCard = -1;

            foreach (Player player in Players)
                if (player.GetCardCount() > 0)
                {
                    Card moveCard = player.GetCard();
                    PlayDeck.Add(moveCard);

                    if (moveCard.Rank.GetHashCode() > winerCard)
                    {
                        winerCard = moveCard.Rank.GetHashCode();
                        winerPlayer = player;
                    }
                }

            PlayDeck.Reverse();// правильно ложимо карти в колоду
            winerPlayer.TakeAllDeck(PlayDeck);

            if (winerPlayer.GetCardCount() == Deck.Count)
                return winerPlayer;
            else
                return null;
        }

    }
    public class Card
    {
        public enum SUITS
        {
            Hearts = 0, Diamonds, Clubs, Spades
        }
        public enum RANKS
        {
           Six = 0, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
        }

        public SUITS Suit { get; set; }
        public RANKS Rank { get; set; }
    }
    public class Player
    {
        List<Card> cards = new List<Card>();
        public int PlayerId { get; set; }

        public void AddCard(Card card) => cards.Add(card);
      
        public Card GetCard()
        {
            Random random = new Random();
            Card card = cards[random.Next(cards.Count)]; //якщо карти видавати по порядку, гра майже завжди бескінечна
            cards.Remove(card);

            Console.WriteLine($" Player{PlayerId} move: {card.Rank.ToString()} {card.Suit.ToString()}");

            return card;
         
        }

        public void TakeAllDeck(IEnumerable<Card> c)
        {
            cards.AddRange(c);
            Console.WriteLine($" Player{PlayerId} Win and take deck! Count Card = {cards.Count}");
        }

        public int GetCardCount() => cards.Count;

    }
    public class MyList<T> : List<T>
    {
        public void Shuffle()
        {
            Random rand = new Random();

            for (int i = this.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                T tmp = this[j];
                this[j] = this[i];
                this[i] = tmp;
            }
        }
    }

}
