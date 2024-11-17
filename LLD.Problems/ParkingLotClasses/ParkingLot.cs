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
        private static ParkingLot instance;
        private readonly List<Level> levels;

        private ParkingLot()
        {
            levels = new List<Level>();
        }

        public static ParkingLot getInstance()
        {
            if (instance == null)
            {
                instance = new ParkingLot();
            }
            return instance;
        }

        public void addLevel(Level level)
        {
            levels.Add(level);
        }

        public bool parkVehicle(Vehicle vehicle)
        {
            foreach (Level level in levels)
            {
                if (level.parkVehicle(vehicle))
                {
                    Console.WriteLine("Vehicle parked successfully.");
                    return true;
                }
            }
            Console.WriteLine("Could not park vehicle.");
            return false;
        }

        public bool unparkVehicle(Vehicle vehicle)
        {
            foreach (Level level in levels)
            {
                if (level.unparkVehicle(vehicle))
                {
                    return true;
                }
            }
            return false;
        }

        public void displayAvailability()
        {
            foreach (Level level in levels)
            {
                level.displayAvailability();
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

        public bool parkVehicle(Vehicle vehicle)
        {
            foreach (ParkingSpot spot in parkingSpots)
            {
                if (spot.isAvailable() && spot.getVehicleType() == vehicle.VehicleType)
                {
                    spot.parkVehicle(vehicle);
                    return true;
                }
            }
            return false;
        }

        public bool unparkVehicle(Vehicle vehicle)
        {
            foreach (ParkingSpot spot in parkingSpots)
            {
                if (!spot.isAvailable() && spot.getParkedVehicle().Equals(vehicle))
                {
                    spot.unparkVehicle();
                    return true;
                }
            }
            return false;
        }

        public void displayAvailability()
        {
            Console.WriteLine("Level " + floor + " Availability:");
            foreach (ParkingSpot spot in parkingSpots)
            {
                Console.WriteLine("Spot " + spot.getSpotNumber() + ": " + (spot.isAvailable() ? "Available For" : "Occupied By ") + " " + spot.getVehicleType());
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
