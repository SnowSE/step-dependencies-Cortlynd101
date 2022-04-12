using System;
using System.Collections.Generic;
using System.IO;

namespace Step_Dependencies
{
    public class StepDependency
    {
        public List<LinkedList<char>> stepsList = new List<LinkedList<char>>();

        public StepDependency()
        {
        }
        public StepDependency(string file)
        {
            stepsList = createStepsList(file);
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
    }
}
