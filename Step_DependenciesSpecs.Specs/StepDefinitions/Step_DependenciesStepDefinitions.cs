using System.IO;

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
            throw new PendingStepException();
        }

        [When(@"the line is parsed")]
        public void WhenTheLineIsParsed()
        {
            throw new PendingStepException();
        }

        [Then(@"(.*) is done before (.*)")]
        public void ThenCIsDoneBeforeA(char c0, char c1)
        {
            throw new PendingStepException();
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