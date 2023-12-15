using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var harryPotter = new HarryPotterCharacter
        {
            Name = "Harry Potter",
            House = "Gryffindor",
            Inventory = new List<string> { "Wand" }

        };

        var hermioneGranger = new HarryPotterCharacter
        {
            Name = "Hermione Granger",
            House = "Gryffindor",
            Inventory = new List<string> { "Book" }
        };

        var ronWeasley = new HarryPotterCharacter
        {
           Name = "Ron Weasley",
           House = "Gryffindor",
           Inventory = new List<string> { "Broom" }
        };

        bool playAgain = true;

        while (playAgain)
        {
            Console.WriteLine("Choose character:");
            Console.WriteLine("1. Harry Potter");
            Console.WriteLine("2. Hermione Granger");
            Console.WriteLine("3. Ron Weasley");

            int characterChoice = Convert.ToInt32(Console.ReadLine());

            HarryPotterCharacter selectedCharacter;

            switch (characterChoice)
            {
                case 1:
                    selectedCharacter = harryPotter;
                    break;
                case 2:
                    selectedCharacter = hermioneGranger;
                    break;
                case 3:
                    selectedCharacter = ronWeasley;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Harry Potter.");
                    selectedCharacter = harryPotter;
                    break;
            }

            selectedCharacter.PrintIntroduction();

            var magicShop = new MagicShop();

            selectedCharacter.VisitMagicShop(magicShop);

            selectedCharacter.CastSpell();

            Console.WriteLine("Do you want to play again? Yes or no");
            string playAgainChoice = Console.ReadLine().ToLower();

            playAgain = (playAgainChoice == "yes");
        }
    }
}

class HarryPotterCharacter
{
    public string Name { get; set; }
    public string House { get; set; }
    public List<string> Inventory { get; set;}

    public void PrintIntroduction()
    {
        Console.WriteLine($"Hello, I'm {Name} from the house {House}.");
        Console.WriteLine($"I have the following items with me: {string.Join(", ", Inventory)}");
    }

    public void VisitMagicShop(MagicShop shop)
    {
        Console.WriteLine("Welcome to the MagicShop!");
        Console.WriteLine("Do you want to buy an animal or a new wand? (1. Animal, 2. Wand)");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                shop.BuyAnimal(this);
                break;
            case 2:
                shop.BuyWand(this);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void CastSpell()
    {
        Console.WriteLine("Enter the magicspell you want to perform: (Vingardium Leviosa, Alohomora, Lumos.");
        string spell = Console.ReadLine();

        switch (spell.ToLower())
        {
            case "vingardium leviosa":
                Console.WriteLine("You made a chosen item fly!");
                break;
            case "alohomora":
                Console.WriteLine("You unlocked an object!");
                break;
            case "lumos":
                Console.WriteLine("Wow, your wand is just like a flashlight!");
                break;
            default:
                Console.WriteLine("Unknown magicspell.");
                break;
        }
    }
}

class MagicShop
    { 
    public void BuyAnimal(HarryPotterCharacter character)
    {
        Console.WriteLine("Choose the animal you want to have with you as a companion (1. Owl, 2. Rat, 3. Cat):");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                character.Inventory.Add("Owl");
                Console.WriteLine("You chose an owl!");
                break;
            case 2:
                character.Inventory.Add("Rat");
                Console.WriteLine("You chose a rat!");
                break;
            case 3:
                character.Inventory.Add("Cat");
                Console.WriteLine("You chose a cat!");
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void BuyWand(HarryPotterCharacter character)
    {
        Console.WriteLine("Choose your wand (1. Phoenixwand, 2. Unicornwand, 3. Trollwand):");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice) 
        {
            case 1:
                character.Inventory.Add("Phoenix Wand");
                Console.WriteLine("You chose a Phoenixwand!");
                break;
            case 2:
                character.Inventory.Add("Unicorn Wand");
                Console.WriteLine("You chose a Unicornwand!");
                break;
            case 3:
                character.Inventory.Add("Troll Wand");
                Console.WriteLine("You chose a Trollwand!");
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}