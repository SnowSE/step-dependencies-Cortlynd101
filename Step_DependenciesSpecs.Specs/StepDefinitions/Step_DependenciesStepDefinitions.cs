using System.IO;
using Step_Dependencies;

namespace Step_DependenciesSpecs.Specs.StepDefinitions
{
    [Binding]
    public sealed class Step_DependenciesStepDefinitions
    {
        private readonly ScenarioContext context;
        public Step_DependenciesStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }
        
        [Given(@"the file path (.*)")]
        public void GivenTheFilePath(string s0)
        {
            string practiceFile = $"{s0}";
            context.Add("practiceFile", practiceFile);
        }

        [When(@"the line is parsed")]
        public void WhenTheLineIsParsed()
        {
            StepDependency stepDependency = new StepDependency(context.Get<string>("practiceFile"));
            context.Add("stepDependency", stepDependency);
        }

        [Then(@"(.*) is done before (.*)")]
        public void ThenCIsDoneBeforeA(char c0, char c1)
        {
            var stepDependencyList = context.Get<StepDependency>("stepDependency").stepsList;

            if (stepDependencyList.Count == 0) //This is the first fail condition. 
            {
                Exception stepDependencyListIsNull = new Exception("The list of linked lists is empty.");
                throw stepDependencyListIsNull;
            }
            else
            {
                bool succesfulTest = false;
                foreach (LinkedList<char> dependents in stepDependencyList)
                {
                    if (dependents.First.Value == c0)
                    {
                        dependents.First.Value.Should().Be(c0);
                        if (dependents.Last.Value == c1)
                        {
                            dependents.Last.Value.Should().Be(c1);
                            succesfulTest = true;
                        }
                    }
                }
                if (succesfulTest == false)
                {
                    Exception DependentPairNotInList = new Exception($"The dependency pair {c0}, {c1} was not found in the list.");
                }
            }
        }

        [Given(@"list head")]
        public void GivenListHead()
        {
            var dependencyClass = context.Get<StepDependency>("stepDependency");
            for (int i = 0; i < dependencyClass.stepsList.Count; i++)
            {
                dependencyClass.GetDependentOrder();
            } 
        }

        [Then(@"the (.*) step that is done should be (.*)")]
        public void ThenTheStepThatIsDoneShouldBeC(int p0, char c0)
        {
            context.Get<StepDependency>("stepDependency").orderOfNonDependent[p0].Should().Be(c0);
        }

        [Given(@"the letter (.*)")]
        public void GivenTheLetter(char c0)
        {
            context.Add("letter", c0);
        }

        [When(@"doing that process")]
        public void WhenDoingThatProcess()
        {
            int letterTime = Processes.getLetterTime(context.Get<char>("letter"));
            context.Add("letterTime", letterTime);
        }

        [Then(@"it should take (.*) seconds")]
        public void ThenItShouldTakeSeconds(int p0)
        {
            context.Get<int>("letterTime").Should().Be(p0);
        }

        [When(@"running multiple processes")]
        public void WhenRunningMultipleProcesses()
        {
            int totalTime = Processes.getTotalTime(context.Get<StepDependency>("stepDependency"));
            context.Add("totalTime", totalTime);

            int quickestTime = Processes.getQuickestTime(context.Get<StepDependency>("stepDependency"));
            context.Add("quickestTime", quickestTime);
        }

        [Then(@"the total time of the process should be (.*) seconds")]
        public void ThenTheTotalTimeOfTheProcessShouldBeSeconds(int p0)
        {
            context.Get<int>("totalTime").Should().Be(p0);
        }

        [Then(@"the quickest time should be (.*) seconds")]
        public void ThenTheQuickestTimeShouldBeSeconds(int p0)
        {
            context.Get<int>("quickestTime").Should().Be(p0);
        }
    }
}









