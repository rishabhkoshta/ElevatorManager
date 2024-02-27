using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager.Interface
{


    public interface IElevatorController
    {
        public void CallElevator(int floor, int passengers);
        public void DisplayElevatorStatus();
    }
}
