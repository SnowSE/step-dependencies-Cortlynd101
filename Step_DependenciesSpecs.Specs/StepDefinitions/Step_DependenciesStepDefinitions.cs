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
                LinkedList<char> currentLinkedList = stepDependencyList.First();

                if (currentLinkedList.First != null) //We need to make sure the first node isn't null.
                {
                    LinkedListNode<char> currentLinkedListNode = currentLinkedList.First; //We grab the first node.

                    for (int i = 0; i < stepDependencyList.Count; i++) //We iterate through the list of linked lists as we don't know which linked list had the value.
                    {
                        
                        if (currentLinkedListNode.Value == c0) //Pass the first step.
                        {
                            currentLinkedListNode.Value.Should().Be(c0);
                            currentLinkedListNode = currentLinkedListNode.Next;

                            for (int j = 0; j < currentLinkedList.Count; j++)
                            {
                                if (currentLinkedListNode.Value == c1) //Pass the second step.
                                {
                                    currentLinkedListNode.Value.Should().Be(c1);
                                }

                                if (currentLinkedListNode.Next != null) //Make sure the next node isn't null.
                                {
                                    currentLinkedListNode = currentLinkedListNode.Next;
                                }

                                if (j == currentLinkedList.Count - 1 && currentLinkedListNode.Next == null) //This means that the next step couldn't be found and it fails the test.
                                {
                                    Exception noStepAfterInitalStep = new Exception( currentLinkedListNode.Value + "The step that was supposed to follow the inital step is not in the list.");
                                    throw noStepAfterInitalStep;
                                }
                            }
                        }
                        else //This means that it couldn't find that step and it fails the test.
                        {
                            Exception noInitalStep = new Exception( currentLinkedListNode.Value + "The inital step is not the head of a linked list in the list of linked lists.");
                            throw noInitalStep;
                        }

                        if (stepDependencyList[i + 1] != null) //Make sure the next list isn't null.
                        {
                            currentLinkedList = stepDependencyList[i + 1];
                        }  
                    }
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