using System;

namespace Lab1_2_FunPlacesToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] choices = new string[] { "Action", "Chilling", "Danger", "Good Food" };
            string[] options = new string[] { "stock car racing", "hiking", "skydiving", "to Taco Bell" };
            int optionChoice = 0;
            string[] travel = new string[] { "sneakers", "a sedan", "a Volkswagen bus", "an airplane" };

            Console.WriteLine("Hello user, what are you in the mood for?");
            Console.WriteLine("Here are your options:\n  1) {0}\n  2) {1}\n  3) {2}\n  4) {3}", choices[0], choices[1], choices[2], choices[3]);

            optionChoice = ChooseActivity(choices);

            Console.WriteLine("How many people are you bringing with you?");

            Console.WriteLine("If you're in the mood for {0}, then you should go {1} and travel in {2}!\nbyeeee", choices[optionChoice].ToLower(), options[optionChoice], travel[ChooseTransportation()]);

            // End of Main
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("End of Demo. Press any key to exit.");
            Console.ReadKey();
        }

        private static int ChooseActivity(string[] choices)
        {
            int myChoice = 0;
            string readLineRaw = "";
            bool illegalEntry = true;
            while (illegalEntry)
            {
                readLineRaw = Console.ReadLine();
                for (int i = 0; i < choices.Length; i++)
                {
                    if (readLineRaw.ToLower() == choices[i].ToLower() || readLineRaw == (i + 1).ToString())
                    {
                        myChoice = i;
                        illegalEntry = false;
                    }
                }
                if(illegalEntry) Console.WriteLine("Unknown selection, please try again.");
            }
            return myChoice;
        }
        private static int ChooseTransportation()
        {
            uint numFriends = 0;
            bool illegalEntry = true;
            while (illegalEntry)
            {
                try
                {
                    numFriends = uint.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    if(e.GetType().ToString() == "System.OverflowException")
                    {
                        Console.WriteLine("Invalid entry, please enter a non-negative number that's not too big.");
                    }else if(e.GetType().ToString() == "System.FormatException")
                    {
                        Console.WriteLine("Invalid entry, please use numbers");
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry, please try again.");
                    }
                    continue;
                }
                illegalEntry = false;
            }
            if (numFriends == 0) return 0;
            if (numFriends < 5) return 1;
            if (numFriends < 11) return 2;
            return 3;
        }
    }
}
