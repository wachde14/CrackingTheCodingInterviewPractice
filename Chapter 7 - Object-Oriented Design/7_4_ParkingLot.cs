using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Chapter_7___Object_Oriented_Design
{
    /// <summary>
    /// Parking Lot: Design a parking lot using object-oriented principles.
    /// • The parking lot has multiple levels. Each level has multiple rows of spots.
    /// • The parking lot can park motorcycles, cars, and buses.
    /// • The parking lot has motorcycle spots, compact spots, and large spots.
    /// • A motorcycle can park in any spot.
    /// • A car can park in either a single compact spot or a single large spot.
    /// • A bus can park in five large spots that are consecutive and within the same row. It cannot park in small spots.
    /// /// </summary>
    public class LargeSpotSection
    {
        private int numberOfOpenSpots;
        public int[] largeSpots;

        public LargeSpotSection(int size)
        {
            numberOfOpenSpots = size;
            largeSpots = new int[size];

            for (int i = 0; i < largeSpots.Length; i++)
            {
                largeSpots[i] = -1;
            }
        }

        public bool CanParkCar()
        {
            return numberOfOpenSpots > 0;
        }

        public bool CanParkBus()
        {
            if (numberOfOpenSpots <= 4)
            {
                return false;
            }

            for (int i = 0; i < largeSpots.Length; i++)
            {
                //Sliding Window to check for 5 consecutive spots

            }

            return false;
        }

        public void ReorganizeBusParking()
        {
            //"Defrag" the largeSpots array for more optimal parking
        }
    }

    public class ParkingLot
    {
        public int motorcycleSpotsAvailable;
        public int compactSpotsAvailable;
        public List<LargeSpotSection> largeSpotSectionList;

        public bool CanParkMotorcycle()
        {
            if (motorcycleSpotsAvailable <= 0)
            {
                return false;
            }

            return true;
        }

        public bool CanParkCar()
        {
            if (compactSpotsAvailable > 0)
            {
                return true;
            }

            foreach (LargeSpotSection largeSpot in largeSpotSectionList)
            {
                if (largeSpot.CanParkCar())
                {
                    return true;
                }
            }

            return false;
        }

        public bool CanParkBus()
        {
            foreach (LargeSpotSection largeSpot in largeSpotSectionList)
            {
                if (largeSpot.CanParkBus())
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class ParkingLotComplex
    {
        private readonly List<ParkingLot> _floors;

        public ParkingLotComplex(List<ParkingLot> inputFloors)
        {
            _floors = inputFloors;
        }

        void Park(Motorcycle motorcycle)
        {
            foreach (ParkingLot parkingLot in _floors)
            {
                if (parkingLot.CanParkMotorcycle())
                {
                    //Park motorcycle by a unique identifier
                    return;
                }
            }

            throw new Exception("Cannot park motorcycle");
        }

        void Park(Car car)
        {
            foreach (ParkingLot parkingLot in _floors)
            {
                if (parkingLot.CanParkCar())
                {
                    //Park car by a unique identifier
                    return;
                }
            }

            throw new Exception("Cannot park car");
        }

        void Park(Bus bus)
        {
            foreach (ParkingLot parkingLot in _floors)
            {
                if (parkingLot.CanParkBus())
                {
                    //Park bus by a unique identifier
                    return;
                }
            }

            throw new Exception("Cannot park bus");
        }
    }

    public abstract class Vehicle
    {
        public string LicensePlateNumber;
        public string DriverName;
    }

    public class Car : Vehicle
    {
        public Car()
        {
        }
    }

    public class Bus : Vehicle
    {
        public Bus()
        {
        }
    }

    public class Motorcycle : Vehicle
    {
        public Motorcycle()
        {
        }
    }

    public class _7_4_ParkingLotTests
    {
        [Test]
        public void _7_4_ParkingLot_WithParkingRequests_ShouldArrangeCarsSuccessfully()
        {
            //Arrange
        }
    }
}
