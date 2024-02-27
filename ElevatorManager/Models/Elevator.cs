using ElevatorManager.Enum;
using ElevatorManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager.Models
{
   
    public class Elevator : IElevator
    {
        public int CurrentFloor { get;  set; }
        public Direction Direction { get;  set; }
        public bool IsMoving { get;  set; }
        public int PassengerCount { get;  set; }
        public int MaxCapacity { get;  set; }

        public Elevator(int maxCapacity)
        {
            CurrentFloor = 1;
            Direction = Direction.Stationary;
            IsMoving = false;
            PassengerCount = 0;
            MaxCapacity = maxCapacity;
        }

        public void MoveToFloor(int targetFloor)
        {
            Direction = targetFloor > CurrentFloor ? Direction.Up : Direction.Down;
            IsMoving = true;

            //  elevator 
            Console.WriteLine($"Elevator moving {Direction} from floor {CurrentFloor} to floor {targetFloor}.");
            CurrentFloor = targetFloor;

            IsMoving = false;
            Direction = Direction.Stationary;
            Console.WriteLine($"Elevator reached floor {CurrentFloor}.");
        }

        public void LoadPassengers(int passengerCount)
        {
            if (PassengerCount + passengerCount <= MaxCapacity)
            {
                PassengerCount += passengerCount;
                Console.WriteLine($"{passengerCount} passengers loaded. Current passenger count: {PassengerCount}");
            }
            else
            {
                Console.WriteLine("Passenger limit exceeded. Elevator is full.");
            }
        }

    }
}
