using ElevatorManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager.Models
{
    public class ElevatorController :IElevatorController
    {
        private List<IElevator> elevators;

        //Dependency injection is used to inject instances of IElevator
        public ElevatorController(IEnumerable<IElevator> elevators)
        {
            this.elevators = elevators.ToList();
        }

        public void CallElevator(int floor, int passengers)
        {
            // logic to find the nearest available elevator
            IElevator nearestElevator = elevators
                .Where(e => !e.IsMoving)
                .OrderBy(e => Math.Abs(e.CurrentFloor - floor))
                .FirstOrDefault();

            if (nearestElevator != null)
            {
                nearestElevator.MoveToFloor(floor);
                nearestElevator.LoadPassengers(passengers);
            }
            else
            {
                Console.WriteLine("No available elevators. Please wait.");
            }
        }

        public void DisplayElevatorStatus()
        {
            foreach (var elevator in elevators)
            {
                Console.WriteLine($"Elevator: Current Floor - {elevator.CurrentFloor}, Direction - {elevator.Direction}, " +
                                  $"Moving - {elevator.IsMoving}, Passenger Count - {elevator.PassengerCount}");
            }
        }

    }
}
