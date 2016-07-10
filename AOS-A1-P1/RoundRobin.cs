using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOS_A1_P1
{
    class RoundRobin
    {
        public void simulate()
        {
            try
            {

                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(@"Input.txt");
                System.IO.StreamWriter O_file = new System.IO.StreamWriter(@"Output.txt");
                file.ReadLine();
                O_file.WriteLine("*** Round Robin Simulation Started ***");
                int TimeQuntum = 0, tempBrustTime, tempArrivalTime, numberofProcess = 0, totalwaitingtime = 0, totalresponsetime = 0;

                Int32.TryParse(file.ReadLine(), out TimeQuntum);
                ProcessQueue ProcessQueue = new ProcessQueue();
                file.ReadLine();
                //File Reading
                while ((line = file.ReadLine()) != null)
                {
                    string[] parse = line.Split('|');
                    Process p = new Process();
                    p.name = parse[0];
                    Int32.TryParse(parse[1], out tempBrustTime);
                    Int32.TryParse(parse[2], out tempArrivalTime);
                    p.arrivalTime = tempArrivalTime;
                    p.brustTime = tempBrustTime;
                    p.TimeSpentOnProcessor = 0;
                    p.WaitingTime = 0;
                    p.hasEverAssignedToSystem = false;
                    ProcessQueue.insertIntoQueue(p);
                    numberofProcess++;

                }
                //Sortuing on Arival Time
                ProcessQueue.sort();

                Process p1;
                int time = 0;
                while ((p1 = ProcessQueue.getFromQueue()) != null)
                {
                    if (p1.arrivalTime <= time)
                    {
                        //Response Time
                        if (!p1.hasEverAssignedToSystem)
                        {
                            // Console.WriteLine(time - p1.arrivalTime);
                            totalresponsetime = totalresponsetime + time - p1.arrivalTime;
                        }

                        //Time Quantum

                        for (int i = 0; i < TimeQuntum; i++)
                        {
                            //Check if Process Complete
                            if (p1.brustTime != p1.TimeSpentOnProcessor)
                            {
                                //Gant Chart
                                ////Console.Write(p1.name);
                                O_file.WriteLine(p1.name);
                                p1.TimeSpentOnProcessor++;
                                time++;
                                p1.hasEverAssignedToSystem = true;
                                //Waiting time incremenet call for the other process
                                ProcessQueue.incrementWaitingTime(time);
                            }
                            else
                            {
                                break;
                            }

                        }
                        Console.Write("- ");
                        O_file.WriteLine("  -  ");
                        //Place in the ready queue again
                        if (p1.brustTime != p1.TimeSpentOnProcessor)
                        {
                            ProcessQueue.insertIntoQueue(p1);
                        }
                        else
                        {
                            //getWaiting Time of
                            //  Console.WriteLine(p1.WaitingTime);
                            totalwaitingtime = totalwaitingtime + p1.WaitingTime;
                        }

                    }
                    else
                    {

                    }

                }
                /*Console.WriteLine("\nThroughput = " + numberofProcess + "/" + time);
                Console.WriteLine("Average Waiting Time = " + totalwaitingtime + "/" + numberofProcess);
                Console.WriteLine("Average Response Time = " + totalresponsetime + "/" + numberofProcess);*/

                O_file.WriteLine("\nThroughput = " + numberofProcess + "/" + time);
                O_file.WriteLine("Average Waiting Time = " + totalwaitingtime + "/" + numberofProcess);
                O_file.WriteLine("Average Response Time = " + totalresponsetime + "/" + numberofProcess);
                file.Close();
                O_file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
