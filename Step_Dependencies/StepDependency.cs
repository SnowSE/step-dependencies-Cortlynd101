using System;
using System.Collections.Generic;

namespace Step_Dependencies
{
    public class StepDependency
    {
        public List<LinkedList<char>> stepsList = new List<LinkedList<char>>();

        public StepDependency()
        {
        }
        public StepDependency(string file, StepDependency stepDependency)
        {
            stepsList = createStepsList(file, stepDependency);
        }
        private List<LinkedList<char>> createStepsList(string file, StepDependency stepDependency)
        //This method returns a List of LinkedLists of chars after creating said list based on a file.
        {
            return stepDependency.stepsList;
        }
    }
}
