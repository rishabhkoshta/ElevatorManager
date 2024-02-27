using ElevatorManager.Enum;
using ElevatorManager.Interface;
using ElevatorManager.Models;
using NUnit.Framework;
using System;

namespace Elevator.Test
{
    [TestFixture]
    public class ElevatorTests
    {
        [Test]
        public void Elevator_MoveToFloor_ShouldUpdateCurrentFloorAndDirection()
        {
            // Arrange
            int maxCapacity = 10;
            IElevator elevator = new ElevatorManager.Models.Elevator(maxCapacity);

            // Act
            elevator.MoveToFloor(5);

            // Assert
            Assert.AreEqual(5, elevator.CurrentFloor);
            Assert.AreEqual(Direction.Stationary, elevator.Direction);
        }

        [Test]
        public void Elevator_LoadPassengers_ShouldUpdatePassengerCount()
        {
            // Arrange
            int maxCapacity = 10;
            IElevator elevator = new ElevatorManager.Models.Elevator(maxCapacity);

            // Act
            elevator.LoadPassengers(3);

            // Assert
            Assert.AreEqual(3, elevator.PassengerCount);
        }
    }

    [TestFixture]
    public class ElevatorControllerTests
    {
        [Test]
        public void ElevatorController_CallElevator_ShouldMoveNearestAvailableElevator()
        {
            // Arrange
            IElevator[] elevators = { new ElevatorManager.Models.Elevator(10), new ElevatorManager.Models.Elevator(10), new ElevatorManager.Models.Elevator(10) };
            IElevatorController elevatorController = new ElevatorController(elevators);

            // Act
            elevatorController.CallElevator(3, 5);

            // Assert
            foreach (var elevator in elevators)
            {
                Assert.AreEqual(3, elevator.CurrentFloor);
            }
        }

        [Test]
        public void ElevatorController_CallElevator_ShouldHandleNoAvailableElevators()
        {
            // Arrange
            IElevator[] elevators = { new ElevatorManager.Models.Elevator(10), new ElevatorManager.Models.Elevator(10), new ElevatorManager.Models.Elevator(10) };
            IElevatorController elevatorController = new ElevatorController(elevators);

            // Act
            // Move all elevators to simulate they are all busy
            foreach (var elevator in elevators)
            {
                elevator.MoveToFloor(7);
            }

            // Assert
            Assert.Throws<InvalidOperationException>(() => elevatorController.CallElevator(3, 5));
        }
    }
}