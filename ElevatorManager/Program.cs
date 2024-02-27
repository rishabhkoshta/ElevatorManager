using ElevatorManager.Interface;
using ElevatorManager.Models;

class Program
{
    static void Main()
    {
        // Dependency injection of elevators into the controller
        IElevator[] elevators = { new Elevator(10), new Elevator(10), new Elevator(10) };
        IElevatorController elevatorController = new ElevatorController(elevators);

        while (true)
        {
            try
            {
                Console.WriteLine("Enter floor number (1-10) and number of passengers waiting (0-10):");
                int floor = int.Parse(Console.ReadLine());
                int passengers = int.Parse(Console.ReadLine());

                elevatorController.CallElevator(floor, passengers);
                elevatorController.DisplayElevatorStatus();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter valid numeric values.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
