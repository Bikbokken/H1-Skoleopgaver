public class Program
{

    public enum Types
    {
        Clubs,
        Hearts,
        Spades,
        Diamonds
    }

    public enum Participant
    {
        Player,
        Computer,
    }

    public enum Status
    {
        Blackjack,
        Bust,
        OK,
    }

    public class GameController
    {
        private List<Card> _cards = new List<Card>();
        private List<Card> _playerCards = new List<Card>();
        private List<Card> _computerCards = new List<Card>();

        public List<Card> Cards { get { return _cards; } }
        public List<Card> PlayerCards { get { return _playerCards; } }
        public List<Card> ComputerCards { get { return _computerCards; } }

        public void GenerateCards()
        {
            for (int i = 1; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    byte value;
                    value = i > 10 ? (byte)10 : (byte)i;
                    _cards.Add(new Card((byte)i, value, (Types)j));
                }
            }
            ShuffleCards();
        }

        private void ShuffleCards()
        {
            Random random = new Random();
            _cards = _cards.OrderBy(x => random.Next()).ToList();
        }

        public byte GiveCard(Participant participant)
        {
            Card card = _cards.First();
            if (participant == Participant.Player)
            {
                _playerCards.Add(card);
            } else if (participant == Participant.Computer)
            {
                _computerCards.Add(card); 
            } else {
                throw new Exception("Error not found");
            }
            _cards.RemoveAt(0);
            return card.Value;
        }

        public Status CheckCards(List<Card> cards)
        {
            byte value = ValueOfCards(cards);
            if(value == 21)
            {
                return Status.Blackjack;
            }
            if(value > 21)
            {
                return Status.Bust;
            }
            return Status.OK;
        }

        public byte ValueOfCards(List<Card> cards)
        {
            byte value = 0;
            cards.ForEach(x => value += x.Value);
            return value;
        }


    }

    public struct Card
    {
        private byte _number;
        private byte _value;
        private Types _type;

        public byte Number { get { return _number; } }
        public byte Value { get { return _value; } }
        public string Type { get { return nameof(_type); } }


        public Card(byte number, byte value, Types type)
        {
            _number = number;
            _value = value;
            _type = type;
        }
        public override string ToString()
        {
            return "NUMBER : " + _number + "  VALUE: " + _value + " TYPE: " + _type;

        }
    }

    static void Main(string[] args)
    {
        GameController gameController = new GameController();
        gameController.GenerateCards();

        gameController.GiveCard(Participant.Player);
        gameController.GiveCard(Participant.Player);
        gameController.GiveCard(Participant.Computer);
        gameController.GiveCard(Participant.Computer);

        Participant turn = Participant.Player;
        bool isGameAlive = true;
        while (isGameAlive)
        {
            Console.WriteLine("Velkommen til blackjack!");
            while(turn == Participant.Player && isGameAlive)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Du har følgende kort: ");
                PrintCards(gameController.PlayerCards, false);
                Console.WriteLine();
                Console.WriteLine("Computeren har følgende kort:");
                PrintCards(gameController.ComputerCards, true);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Tryk på H: For at holde - Tryk på T: For at tage et til kort");
                Console.WriteLine();

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.T:
                        byte cardValue = gameController.GiveCard(Participant.Player);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Du trak en " + cardValue);
                        Console.WriteLine();
                        switch(gameController.CheckCards(gameController.PlayerCards))
                        {
                            case Status.Blackjack:
                                Console.WriteLine("Du har fået blackjack!");
                                break;
                            case Status.Bust:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Du er bust! Computeren vinder!");
                                isGameAlive = false;
                                break;
                        }
                        break;
                    case ConsoleKey.H:
                        turn = Participant.Computer;
                        break;
                }
            }
            while(turn == Participant.Computer && isGameAlive)
            {
                Console.WriteLine("Computerens kort er:");
                PrintCards(gameController.ComputerCards, false);
                Console.WriteLine();
                Task.Delay(1000).Wait();
                byte valueOfComputer = gameController.ValueOfCards(gameController.ComputerCards);
                if (valueOfComputer > 16) //Basic blackjack, if the computer hits 16 or over, the computer cannot draw any more cards
                {
                    switch(gameController.CheckCards(gameController.ComputerCards))
                    {
                        case Status.Blackjack:
                            if(gameController.CheckCards(gameController.PlayerCards) == Status.Blackjack)
                            {
                                Console.WriteLine("I har begge vundet!");
                                isGameAlive=false;
                            }
                            break;
                        case Status.Bust:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Du har vundet!");
                            isGameAlive = false;
                            break;
                        case Status.OK:
                            if (valueOfComputer > gameController.ValueOfCards(gameController.PlayerCards))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Computeren vandt!");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Du vandt!");
                            }
                            isGameAlive = false;

                            break;
                    }
                   
                } else
                {
                    gameController.GiveCard(Participant.Computer);
                }
            }
        }
    }

    static void PrintCards(List<Card> cards, bool hideLast)
    {
        foreach(Card card in cards)
        {
            if(hideLast)
            {
                if (cards.IndexOf(card) == cards.Count - 1)
                {
                    Console.Write("X" + "  ");
                }
                else
                {
                    Console.Write(card.Value + "  ");
                }
            } else
            {
                Console.Write(card.Value + "  ");
            }
        }
    }
}