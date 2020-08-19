using System;
using System.Collections.Generic;
using System.Linq;

namespace JurasicPark
{

    class Dinosaur
    {

        public string Name { get; set; }
        public string DietType { get; set; }

        public DateTime WhenAcquired { get; set; }

        public int Weight { get; set; }

        public int EnclosureNumber { get; set; }

    }



    class Program
    {

        static void Greeting()
        {

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("=============== Welcome to Mo's Jurassic Park's Database ===============");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();



        }

        static void menu()
        {

            Console.WriteLine("What do you need to do?");

            Console.WriteLine();

            Console.WriteLine("View: view a list of all dinosaurs in the park's database");
            Console.WriteLine("Add: add a new dinosaur into the database");
            Console.WriteLine("Remove: Remove a dinosaur from the database");
            Console.WriteLine("Transfer: Transfer a dinosaur from one enclosure to a new one");
            Console.WriteLine("Summary: view a summary of total numbers of dinosaurs based on their diet");
            Console.WriteLine("Quit: quit the database");

            Console.WriteLine();

            Console.Write("Action: ");

        }



        static void Main(string[] args)
        {

            Greeting();

            var dinosaurs = new List<Dinosaur>(){

              new Dinosaur
              {
                Name = "Albertosaurus",
                DietType = "carnivore",
                WhenAcquired = DateTime.Now,
                Weight = 6000,
                EnclosureNumber = 126

              },
              new Dinosaur
              {
                Name = "Triceratops",
                DietType = "herbivore",
                WhenAcquired = DateTime.Now,
                Weight = 26500,
                EnclosureNumber = 64
              },
              new Dinosaur {

                Name = "Tyrannosaurus",
                DietType = "carnivore",
                WhenAcquired = DateTime.Now,
                Weight = 15500,
                EnclosureNumber = 132

              }

            };

            var quit = false;


            while (quit != true)
            {

                menu();

                var action = Console.ReadLine();

                if (action == "Quit")
                {

                    quit = true;

                    Console.WriteLine("-----Good bye----");
                }
                else if (action == "Add")
                {

                    Console.Write("What is the dino's name? Answer: ");
                    var name = Console.ReadLine();

                    Console.Write("What is the dino's diet? carnivore/herbivore. Answer: ");
                    var diet = Console.ReadLine();


                    Console.WriteLine("what is the weight of the dino in lb? Answer: ");
                    var weight = int.Parse(Console.ReadLine());


                    Console.WriteLine("What is the enclosure number you wish to put the dino in? Answer: ");
                    var enclosure = int.Parse(Console.ReadLine());


                    var dino = new Dinosaur()
                    {

                        Name = name,
                        DietType = diet,
                        Weight = weight,
                        EnclosureNumber = enclosure,
                        WhenAcquired = DateTime.Now


                    };

                    dinosaurs.Add(dino);



                }
                else if (action == "Remove")
                {

                    Console.Write("What is the dino's name? Answer: ");
                    var dinoName = Console.ReadLine();

                    var foundDino = dinosaurs.FirstOrDefault(Pet => Pet.Name == dinoName);

                    if (foundDino != null)
                    {

                        Console.WriteLine($"{foundDino.Name} is a {foundDino.DietType} dinosaur added on {foundDino.WhenAcquired} and weights {foundDino.Weight} lbs and it's location is enclosure number {foundDino.EnclosureNumber}");

                        dinosaurs.Remove(foundDino);

                        Console.WriteLine($"{foundDino.Name} has been successfully removed from the park's database");

                    }
                    else
                    {

                        Console.WriteLine("The dinosaur that your are looking for is not found");

                    }

                }
                else if (action == "Transfer")
                {

                    Console.Write("What is the dino's name? Answer: ");
                    var dinoName = Console.ReadLine();

                    var foundDino = dinosaurs.FirstOrDefault(Pet => Pet.Name == dinoName);

                    if (foundDino != null)
                    {
                        Console.WriteLine($"{foundDino.Name} is a {foundDino.DietType} dinosaur added on {foundDino.WhenAcquired} and weights {foundDino.Weight} lbs and it's location is enclosure number {foundDino.EnclosureNumber}");

                        var oldEnclosure = foundDino.EnclosureNumber;

                        Console.Write("What is the new enclosure no you wish to transfer the dino to? Answer: ");

                        var newEnclosure = int.Parse(Console.ReadLine());

                        foundDino.EnclosureNumber = newEnclosure;


                        Console.WriteLine($"Database is now updated and {foundDino.Name} is now transferred from enclosure number {oldEnclosure} to Enclosure number {newEnclosure}");

                        Console.Write("Is there is any thing else you need to do? press y for yes or press any key for no Answer: ");

                        var answer = Console.ReadLine();

                        if (answer != "y")
                        {

                            quit = true;

                        }



                    }
                    else
                    {
                        Console.WriteLine("The dinosaur that your are looking for is not found");
                    }


                }
                else if (action == "Summary")
                {

                    var numberOfHerbivores = dinosaurs.Where(diet => diet.DietType == "herbivore").Count();
                    var numberOfCarnivores = dinosaurs.Where(diet => diet.DietType == "carnivore").Count();


                    Console.WriteLine($"Our Jurasic Park has a total of {numberOfHerbivores + numberOfCarnivores} dinosaurs in which {numberOfHerbivores} are herbivores and {numberOfCarnivores} are carnivores");

                    Console.Write("Is there is any thing else you need to do? press y for yes or press any key for no Answer: ");

                    var answer = Console.ReadLine();

                    if (answer != "y")
                    {

                        quit = true;

                    }
                }













            }









        }
    }
}
