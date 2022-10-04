using System;

namespace Prague_Parkering__Andreas_Bostrom_
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingHouse parkingHouse = new ParkingHouse();
            parkingHouse.TestVehicles();
            Console.WriteLine("menu");
            bool menu = true;
            while (menu)
            {
                string command = "0";
                Console.WriteLine("------------------------------------");
                Console.WriteLine("PRESS 1 => Park a vehicle");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("PRESS 2 => Check out vehicle");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("PRESS 3 => Move vehicle");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("PRESS 4 => Search for vehicle");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("PRESS 5 => Print out parked vehicles");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("End Program Press 6");
                Console.WriteLine("------------------------------------");

                command = Console.ReadLine();
                if (command == "1")
                {
                    Console.WriteLine("What kind of vehicle do you want to park?");
                    Console.WriteLine("Type: car");
                    Console.WriteLine("or");
                    Console.WriteLine("Type: mc");
                    string vehicleType = Console.ReadLine();
                    if (vehicleType.ToLower() == "car" || vehicleType.ToLower() == "mc")
                    {
                        Console.WriteLine($"Please type you {vehicleType}s licence plate number:");
                        string licencePlate = Console.ReadLine();
                        Console.WriteLine("\n___________________________");
                        Vehicle vehicle = new Vehicle(vehicleType, licencePlate);
                        parkingHouse.SearchForEmptySpots(vehicle);
                        Console.Clear();
                        Console.WriteLine("_________________________________________");
                        Console.WriteLine($"Your {vehicleType} is successfully parked");
                        Console.WriteLine("_________________________________________");
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("_________________________________________");
                        Console.WriteLine("Sorry, you have to type \"car\" or \"mc\"");
                        Console.WriteLine("_________________________________________");
                    }



                    continue;
                }
                if (command == "2")
                {

                    Console.WriteLine("Please type the Licence plate number");
                    string lisenceNumber = Console.ReadLine();
                    parkingHouse.CheckOutAndPay(lisenceNumber);
                    //Console.Clear();
                    continue;
                }
                if (command == "3")
                {
                    Console.WriteLine("Please insert your Licenseplate value");
                    string lisencePlateTest = Console.ReadLine();
                    parkingHouse.MoveVehicle(lisencePlateTest);
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                if (command == "4")
                {
                    Console.WriteLine("Please insert the vehicles licence plate that you are looking for:");
                    string findVehicle = Console.ReadLine();
                    parkingHouse.SearchVehicle(findVehicle);
                    Console.Clear();
                    continue;
                }
                if (command == "5")
                {
                    parkingHouse.PrintParkingSpots();
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                if (command == "6")
                {
                    Console.WriteLine("Have a nice day");
                    menu = false;
                    continue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("________________________________");
                    Console.WriteLine("Sorry, wrong comand.\nTyr again.");
                    Console.WriteLine("________________________________");
                }

            }
        }
    }
}
