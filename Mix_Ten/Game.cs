
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mix_Ten
{
    public class Game
    {
        int chips = 1000;
        Deck deck;
        static List<Card> userHand;
        static List<Card> bothand;
        static List<Card> bot2hand;
        static List<Card> bot3hand;
        static List<Card> Joke;
        int numberplayer;
        int bet;
        int numberleavebot1;
        int numberleavebot2;
        int numberleavebot3;

        public void playagin()
        {
            while (true)
            {
                Bot1();
                showjoke();
                Bot2();
                showjoke();
                Bot3();
                showjoke();
                Player();
                HitorKeep();
                Console.WriteLine("Remaining Cards: {0}\n", deck.GetAmountOfRemainingCrads());
                if (deck.GetAmountOfRemainingCrads() <= 0)
                    break;
            }
        }
        public void showjoke()
        {
            Console.WriteLine("Joke: {0} of {1}", Joke[0].Face, Joke[0].Suit);
            Console.WriteLine("Joke : {0}", Joke[0].Value);
            int unjoke = 10 - Joke[0].Value;
            if (unjoke <= 0)
                Console.WriteLine("UnJoke : none\n");
            else
                Console.WriteLine("UnJoke : {0} \n", unjoke);
        }
        public void mainplay()
        {
            Console.Title = "♠♥♣♦ Mixten Game by UP_KIKI";

            while (chips > 0)
            {
                Console.WriteLine("--------New Game-------");
                deck = new Deck();
                deck.Shuffle();
                DealHand();
                dealbot1();
                dealbot2();
                dealbot3();
                dealplayer();
                joke();
                playagin();
            }
            Console.WriteLine("You Lost! see you next time...");
        }
        public void play()
        {
            mainplay();
           
        }

        public void playerwin()
        {
            Console.WriteLine("Player Win!!!! : {0}",bet*4);
            Console.WriteLine(" {0} {1}  {2} {3}  {4} {5}  {6} {7}  {8} {9}  {10} {11}", userHand[0].Face, userHand[0].Suit, userHand[1].Face, userHand[1].Suit, userHand[2].Face, userHand[2].Suit,
                        userHand[3].Face, userHand[3].Suit, userHand[4].Face, userHand[4].Suit, userHand[5].Face, userHand[5].Suit);
            chips = chips + (bet * 3);
            Console.WriteLine("money : {0}", chips);
            play();
        }
        public void bot1win()
        {
            Console.WriteLine("Bot1 Win!!!!");
            Console.WriteLine(" {0} {1}  {2} {3}  {4} {5}  {6} {7}  {8} {9}  {10} {11}", bothand[0].Face, bothand[0].Suit, bothand[1].Face, bothand[1].Suit, bothand[2].Face, bothand[2].Suit,
                        bothand[3].Face, bothand[3].Suit, bothand[4].Face, bothand[4].Suit, bothand[5].Face, bothand[5].Suit);
            chips = chips - bet;
            Console.WriteLine("money : {0}", chips);
           
        }
        public void bot2win()
        {
            Console.WriteLine("Bot2 Win!!!!");
            Console.WriteLine(" {0} {1}  {2} {3}  {4} {5}  {6} {7}  {8} {9}  {10} {11}", bot2hand[0].Face, bot2hand[0].Suit, bot2hand[1].Face, bot2hand[1].Suit, bot2hand[2].Face, bot2hand[2].Suit,
                        bot2hand[3].Face, bot2hand[3].Suit, bot2hand[4].Face, bot2hand[4].Suit, bot2hand[5].Face, bot2hand[5].Suit);
            chips = chips - bet;
            Console.WriteLine("money : {0}", chips);
        }
        public void bot3win()
        {
            Console.WriteLine("Bot3 Win!!!!");
            Console.WriteLine(" {0} {1}  {2} {3}  {4} {5}  {6} {7}  {8} {9}  {10} {11}", bot3hand[0].Face, bot3hand[0].Suit, bot3hand[1].Face, bot3hand[1].Suit, bot3hand[2].Face, bot3hand[2].Suit,
                        bot3hand[3].Face, bot3hand[3].Suit, bot3hand[4].Face, bot3hand[4].Suit, bot3hand[5].Face, bot3hand[5].Suit);
            chips = chips - bet;
            Console.WriteLine("money : {0}", chips);
            play();
        }
        public void DealHand()
        {
            Console.WriteLine("Remaining Cards: {0}", deck.GetAmountOfRemainingCrads());
            Console.WriteLine("Current Chips: {0}", chips);
            Console.WriteLine("How much would you like to bet? (1 - {0})", chips);
            bet = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
        }
        //**********
        //Joke 
       
        public void joke()
        {
            Joke = new List<Card>();
            Joke.Add(deck.DrawACard());
            Console.WriteLine("Joke: {0} of {1}", Joke[0].Face, Joke[0].Suit);
            Console.WriteLine("Joke : {0}", Joke[0].Value);
            int unjoke = 10 - Joke[0].Value;
            if (unjoke <= 0)
                Console.WriteLine("UnJoke : none\n");
            else
                Console.WriteLine("UnJoke : {0} \n", unjoke);
        }
        

        public void dealbot1()
        {
            bothand = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                bothand.Add(deck.DrawACard());
            }
        }

        int limitbot1 = 5;
        public void Bot1()
        {            
            Console.WriteLine("[ Bot1 ] : Hidden");
            for (int i = 4; i < limitbot1 + 1; i++)
            {
                bothand.Add(deck.DrawACard());
            }
            bothand[5] = bothand[limitbot1];
           /*
            Console.WriteLine("{0} {1} ", bothand[5].Face, bothand[5].Suit);
            Console.WriteLine(limitbot1);
          */
            limitbot1 = limitbot1 + 1;
            /*
            int x = 1;
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Card {0}: {1} of {2}", x, bothand[i].Face, bothand[i].Suit);
                x++;
            }    */       
            int toal = 0;
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    if (bothand[i].Value + bothand[j].Value == 10)
                    {
                        toal = toal + 1;
                       // Console.WriteLine("{0}  {1}", i, j);
                    }
                    for (int z = 10; z < 14; z++)
                    {
                        if (bothand[i].Value == z && bothand[j].Value == z)
                        {
                          //  Console.WriteLine(" test {0}",z);
                            toal = toal + 1;
                        }
                    }
                }
            }
            for (int i = 0; i < 6; i++)
            {
                if (bothand[i].Value == 5 && bothand[i].Value == 5)
                    toal = toal - 1;
            }
            for (int z = 10; z < 14; z++)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (bothand[i].Value == z && bothand[i].Value == z)
                        toal = toal - 1;
                }
            }
            int joke = 0;
            for (int w = 0; w < 6; w++)
            {
                if ((Joke[0].Value == bothand[w].Value))
                {
                    joke = joke + 1;
                    toal = toal + 1;
                }
            }
            if (joke >= 3)
            {
                bot1win();
                play();
            }
            int newnumber = 5;// สำคัญๆ //////////////
            Random dd = new Random();
            int r = dd.Next(newnumber);          
            Console.WriteLine("Dou :{0}", toal);
            if (toal >= 8)
            {
                bot1win();
                play();
            }
            Console.WriteLine("leave Card : {0} {1}\n", bothand[r].Face, bothand[r].Suit);
            numberleavebot1 = r;
            bothand[numberleavebot1] = bothand[newnumber];/////
            newnumber++;
        }
        // bot1
        //
        public void dealbot2()
        {
            bot2hand = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                bot2hand.Add(deck.DrawACard());
            }
        }
        int limitbot2 = 5;
        public void Bot2()
        {           
            
            Console.WriteLine("[ Bot2 ] : Hidden");           
            for (int i = 4; i < limitbot2 + 1; i++)
            {
                bot2hand.Add(deck.DrawACard());               
            }
            bot2hand[5] = bot2hand[limitbot2];
            /*
            Console.WriteLine("{0} {1} ", bot2hand[5].Face, bot2hand[5].Suit);
            Console.WriteLine(limitbot2);
            */
            limitbot2 = limitbot2 + 1;
            /*
            int x = 1;
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Card {0}: {1} of {2}", x, bot2hand[i].Face, bot2hand[i].Suit);
                x++;
            }*/
            int toal = 0;
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    if (bot2hand[i].Value + bot2hand[j].Value == 10)
                    {
                       // Console.WriteLine("5");
                        toal = toal + 1;
                    }
                    for (int z = 10; z < 14; z++)
                    {
                        if (bot2hand[i].Value == z && bot2hand[j].Value == z)
                        {
                           // Console.WriteLine(z);
                            toal = toal + 1;
                        }
                    }                   
                }
            }
            for (int i = 0; i < 6; i++)
            {
                if (bot2hand[i].Value == 5 && bot2hand[i].Value == 5)
                    toal = toal - 1;
            }
            for (int z = 10; z < 14; z++)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (bot2hand[i].Value == z && bot2hand[i].Value == z)
                        toal = toal - 1;
                }
            }
            int joke = 0;
            for (int w = 0; w < 6; w++)
            {
                if ((Joke[0].Value == bot2hand[w].Value))
                {
                    joke = joke + 1;
                    toal = toal + 1;
                }
            }
            if (joke >= 3)
            {
                bot2win();
                play();
            }
            Console.WriteLine("Dou :{0}", toal);
            if (toal >= 8)
            {
                bot2win();
                play();
            }
            Random dd = new Random();
            int newnumber = 5;// สำคัญๆ //////////////            
            int r = dd.Next(newnumber);
            Console.WriteLine("leave Card : {0} {1}\n", bot2hand[r].Face, bot2hand[r].Suit);
            numberleavebot2 = r;
            bot2hand[numberleavebot2] = bot2hand[newnumber];/////
            newnumber++;
        }

        public void dealbot3()
        {
            bot3hand = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                bot3hand.Add(deck.DrawACard());
            }
        }
        //
        int limitbot3 = 5;
        public void Bot3()
        {            
            Console.WriteLine("[ Bot3 ] : Hidden");
            for (int i = 4; i < limitbot3 + 1; i++)
            {
                bot3hand.Add(deck.DrawACard());
            }
            bot3hand[5] = bot3hand[limitbot3];
            /*
            Console.WriteLine("{0} {1} ", bot3hand[5].Face, bot3hand[5].Suit);
            Console.WriteLine(limitbot3);
            */
            limitbot3 = limitbot3 + 1;         
            /*
            int x = 1;
            for (int i = 0; i < 6; i++)
            {

                Console.WriteLine("Card {0}: {1} of {2}", x, bot3hand[i].Face, bot3hand[i].Suit);
                x++;
            }
           */
            int toal = 0;
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    if (bot3hand[i].Value + bot3hand[j].Value == 10)
                    {
                        //Console.WriteLine("5");
                        toal = toal + 1;
                    }
                    for (int z = 10; z < 14; z++)
                    {
                        if (bot3hand[i].Value == z && bot3hand[j].Value == z)
                        {
                           // Console.WriteLine(z);
                            toal = toal + 1;
                        }
                    }
                }
            }
            for (int i = 0; i < 6; i++)
            {
                if (bot3hand[i].Value == 5 && bot3hand[i].Value == 5)
                    toal = toal - 1;
            }

            for (int z = 10; z < 14; z++)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (bot3hand[i].Value == z && bot3hand[i].Value == z)
                        toal = toal - 1;
                }
            }

            int joke = 0;
            for (int w = 0; w < 6; w++)
            {
                if ((Joke[0].Value == bot3hand[w].Value))
                {
                    joke = joke + 1;
                    toal = toal + 1;

                }
            }
            if (joke >= 3)
            {
                bot3win();
            }
            Console.WriteLine("Dou :{0}", toal);
            if (toal>=8)
            {
                bot3win();
            }          
            Random dd = new Random();
            int newnumber = 5;// สำคัญๆ //////////////
            int r = dd.Next(newnumber);          
            bot3hand[numberleavebot3] = bot3hand[newnumber];/////
            Console.WriteLine("leave Card : {0} {1}\n", bot3hand[r].Face, bot3hand[r].Suit);
            numberleavebot3 = r;
            newnumber++;
        }
        //
        public void dealplayer()
        {
            userHand = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                userHand.Add(deck.DrawACard());
            }
        }

        public void checkplayer(int n,string s)
        {
            int toal = 0;
            int joke = 0;
            for (int w = 0; w <= n; w++)
            {
                if ((Joke[0].Value == userHand[w].Value))
                {
                    joke = joke + 1;
                    toal = toal + 1;
                }
            }
            if (joke >= 3)
            {
                playerwin();
            }
            if(s=="p")
            {
                for (int i = 0; i <= n; i++)
                {
                    for (int j = 0; j <= n; j++)
                    {
                        if (userHand[i].Value + userHand[j].Value == 10)
                        {
                            // Console.WriteLine("5");
                            toal = toal + 1;
                        }
                        for (int z = 10; z < 14; z++)
                        {
                            if (userHand[i].Value == z && userHand[j].Value == z)
                            {
                                //Console.WriteLine(z);
                                toal = toal + 1;
                            }
                        }
                    }
                }
                for (int i = 0; i <= n; i++)
                {
                    if (userHand[i].Value == 5 && userHand[i].Value == 5)
                        toal = toal - 1;
                }
                for (int z = 10; z < 14; z++)
                {
                    for (int i = 0; i <= n; i++)
                    {
                        if (userHand[i].Value == z && userHand[i].Value == z)
                            toal = toal - 1;
                    }
                }
                if (toal >= 6)
                {
                    playerwin();
                }
                Console.WriteLine("Dou :{0}", toal);
            }
            if (s == "b")
            {
                for (int i = 0; i <= n; i++)
                {
                    for (int j = 0; j <= n; j++)
                    {
                        if (userHand[i].Value + userHand[j].Value == 10)
                        {
                            // Console.WriteLine("5");
                            toal = toal + 1;
                        }
                        for (int z = 10; z < 14; z++)
                        {
                            if (userHand[i].Value == z && userHand[j].Value == z)
                            {
                                //Console.WriteLine(z);
                                toal = toal + 1;
                            }
                        }
                    }
                }
                for (int i = 0; i <= n; i++)
                {
                    if (userHand[i].Value == 5 && userHand[i].Value == 5)
                        toal = toal - 1;
                }
                for (int z = 10; z < 14; z++)
                {
                    for (int i = 0; i <= n; i++)
                    {
                        if (userHand[i].Value == z && userHand[i].Value == z)
                            toal = toal - 1;
                    }
                }
                for (int i = 0; i <= n; i++)
                {                   
                        if (userHand[i].Value + bot3hand[numberleavebot3].Value == 10)
                        {
                            // Console.WriteLine("5");
                            toal = toal + 1;
                        }
                        for (int z = 10; z < 14; z++)
                        {
                            if (userHand[i].Value == z && bot3hand[numberleavebot3].Value == z)
                            {
                                //Console.WriteLine(z);
                                toal = toal + 1;
                            }
                        }                    
                }
                
                if (toal >= 6)
                {
                    playerwin();
                }
                Console.WriteLine("Dou :{0}", toal);
            }
            
        }
        public void Player()
        {          
            //
            Console.WriteLine("[Player]");
            //***//
         
            int n = 1;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Card {0}: {1} of {2}",n, userHand[i].Face, userHand[i].Suit);
                n++;
            }
            Console.WriteLine(" {0} {1} {2} {3} {4} ", userHand[0].Value, userHand[1].Value, userHand[2].Value, userHand[3].Value, userHand[4].Value);
           
        }
        int limitplayer = 5;
        public void HitorKeep()
        {
            Console.WriteLine("Addcard or Keepcard :[h|k] ");
            ConsoleKeyInfo userOption = Console.ReadKey(true);
            while (userOption.Key != ConsoleKey.H && userOption.Key != ConsoleKey.K)
            {
                Console.WriteLine("illegal key. Please choose a valid option: [k:Keep||h:Hit]");
                userOption = Console.ReadKey(true);
            }
            Console.WriteLine();
            switch (userOption.Key)
            {
                case ConsoleKey.H:
                    // กด Hit 
                    for (int i = 4; i < limitplayer + 1; i++)
                    {
                        userHand.Add(deck.DrawACard());//จั่วไพ่เพิ่ม
                    }
                    userHand[5] = userHand[limitplayer];
                    Console.WriteLine("{0} {1} ", userHand[5].Face, userHand[5].Suit);
                    Console.WriteLine(limitplayer);
                    limitplayer = limitplayer + 1;
                   
                    int n = 1;
                    for (int i = 0; i < 6; i++)
                    {                                               
                        Console.WriteLine("Card {0}: {1} of {2}",n, userHand[i].Face, userHand[i].Suit);
                        n++;
                    }
                    int newnumber = 5 ;
                    //userHand[numberplayer] = userHand[numberplayer];
                    checkplayer(5,"p");
                    Console.WriteLine("[Are You leave Card]");
                    Console.WriteLine(" 0: {0} {1} 1: {2} {3} 2: {4} {5} 3: {6} {7} 4: {8} {9} 5: {10} {11}", userHand[0].Face, userHand[0].Suit, userHand[1].Face, userHand[1].Suit, userHand[2].Face, userHand[2].Suit,
                        userHand[3].Face, userHand[3].Suit, userHand[4].Face, userHand[4].Suit, userHand[newnumber].Face, userHand[newnumber].Suit);
                    Console.Write("Input : ");
                    int gg = Convert.ToInt32(Console.ReadLine());                   
                    for (int i = 0; i < 6; i++)
                    {
                        if (gg == i)
                        {
                            numberplayer = i;
                            Console.WriteLine("leave Card : {0} {1}\n", userHand[numberplayer].Face, userHand[numberplayer].Suit);
                            userHand[numberplayer] = userHand[newnumber];
                        }
                    }
                    newnumber++;
                    break;
                //***
                case ConsoleKey.K:
                    int x = 1;
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("Card {0}: {1} of {2}", x, userHand[i].Face, userHand[i].Suit);
                        x++;
                    }
                    Console.WriteLine("Card 6: {0} of {1}", bot3hand[numberleavebot3].Face, bot3hand[numberleavebot3].Suit);

                   // userHand[5] = bot3hand[numberleavebot3];
                    checkplayer(4,"b");
                    //int newnumber2 = 6;
                    Console.WriteLine("[Are You leave Card]");
                    Console.WriteLine(" 0: {0} {1} 1: {2} {3} 2: {4} {5} 3: {6} {7} 4: {8} {9} 5: {10} {11}", userHand[0].Face, userHand[0].Suit, userHand[1].Face, userHand[1].Suit, userHand[2].Face, userHand[2].Suit,
                        userHand[3].Face, userHand[3].Suit, userHand[4].Face, userHand[4].Suit,bot3hand[numberleavebot3].Face,bot3hand[numberleavebot3].Suit);
                    Console.Write("Input : ");
                    int xx = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < 6; i++)
                    {
                        if (xx == i && xx != 5)
                        {
                            numberplayer = i;
                            Console.WriteLine("leave Card : {0} {1}\n", userHand[numberplayer].Face, userHand[numberplayer].Suit);
                            userHand[numberplayer] = bot3hand[numberleavebot3];
                        }
                        if (xx == 5)
                        {
                            //numberplayer = numberleavebot3;
                            Console.WriteLine("leave Card : {0} {1}\n", bot3hand[numberleavebot3].Face, bot3hand[numberleavebot3].Suit);
                            // bot3hand[numberplayer] = bot3hand[numberleavebot3];
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
          //  Console.WriteLine(" test: {0} ", numberplayer);
           // Console.ReadLine();
        }
    }
}


