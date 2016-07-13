using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOS_A1_P1
{
    class CentralQueue
    {
        public void simulate()
        {

            try
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(@"Input.txt");
                System.IO.StreamWriter O_file = new System.IO.StreamWriter(@"Output.txt");

                file.ReadLine();
                O_file.WriteLine("*** Centeral Queue Simulation Started ***");
                int TimeQuntum = 0, tempBrustTime, tempArrivalTime, numberofProcess = 0, numberofCPU;
                //totalwaitingtime = 0, totalresponsetime = 0;

                Int32.TryParse(file.ReadLine(), out TimeQuntum);
                file.ReadLine();
                // Assuming No of processores equals to 3
                numberofCPU = 3;
                ProcessQueue queue = new ProcessQueue();

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
                    queue.insertIntoQueue(p);
                    numberofProcess++;

                }
                //Sortuing on Arival Time
                queue.sort();

                int time = 0;
                int[] TimeQuantumofCPU = new int[numberofCPU];

                //making all zeros
                for (int i = 0; i < TimeQuantumofCPU.Length; i++)
                {
                    TimeQuantumofCPU[i] = 0;
                }

                Process[] assignedproccesstoCPU = new Process[numberofCPU];
                while (true)
                {
                    O_file.WriteLine("At Time " + time);
                    for (int i = 0; i < numberofCPU; i++)
                    {
                        //Assigning Procces to CPU if available
                        if (assignedproccesstoCPU[i] == null)
                        {
                            Process p1 = queue.getFromQueue();
                            if (p1 != null && p1.arrivalTime <= time)
                            {
                                assignedproccesstoCPU[i] = p1;
                            }
                            else if (p1 != null)
                            {
                                queue.insertIntoQueueStart(p1);
                            }
                        }


                        if (assignedproccesstoCPU[i] != null)
                        {
                            Process p1 = assignedproccesstoCPU[i];

                            O_file.WriteLine("Proccessor" + i + "  running  " + p1.name);
                            p1.TimeSpentOnProcessor++;
                            TimeQuantumofCPU[i] = TimeQuantumofCPU[i] + 1;

                            // if proccess Complete on a proceess
                            if (p1.brustTime == p1.TimeSpentOnProcessor)
                            {
                                assignedproccesstoCPU[i] = null;
                            }

                            if (TimeQuantumofCPU[i] == TimeQuntum && p1.brustTime != p1.TimeSpentOnProcessor)
                            {
                                TimeQuantumofCPU[i] = 0;
                                assignedproccesstoCPU[i] = null;
                                queue.insertLastintoqueue(p1);
                            }
                        }
                    }
                    time++;
                    if (assignedproccesstoCPU.All(p => p == null) == true && queue.numberOfProcessinQueue() == 0)
                        break;
                }

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
