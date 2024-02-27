using ElevatorManager.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager.Interface
{
    public interface IElevator
    {
       public bool IsMoving { get; set; }
        int CurrentFloor { get;  set; }
        Direction Direction { get;  set; }         
        int PassengerCount { get;  set; }
        int MaxCapacity { get;  set; }

        public void MoveToFloor(int targetFloor);
        public void LoadPassengers(int passengerCount);
       
    }
}
