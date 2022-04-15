using System;
using System.Text;

namespace Step_Dependencies
{
    public class Processes
    {
        public int[] runningProcesses;
        public int timeCount = 0;

        public Processes()
        {
            runningProcesses = new int[5];
            foreach( int i in runningProcesses)
            {
                runningProcesses[i] = 0;
            }


        }
        public static int getLetterTime(char c)
        {
            //int letterTime = 60;
            int letterTime = ((int)c - 4);
            return letterTime;
        }

        public static int getTotalTime(StepDependency stepDependency)
        {
            int totalTime = 0;
            foreach (var step in stepDependency.stepsList)
            {
                totalTime = totalTime + getLetterTime(step.First.Value);
                totalTime = totalTime + getLetterTime(step.Last.Value);
            }
            return totalTime;
        }

        public static int getQuickestTime(StepDependency stepDependency)
        {
            int quickestTime = 0;
            char[] processOne = new char[26];
            char[] processTwo = new char[26];
            char[] processThree = new char[26];
            char[] processFour = new char[26];
            char[] processFive = new char[26];

            putEmptyChars(processOne);
            putEmptyChars(processTwo);
            putEmptyChars(processThree);
            putEmptyChars(processFour);
            putEmptyChars(processFive);



            return quickestTime;
        }

        public void SubtractingTimeOffAsciiValues()
        {
            for(int i = 0; i < 5; i++)
            {
                movingToNextAvaiableProcess(i);
                runningProcesses[i]--;
            }
            timeCount++;
        }

        public void movingToNextAvaiableProcess(int i)
        {
            var steps = new StepDependency();
            if(runningProcesses[i] == 0)
            {
                steps.GetDependentOrder();
                steps.currValue = runningProcesses[i];

            }
        }

        private static void putEmptyChars(char[] process)
        {
            for (int i = 0; i < 26; i++)
            {
                process[i] = ' ';
            }
        }
    }
}
