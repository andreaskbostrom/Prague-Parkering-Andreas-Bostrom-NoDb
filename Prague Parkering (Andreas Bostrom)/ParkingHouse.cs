using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parkering__Andreas_Bostrom_
{
    class ParkingHouse
    {


        public Vehicle[,] parkingSpots = new Vehicle[20, 2];

        public ParkingHouse() //Constructor tht initializes the parking spot.
        {
            Console.WriteLine("Your in Constructor PArkingHouse");
            for (int i = 0; i < parkingSpots.GetLength(0); i++)
            {
                for (int k = 0; k < parkingSpots.GetLength(1); k++)
                {
                    parkingSpots[i, k] = new Vehicle();
                }
            }
        }
        public void TestVehicles() //all dummy vehicles live here.
        {
            Vehicle vehicle1 = new Vehicle("car", "bbb 888", new DateTime(2021, 10, 23, 09, 30, 00));
            Vehicle vehicle2 = new Vehicle("car", "ccc 888", new DateTime(2021, 10, 20, 20, 30, 00));
            Vehicle vehicle3 = new Vehicle("car", "ddd 888", new DateTime(2021, 10, 4, 05, 30, 00));
            Vehicle vehicle14 = new Vehicle("mc", "eee 888", new DateTime(2021, 10, 9, 08, 30, 00));
            Vehicle vehicle15 = new Vehicle("mc", "fff 888", new DateTime(2021, 10, 1, 03, 30, 00));
            Vehicle vehicle16 = new Vehicle("mc", "fff 888", new DateTime(2021, 10, 1, 03, 30, 00));
            parkingSpots[0, 0] = vehicle1;
            parkingSpots[1, 0] = vehicle2;
            parkingSpots[2, 0] = vehicle3;
            parkingSpots[3, 0] = vehicle14;
            parkingSpots[3, 1] = vehicle15;
            parkingSpots[4, 0] = vehicle16;
        }

        public void SearchForEmptySpots(Vehicle vehicle) //I'm looking for empty spots for mc or car here.
        {
            int[] foundSpot = new int[2];

            for (int spot = 0; spot < parkingSpots.GetLength(0); spot++)
            {
                for (int depth = 0; depth < parkingSpots.GetLength(1); depth++)
                {
                    if (parkingSpots[spot, depth].VehicleType == "car")
                    {
                        break;
                    }
                    else if (parkingSpots[spot, depth].VehicleType == "mc" && vehicle.VehicleType == "car")
                    {
                        break;
                    }
                    if (parkingSpots[spot, depth].VehicleType == null)
                    {

                        if (parkingSpots[spot, depth].VehicleType == null)
                        {
                            foundSpot[0] = spot;
                            foundSpot[1] = depth;
                            ParkVehicle(foundSpot, vehicle);
                            goto endLoop;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"sorry no spots avalible for {vehicle.VehicleType}");
                    }

                }
            }
        endLoop: Console.WriteLine("");


            // return foundSpot;
        }
        public void ParkVehicle(int[] foundSpot, Vehicle vehicle) // when i found a parking spot im putting it in here.
        {
            //park vehicle at empty spot.
            parkingSpots[foundSpot[0], foundSpot[1]] = vehicle;
        }
        public void SearchForVehicle(string findVehicle, Vehicle vehicle)
        {
            int[] foundVehicle = new int[2];
            for (int spot = 0; spot < parkingSpots.GetLength(0); spot++)
            {
                for (int depth = 0; depth < parkingSpots.GetLength(1); depth++)
                {
                    if (parkingSpots[spot, depth].LicencePlate == vehicle.LicencePlate)
                    {
                        Console.WriteLine("we found your vehicle");
                        Console.WriteLine($"parking spot:{spot} depth:{depth} {vehicle.LicencePlate}");
                        foundVehicle[0] = spot;
                        foundVehicle[1] = depth;
                    }
                    break;
                }
            }
            Console.WriteLine("could not found the vehicle");

            //breakLoop: Console.WriteLine("break loop");
        }
        public void PrintParkingSpots() //I print my parking space out here.
        {
            for (int spot = 0; spot < parkingSpots.GetLength(0); spot++)
            {
                for (int depth = 0; depth < parkingSpots.GetLength(1); depth++)
                {
                    Console.WriteLine($"parkingspot [{spot}] {parkingSpots[spot, depth].VehicleType} " +
                        $"{parkingSpots[spot, depth].LicencePlate} {parkingSpots[spot, depth].Arrival}");
                }
                Console.WriteLine();
            }
        }

        public void CheckOutAndPay(string lisenceNumber) //here im sending the bill and deleting the car or mc here.
        {
            for (int spot = 0; spot < parkingSpots.GetLength(0); spot++)
            {
                for (int depth = 0; depth < parkingSpots.GetLength(1); depth++)
                {

                    if (parkingSpots[spot, depth].LicencePlate == lisenceNumber)
                    {
                        PayBill(parkingSpots[spot, depth], parkingSpots);
                        Vehicle vehicle = new Vehicle();
                        parkingSpots[spot, depth] = vehicle;

                        return;
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("____________________________");
            Console.WriteLine("Can't find that Licens plate");
            Console.WriteLine("____________________________");
        }

        public void PayBill(Vehicle vehicle, Vehicle[,] parking)
        {
            if (vehicle.VehicleType == "car")
            {
                DateTime avslut = DateTime.Now;
                TimeSpan parkedTime = avslut.Subtract(vehicle.Arrival);
                int cost = 0;
                int hours = 0;

                cost = 40 * parkedTime.Hours;
                cost = cost + 40;
                hours = 1 + parkedTime.Hours;
                Console.WriteLine("_______________________________________________________________________________________");
                Console.WriteLine($"your car have benn parked for {hours} hours (started hours). Total cost is : {cost}kr.");
                Console.WriteLine("_______________________________________________________________________________________");
                Console.ReadKey();
                return;
            }
            if (vehicle.VehicleType == "mc")
            {
                DateTime avslut = DateTime.Now;
                TimeSpan parkedTime = avslut.Subtract(vehicle.Arrival);
                int cost = 0;
                int hours = 0;

                cost = 25 * parkedTime.Hours;
                cost = cost + 25;
                hours = 1 + parkedTime.Hours;
                Console.WriteLine("__________________________________________________________________________________________");
                Console.WriteLine($"Your mc have been parked for {hours} hours (started hours). Your total cost is: {cost}kr.");
                Console.WriteLine("Press any key");
                Console.WriteLine("__________________________________________________________________________________________");
                Console.ReadKey();
                return;
            }
        }
        public void SearchVehicle(string value)  //Checking for licenceplate in th eparking spots.
        {
            //Algoritm som loopar igenom matrixen
            for (int spot = 0; spot < parkingSpots.GetLength(0); spot++)
            {
                for (int depth = 0; depth < parkingSpots.GetLength(1); depth++)
                {

                    //Stannar up loopen om den hittar value i ett parkerat fordon
                    if (parkingSpots[spot, depth].LicencePlate == value)
                    {
                        Console.WriteLine("__________________________________________________________________________________");
                        Console.WriteLine($"your {parkingSpots[spot, depth].VehicleType} are parked at: [{spot}] [{depth}]");
                        Console.WriteLine("press any key");
                        Console.WriteLine("__________________________________________________________________________________");
                        Console.ReadKey();
                        return;
                    }

                    //Else fångar upp om fordonet inte finns och skickar tillbaka till menyn
                }
            }
            Console.WriteLine("__________________________");
            Console.WriteLine("Vheicle dose not exist.\n" +
                              "Press any key");
            Console.WriteLine("__________________________");
            Console.ReadKey();
        }

        public void MoveVehicle(string moveCar)
        {
            for (int spot = 0; spot < parkingSpots.GetLength(0); spot++)
            {
                for (int depth = 0; depth < parkingSpots.GetLength(1); depth++)
                {
                    if (parkingSpots[spot, depth].LicencePlate == moveCar)
                    {
                        Console.WriteLine($"your {parkingSpots[spot, depth].VehicleType} are parked at: [{spot}] [{depth}]");
                        SearchForEmptySpots(parkingSpots[spot, depth]);
                        parkingSpots[spot, depth] = new Vehicle();
                        Console.ReadKey();
                        return;
                    }
                }
            }
            Console.WriteLine("____________________");
            Console.WriteLine("Vheicle dose not exist\n" +
                              "Press any key");
            Console.WriteLine("____________________");
            Console.ReadKey();
        }
    }
}
