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
            context.Add("stepsDependency", stepDependency);
        }

        [Then(@"(.*) is done before (.*)")]
        public void ThenCIsDoneBeforeA(char c0, char c1)
        {
            var stepDependencyList = context.Get<StepDependency>("stepsDependency").stepsList;

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
            throw new PendingStepException();
        }

        [When(@"checking against all nodes")]
        public void WhenCheckingAgainstAllNodes()
        {
            throw new PendingStepException();
        }

        [Then(@"the (.*) step that is done should be (.*)")]
        public void ThenTheStepThatIsDoneShouldBeC(int p0, char c0)
        {
            throw new PendingStepException();
        }

    }
}









