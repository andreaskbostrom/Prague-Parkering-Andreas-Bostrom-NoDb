using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parkering__Andreas_Bostrom_
{
    class Vehicle
    {

        public string VehicleType;
        public DateTime Arrival;
        public string LicencePlate
        {
            get;
            set;
        }

        public Vehicle() //intitial Constructor
        {
        }

        public Vehicle(string vehicleType, string licencePlate) //Constructor with two objekts?
        {
            vehicleType = vehicleType.ToLower();
            licencePlate = licencePlate.ToLower();

            if (vehicleType == "car")
            {

                this.VehicleType = vehicleType;
                this.LicencePlate = licencePlate;
                this.Arrival = DateTime.Now;
            }
            if (vehicleType == "mc")
            {
                this.VehicleType = vehicleType;
                this.LicencePlate = licencePlate;
                this.Arrival = DateTime.Now;
            }
        }
        public Vehicle(string vehicleType, string licencePlate, DateTime arrival) //Constructor with two objekts?
        {
            vehicleType = vehicleType.ToLower();
            licencePlate = licencePlate.ToLower();

            if (vehicleType == "car")
            {
                this.VehicleType = vehicleType;
                this.LicencePlate = licencePlate;
                this.Arrival = arrival;
            }
            if (vehicleType == "mc")
            {
                this.VehicleType = vehicleType;
                this.LicencePlate = licencePlate;
                this.Arrival = arrival;
            }
        }
    }
}
