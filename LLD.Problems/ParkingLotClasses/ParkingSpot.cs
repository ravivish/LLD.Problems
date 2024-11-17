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

        public bool IsAvailable()
        {
            return parkedVehicle == null;
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            if (IsAvailable() && vehicle.VehicleType == vehicleType)
            {
                parkedVehicle = vehicle;
            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle type or spot already occupied.");
            }
        }

        public void UnparkVehicle()
        {
            parkedVehicle = null;
        }

        public VehicleType GetVehicleType()
        {
            return vehicleType;
        }

        public Vehicle GetParkedVehicle()
        {
            return parkedVehicle;
        }

        public int GetSpotNumber()
        {
            return spotNumber;
        }
    }
}