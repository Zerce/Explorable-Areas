/*
 * Kennedy Liggins
 * Rigoberto Cervantes
 * Emanuel Jaramillo
 * Chris Avelar
 * 10/25/2020
 * Introduction to Programming FA20
 * Aided by http://programmingisfun.com/learn/c-sharp-adventure-game/c_sharp_11_instances_lists/
 * Art from asciiart.eu/weapons/swords
 */

using System;
using System.Collections.Generic;

namespace ExplorableAreasGroupProject
{
    public class World
    {
        public string ChoiceA = "a";
        public string ChoiceB = "b";
        public string ChoiceC = "c";
        public string ChoiceD = "d";

        public string CurrentLocation;

        public World()
        {
            List<string> Locations = new List<string>();

            Locations.Add("Town");
            Locations.Add("Forest");
            Locations.Add("Arctic");
            Locations.Add("Desert");

            List<string> TownInventory = new List<string>();
            TownInventory.Add("Citrine Key");
            TownInventory.Add("Gold");

            List<string> ForestInventory = new List<string>();
            ForestInventory.Add("Jade Key");
            ForestInventory.Add("Coat");

            List<string> ArcticInventory = new List<string>();
            ArcticInventory.Add("Sapphire Key");
            ArcticInventory.Add("Water");

            List<string> DesertInventory = new List<string>();
            DesertInventory.Add("Ruby Key");
            DesertInventory.Add("Necklace");

            List<string> Descriptions = new List<string>();
            Descriptions.Add("Citrine Key: One of the four keys needed to save the land.");
            Descriptions.Add("Jade Key: One of the four keys needed to save the land.");
            Descriptions.Add("Sapphire Key: One of the four keys needed to save the land.");
            Descriptions.Add("Ruby Key: One of the four keys needed to save the land.");
            Descriptions.Add("A bag of gold.");
            Descriptions.Add("A warm, blue, winter coat.");
            Descriptions.Add("Melted snow in a cup.");
            Descriptions.Add("A shiny necklace with some sand still on it.");

            List<string> PlayerInventory = new List<string>();

            List<string> InventoryDescriptions = new List<string>();

            Start();

            void Start()
            {
                Console.Write(@"
 .______________________________________________________| _._._._._._._._._._.
 \_____________________________________________________ |_#_#_#_#_#_#_#_#_#_|
                                                        |");
                Console.WriteLine("\nWelcome adventurer! You must save the land by finding four keys. Are you up to the challenge?\na) Yes\tb) No");
                Console.WriteLine("     ");
                string Choice = Console.ReadLine();
                if (Choice.ToLower() == ChoiceA)
                {
                    Console.WriteLine("Great! Enter the letter of a choice when prompted. Good Luck!");
                    GetLocation();
                }
                else if (Choice.ToLower() == ChoiceB)
                {
                    Console.WriteLine("See you soon, adventurer! Press ENTER to exit");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("That was not one of the given options, please press ENTER to try again.");
                    Console.ReadKey();
                    Start();
                }
            }

            void GetLocation()
            {
                Console.Title = "The Four Keys";

                Console.Clear();
                Console.WriteLine("You are in the middle of the land. There is a town to your right, a forest to your left, a desert in front of you, and an arctic behind you. You need water to enter the desert, and a coat to enter the arctic. Where will you go?\na) Town\t\tb) Forest\tc) Arctic\td) Desert");
                Console.WriteLine("     ");
                string Choice = Console.ReadLine();
                if (Choice.ToLower() == ChoiceA)
                {
                    Town();
                }
                else if (Choice.ToLower() == ChoiceB)
                {
                    Forest();
                }
                else if (Choice.ToLower() == ChoiceC && PlayerInventory.Contains("Coat"))
                {
                    Arctic();
                }
                else if (Choice.ToLower() == ChoiceD && PlayerInventory.Contains("Water"))
                {
                    Desert();
                }
                else
                {
                    Console.WriteLine("That was not one of the given options or you do not have a needed item, please press ENTER to try again.");
                    Console.ReadKey();
                    GetLocation();
                }
            }

            void Town()
            {
                Console.Title = "The Town";
                CurrentLocation = "Town";

                Console.Clear();
                Console.WriteLine("You have arrived at the town. Would you like to look around, talk to people, go back, or check your inventory?\na) Look Around\t\tb) Talk to People\tc) Go Back\td) Check Inventory");
                Console.WriteLine("     ");
                string Choice = Console.ReadLine();
                if (Choice.ToLower() == ChoiceA && TownInventory.Contains("Citrine Key"))
                {
                    FindKey();
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    Town();
                }
                else if (Choice.ToLower() == ChoiceA && PlayerInventory.Contains("Citrine Key"))
                {
                    Console.WriteLine("There is nothing to find here. Press ENTER to continue.");
                    Console.ReadKey();
                    Town();
                }
                else if (Choice.ToLower() == ChoiceB && TownInventory.Contains("Gold"))
                {
                    Console.WriteLine("You meet a very rich man named John. He gives you some of his extra gold.");
                    TownInventory.Remove("Gold");
                    PlayerInventory.Add("Gold");
                    Descriptions.Remove("Gold: A bag of gold.");
                    InventoryDescriptions.Add("Gold: A bag of gold.");
                    Console.ReadKey();
                    Town();
                }
                else if (Choice.ToLower() == ChoiceB && PlayerInventory.Contains("Gold"))
                {
                    Console.WriteLine("There is no one to talk to here. Press ENTER to continue.");
                    Console.ReadKey();
                    Town();
                }
                else if (Choice.ToLower() == ChoiceC)
                {
                    GetLocation();
                }
                else if (Choice.ToLower() == ChoiceD)
                {
                    DisplayInventory();
                    Town();
                }
                else
                {
                    Console.WriteLine("That was not one of the given options, please press ENTER to try again.");
                    Console.ReadKey();
                    Town();
                }
            }

            void Forest()
            {
                Console.Title = "The Forest";
                CurrentLocation = "Forest";

                Console.Clear();
                Console.WriteLine("You have arrived at the forest. Would you like to look around, talk to people, go back, or check your inventory?\na) Look Around\t\tb) Talk to People\tc) Go Back\td) Check Inventory");
                Console.WriteLine("     ");
                string Choice = Console.ReadLine();
                if (Choice.ToLower() == ChoiceA && ForestInventory.Contains("Jade Key"))
                {
                    FindKey();
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    Forest();
                }
                else if (Choice.ToLower() == ChoiceA && PlayerInventory.Contains("Jade Key"))
                {
                    Console.WriteLine("There is nothing to find here. Press ENTER to continue.");
                    Console.ReadKey();
                    Forest();
                }
                else if (Choice.ToLower() == ChoiceB && ForestInventory.Contains("Coat"))
                {
                    Console.WriteLine("You meet a nice woman named Anna. She is selling coats for gold. Would you like to buy one?\na) Yes\tb) No");
                    Console.WriteLine("     ");
                    string SecondChoice = Console.ReadLine();
                    if (SecondChoice.ToLower() == ChoiceA && PlayerInventory.Contains("Gold"))
                    {
                        Console.WriteLine("Anna gives you a warm coat.");
                        PlayerInventory.Remove("Gold");
                        ForestInventory.Remove("Coat");
                        PlayerInventory.Add("Coat");
                        InventoryDescriptions.Remove("Gold: A bag of gold.");
                        Descriptions.Remove("Coat: A warm, blue, winter coat.");
                        InventoryDescriptions.Add("Coat: A warm, blue, winter coat.");
                        Console.ReadKey();
                        Forest();
                    }
                    else if (SecondChoice.ToLower() == ChoiceA && TownInventory.Contains("Gold"))
                    {
                        Console.WriteLine("You do not have gold to give her. Press ENTER to continue.");
                        Console.ReadKey();
                        Forest();
                    }
                    else if (SecondChoice.ToLower() == ChoiceB)
                    {
                        Console.WriteLine("Press ENTER to continue.");
                        Console.ReadKey();
                        Forest();
                    }
                    else
                    {
                        Console.WriteLine("That was not one of the given options, please press ENTER to try again.");
                        Console.ReadKey();
                        Forest();
                    }
                }
                else if (Choice.ToLower() == ChoiceB && PlayerInventory.Contains("Coat"))
                {
                    Console.WriteLine("There is no one to talk to here. Press ENTER to continue.");
                    Console.ReadKey();
                    Forest();
                }
                else if (Choice.ToLower() == ChoiceC)
                {
                    GetLocation();
                }
                else if (Choice.ToLower() == ChoiceD)
                {
                    DisplayInventory();
                    Forest();
                }
                else
                {
                    Console.WriteLine("That was not one of the given options, please press ENTER to try again.");
                    Console.ReadKey();
                    Forest();
                }
            }

            void Arctic()
            {

                Console.Title = "The Arctic";
                CurrentLocation = "Arctic";

                Console.Clear();
                Console.WriteLine("You have arrived at the arctic. Would you like to look around, talk to people, go back, or check your inventory?\na) Look Around\t\tb) Talk to People\tc) Go Back\td) Check Inventory");
                Console.WriteLine("     ");
                string Choice = Console.ReadLine();
                if (Choice.ToLower() == ChoiceA && ArcticInventory.Contains("Water"))
                {
                    Console.WriteLine("There is a lot of snow here. You take some, but it melts into water in your cup. You got some water");
                    ArcticInventory.Remove("Water");
                    PlayerInventory.Add("Water");
                    Descriptions.Remove("Water: Melted snow in a cup.");
                    InventoryDescriptions.Add("Water: Melted snow in a cup.");
                    Console.ReadKey();
                    Arctic();
                }
                else if (Choice.ToLower() == ChoiceA && PlayerInventory.Contains("Water"))
                {
                    Console.WriteLine("There is nothing to find here. Press ENTER to continue.");
                    Console.ReadKey();
                    Arctic();
                }
                else if (Choice.ToLower() == ChoiceB && ArcticInventory.Contains("Sapphire Key"))
                {
                    Console.WriteLine("You meet a small girl nemed Belle. She has been playing with the Sapphire Key as a toy. She agrees to give it to you, as long as you share.");
                    Console.ReadKey();
                    FindKey();
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    Arctic();
                }
                else if (Choice.ToLower() == ChoiceB && PlayerInventory.Contains("Sapphire Key"))
                {
                    Console.WriteLine("There is no one to talk to here. Press ENTER to continue.");
                    Console.ReadKey();
                    Arctic();
                }
                else if (Choice.ToLower() == ChoiceC)
                {
                    GetLocation();
                }
                else if (Choice.ToLower() == ChoiceD)
                {
                    DisplayInventory();
                    Arctic();
                }
                else
                {
                    Console.WriteLine("That was not one of the given options, please press ENTER to try again.");
                    Console.ReadKey();
                    Arctic();
                }
            }

            void Desert()
            {
                Console.Title = "The Desert";
                CurrentLocation = "Desert";

                Console.Clear();
                Console.WriteLine("You have arrived at the desert. Would you like to look around, talk to people, go back, or check your inventory?\na) Look Around\t\tb) Talk to People\tc) Go Back\td) Check Inventory");
                Console.WriteLine("     ");
                string Choice = Console.ReadLine();
                if (Choice.ToLower() == ChoiceA && DesertInventory.Contains("Necklace"))
                {
                    Console.WriteLine("You find a shiny, silver necklace in the sand. You don't want it to get buried or lost, so you pick it up. You got a necklace.");
                    DesertInventory.Remove("Necklace");
                    PlayerInventory.Add("Necklace");
                    Descriptions.Remove("Necklace: A shiny necklace with some sand still on it.");
                    InventoryDescriptions.Add("Necklace: A shiny necklace with some sand still on it.");
                    Console.ReadKey();
                    Desert();
                }
                else if (Choice.ToLower() == ChoiceA && PlayerInventory.Contains("Necklace"))
                {
                    Console.WriteLine("There is nothing to find here. Press ENTER to continue.");
                    Console.ReadKey();
                    Desert();
                }
                else if (Choice.ToLower() == ChoiceB && DesertInventory.Contains("Ruby Key"))
                {
                    Console.WriteLine("You meet a sad woman named May. She says she lost her necklace. She says she will give you the Ruby Key if you find it. Can you give her her necklace?\na) Yes\tb) No");
                    Console.WriteLine("     ");
                    string SecondChoice = Console.ReadLine();
                    if (SecondChoice.ToLower() == ChoiceA && PlayerInventory.Contains("Necklace"))
                    {
                        Console.WriteLine("May is so happy. She gives you the Ruby Key.");
                        PlayerInventory.Remove("Necklace");
                        InventoryDescriptions.Remove("Necklace: A shiny necklace with some sand still on it.");
                        Console.ReadKey();
                        Console.WriteLine("Press ENTER to continue.");
                        Console.ReadKey();
                        FindKey();
                    }
                    else if (SecondChoice.ToLower() == ChoiceA && TownInventory.Contains("Necklace"))
                    {
                        Console.WriteLine("You do not have a necklace to give her. Press ENTER to continue.");
                        Console.ReadKey();
                        Desert();
                    }
                    else if (SecondChoice.ToLower() == ChoiceB)
                    {
                        Console.WriteLine("Press ENTER to continue.");
                        Console.ReadKey();
                        Desert();
                    }
                    else
                    {
                        Console.WriteLine("That was not one of the given options, please press ENTER to try again.");
                        Console.ReadKey();
                        Desert();
                    }
                }
                else if (Choice.ToLower() == ChoiceB && PlayerInventory.Contains("Ruby Key"))
                {
                    Console.WriteLine("There is no one to talk to here. Press ENTER to continue.");
                    Console.ReadKey();
                    Desert();
                }
                else if (Choice.ToLower() == ChoiceC)
                {
                    GetLocation();
                }
                else if (Choice.ToLower() == ChoiceD)
                {
                    DisplayInventory();
                    Desert();
                }
                else
                {
                    Console.WriteLine("That was not one of the given options, please press ENTER to try again.");
                    Console.ReadKey();
                    Desert();
                }
            }

            void FindKey()
            {
                if (CurrentLocation == "Town")
                {
                    Console.Clear();
                    TownInventory.Remove("Citrine Key");
                    PlayerInventory.Add("Citrine Key");
                    Descriptions.Remove("Citrine Key: One of the four keys needed to save the land.");
                    InventoryDescriptions.Add("Citrine Key: One of the four keys needed to save the land.");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("CONGRATULATIONS, You found the Citrine Key! ");
                    Console.ReadKey();
                    Console.ResetColor();
                }
                else if (CurrentLocation == "Forest")
                {
                    Console.Clear();
                    ForestInventory.Remove("Jade Key");
                    PlayerInventory.Add("Jade Key");
                    Descriptions.Remove("Jade Key: One of the four keys needed to save the land.");
                    InventoryDescriptions.Add("Jade Key: One of the four keys needed to save the land.");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("CONGRATULATIONS, You found the Jade Key! ");
                    Console.ReadKey();
                    Console.ResetColor();
                }
                else if (CurrentLocation == "Arctic")
                {
                    Console.Clear();
                    ArcticInventory.Remove("Sapphire Key");
                    PlayerInventory.Add("Sapphire Key");
                    Descriptions.Remove("Sapphire Key: One of the four keys needed to save the land.");
                    InventoryDescriptions.Add("Sapphire Key: One of the four keys needed to save the land.");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("CONGRATULATIONS, You found the Sapphire Key! ");
                    Console.ReadKey();
                    Console.ResetColor();
                }
                else if (CurrentLocation == "Desert")
                {
                    Console.Clear();
                    DesertInventory.Remove("Ruby Key");
                    PlayerInventory.Add("Ruby Key");
                    Descriptions.Remove("Ruby Key: One of the four keys needed to save the land.");
                    InventoryDescriptions.Add("Ruby Key: One of the four keys needed to save the land.");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("CONGRATULATIONS, You found the Ruby Key! ");
                    Console.ReadKey();
                    Console.ResetColor();
                }

            }

            void EndGame()
            {
                Console.Clear();
                Console.WriteLine("CONGRATULATIONS! You have found all four keys and saved the land!");
                Console.WriteLine("     ");
                Console.WriteLine("Thank you for playing adventurer. Press ENTER to exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            if (PlayerInventory.Contains("Citrine Key") && PlayerInventory.Contains("Jade Key") && PlayerInventory.Contains("Sapphire Key") && PlayerInventory.Contains("Ruby Key"))
            {
                EndGame();
            }

            void DisplayInventory()
            {
                if (PlayerInventory.Count > 0)
                {
                    foreach (string description in InventoryDescriptions)
                    {
                        Console.WriteLine("     ");
                        Console.WriteLine(description);
                    }
                }
                else
                {
                    Console.WriteLine("You do not have any items.");
                }
                Console.ReadKey();
            }
        }
    }
}
