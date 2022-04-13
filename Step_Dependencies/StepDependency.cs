using System;
using System.Collections.Generic;
using System.IO;

namespace Step_Dependencies
{
    public class StepDependency
    {
        public List<LinkedList<char>> stepsList = new List<LinkedList<char>>();
        public char[] orderOfNonDependent;
        public bool isCharDependent = true;
        public int charCount = 0;

        public StepDependency()
        {
        }
        public StepDependency(string file)
        {
            stepsList = createStepsList(file);
            orderOfNonDependent = new char[stepsList.Count];
        }
        private List<LinkedList<char>> createStepsList(string file)
        //This method returns a List of LinkedLists of chars after creating said list based on a file.
        {
            ListMaker(file);
            return stepsList;
        }
        
        //name needs work
        //This method takes in a file path and retrives a given text file from it
        public void ListMaker(string depedancySource)
        {
            System.IO.StreamReader dependancyTextReader = new System.IO.StreamReader(depedancySource);
            string lineToSearch;

            while ((lineToSearch = dependancyTextReader.ReadLine()) != null)
            {
                char dependant = ' ';
                char dependancy = ' ';
                int nextLineisItem = 0;
                foreach (char dep in lineToSearch)
                {
                    if(nextLineisItem == 2)
                    {
                        if(dependancy == ' ')
                        {
                            dependancy = dep;
                            nextLineisItem = 0;
                        }
                        else
                        {
                            dependant = dep;
                            nextLineisItem = 0;
                        }
                    }
                    //detects end of word Ste'p'
                    if(dep == 'p')
                    {
                        nextLineisItem++;
                    }
                    //detects space before dependant or dependency
                    if(dep == ' ' && nextLineisItem == 1)
                    {
                        nextLineisItem++;
                    }
                }
                //creates new linked list pair and saves them in stepsList
                LinkedList<char> dependancyPair = new LinkedList<char>();
                dependancyPair.AddFirst(dependancy);
                dependancyPair.AddLast(dependant);
                stepsList.Add(dependancyPair);
            }

        }
        public void GetDependentOrder()
        {
            var currList = 0;
            while(isCharDependent == true)
            {
                var firstList = stepsList[currList];
                var firstHead = firstList.First.Value;

                foreach (LinkedList<char> dependant in stepsList)
                {
                    if(firstHead == dependant.First.Next.Value)
                    {
                        break;
                    }
                    else
                    {
                        isCharDependent = false;
                        checkToSeeIfCharIsAlreadyWritten(firstHead);
                        CharCanBeWritten(firstHead, currList);
                    }
                }
                currList++;
            }

        }

        public void checkToSeeIfCharIsAlreadyWritten(char c)
        {
            bool foundChar = false;
            for(int i = 0; i < orderOfNonDependent.Length; i++)
            {
                if(orderOfNonDependent[i] == c)
                {
                    foundChar = true;
                } 
            }
            if(!foundChar)
            addingNonDenpendedChar(c);
        }

        public void addingNonDenpendedChar(char c)
        {
            if(isCharDependent == false)
            {
                orderOfNonDependent[charCount] = c;
                charCount++;
            }
        }

        public void CharCanBeWritten(char c, int currList)
        {
            var nonDenpendentChar = stepsList[currList].First;
            stepsList[currList].First.Value = nonDenpendentChar.Next.Value;
            nonDenpendentChar.Next.Value = '\0';
        }
    }
}
