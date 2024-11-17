namespace LLD.Problems.ParkingLotClasses
{
    internal class ParkingSpot
    {
        private readonly int spotNumber;
        private readonly VehicleType vehicleType;
        private Vehicle parkedVehicle;

        public ParkingSpot(int spotNumber, VehicleType vehicleType)
        {
            this.spotNumber = spotNumber;
            this.vehicleType = vehicleType;
        }

        public bool isAvailable()
        {
            return parkedVehicle == null;
        }

        public void parkVehicle(Vehicle vehicle)
        {
            if (isAvailable() && vehicle.VehicleType == vehicleType)
            {
                parkedVehicle = vehicle;
            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle type or spot already occupied.");
            }
        }

        public void unparkVehicle()
        {
            parkedVehicle = null;
        }

        public VehicleType getVehicleType()
        {
            return vehicleType;
        }

        public Vehicle getParkedVehicle()
        {
            return parkedVehicle;
        }

        public int getSpotNumber()
        {
            return spotNumber;
        }
    }
}