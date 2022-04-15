using System;
using System.Text;

namespace Step_Dependencies
{
    public class Processes
    {
        public static int getLetterTime(char c)
        {
            int letterTime = 60;
            letterTime = letterTime + ((int)c - 64);
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

        private static void putEmptyChars(char[] process)
        {
            for (int i = 0; i < 26; i++)
            {
                process[i] = ' ';
            }
        }
    }
}
