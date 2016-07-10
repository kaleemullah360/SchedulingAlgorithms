using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOS_A1_P1
{
    class Process
    {
        public string name { get; set; }
        public int arrivalTime { get; set; }
        public int brustTime { get; set; }
        public int TimeSpentOnProcessor { get; set; }
        public int WaitingTime { get; set; }

        public bool hasEverAssignedToSystem { get; set; }
    }
}
