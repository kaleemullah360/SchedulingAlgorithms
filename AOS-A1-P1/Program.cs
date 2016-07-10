using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOS_A1_P1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 1 for Round Robin simulation and 2 for Cenetral Queue Simulation");
            int pressedkey = 1 ;
            pressedkey = Console.Read();
            if (pressedkey == 1)
            {
                RoundRobin RR = new RoundRobin();
                RR.simulate();
            }
            else
            {
                CentralQueue CQ = new CentralQueue();
                CQ.simulate();
            }
            Console.WriteLine("Please refer to Output.txt file for result(s)");
            Console.WriteLine("File can be found in '.../AOS-A1-P1/AOS-A1-P1/bin/Debug'");
            
        }
    }
}
