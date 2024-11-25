using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LLD.Problems.ParkingLotClasses
{
    internal class ParkingLot
    {
        private static ParkingLot? instance;
        private readonly List<Level> levels;

        private ParkingLot()
        {
            levels = new List<Level>();
        }

        public static ParkingLot GetInstance()
        {
            if (instance == null)
            {
                instance = new ParkingLot();
            }
            return instance;
        }

        public void AddLevel(Level level)
        {
            levels.Add(level);
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            foreach (Level level in levels)
            {
                if (level.ParkVehicle(vehicle))
                {
                    Console.WriteLine("Vehicle parked successfully.");
                    return true;
                }
            }
            Console.WriteLine("Could not park vehicle.");
            return false;
        }

        public bool UnparkVehicle(Vehicle vehicle)
        {
            foreach (Level level in levels)
            {
                if (level.UnparkVehicle(vehicle))
                {
                    return true;
                }
            }
            return false;
        }

        public void DisplayAvailability()
        {
            foreach (Level level in levels)
            {
                level.DisplayAvailability();
            }
        }
    }

    public enum VehicleType
    {
        MOTORCYCLE,
        CAR,
        TRUCK
    }

    public abstract class Vehicle
    {
        protected VehicleType vehicleType;
        protected string vehicleNumber;

        public Vehicle(VehicleType vehicleType, string vehicleNumber)
        {
            this.vehicleType = vehicleType;
            this.vehicleNumber = vehicleNumber;
        }

        public VehicleType VehicleType
        {
            get
            {
                return vehicleType;
            }
        }
    }

    public class Level
    {
        private readonly int floor;
        private List<ParkingSpot> parkingSpots;

        public Level(int floor,int numberOfSpots)
        {
            this.floor = floor;
            this.parkingSpots = new List<ParkingSpot>(numberOfSpots);

            // Assign spots in ration of 50:40:10 for bikes, cars and trucks
            double spotsForBikes = 0.50;
            double spotsForCars = 0.40;

            int numBikes = (int)(numberOfSpots * spotsForBikes);
            int numCars = (int)(numberOfSpots * spotsForCars);

            for (int i = 1; i <= numBikes; i++)
            {
                parkingSpots.Add(new ParkingSpot(i, VehicleType.MOTORCYCLE));
            }
            for (int i = numBikes + 1; i <= numBikes + numCars; i++)
            {
                parkingSpots.Add(new ParkingSpot(i, VehicleType.CAR));
            }
            for (int i = numBikes + numCars + 1; i <= numberOfSpots; i++)
            {
                parkingSpots.Add(new ParkingSpot(i, VehicleType.TRUCK));
            }
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            foreach (ParkingSpot spot in parkingSpots)
            {
                if (spot.IsAvailable() && spot.GetVehicleType() == vehicle.VehicleType)
                {
                    spot.ParkVehicle(vehicle);
                    return true;
                }
            }
            return false;
        }

        public bool UnparkVehicle(Vehicle vehicle)
        {
            foreach (ParkingSpot spot in parkingSpots)
            {
                if (!spot.IsAvailable() && spot.GetParkedVehicle().Equals(vehicle))
                {
                    spot.UnparkVehicle();
                    return true;
                }
            }
            return false;
        }

        public void DisplayAvailability()
        {
            Console.WriteLine("Level " + floor + " Availability:");
            foreach (ParkingSpot spot in parkingSpots)
            {
                Console.WriteLine("Spot " + spot.GetSpotNumber() + ": " + (spot.IsAvailable() ? "Available For" : "Occupied By ") + " " + spot.GetVehicleType());
            }
        }

    }

    public class Car : Vehicle
    {
        public Car(string vehicleNumber) : base(VehicleType.CAR, vehicleNumber)
        {
        }
    }

    public class Truck : Vehicle
    {
        public Truck(string vehicleNumber) : base(VehicleType.TRUCK, vehicleNumber)
        {
        }
    }   

    public class Motorcycle : Vehicle
    {
        public Motorcycle(string vehicleNumber) : base(VehicleType.MOTORCYCLE, vehicleNumber)
        {
        }
    }

}
