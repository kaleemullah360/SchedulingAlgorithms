using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOS_A1_P1
{
    class ProcessQueue
    {
        private List<Process> list = new List<Process>();
        public void insertIntoQueue(Process p)
        {
            list.Add(p);
        }
        public void insertIntoQueueStart(Process p)
        {
            List<Process> templist = new List<Process>();
            templist.Add(p);
            //list = null;
            list = templist.Concat(list).ToList();
            //  list = templist;
        }

        public void insertLastintoqueue(Process p)
        {
            List<Process> templist = new List<Process>();
            templist.Add(p);
            list = list.Concat(templist).ToList();
        }
        public Process getFromQueue()
        {
            if (list.Count() != 0)
            {
                Process p = list.ElementAt<Process>(0);
                list.RemoveAt(0);
                return p;

            }
            else
                return null;
        }

        public int numberOfProcessinQueue()
        {
            return list.Count;
        }

        public void sort()
        {
            list.Sort((x, y) => x.arrivalTime.CompareTo(y.arrivalTime));
        }

        public void incrementWaitingTime(int time)
        {
            foreach (Process p in list)
            {
                if (p.arrivalTime < time)
                    p.WaitingTime++;
            }

        }
    }
}
